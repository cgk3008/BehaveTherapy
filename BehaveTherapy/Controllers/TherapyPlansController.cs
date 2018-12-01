using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BehaveTherapy.Models;
using BugTracker.Models.Helper;
using Microsoft.AspNet.Identity;

namespace BehaveTherapy.Controllers
{
    public class TherapyPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TherapyPlans
        public ActionResult Index()
        {
            return View(db.TherapyPlan.ToList());
        }

        // GET: TherapyPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlan therapyPlan = db.TherapyPlan.Find(id);
            if (therapyPlan == null)
            {
                return HttpNotFound();
            }
            return View(therapyPlan);
        }

        // GET: TherapyPlans/Create
        public ActionResult Create()
        {
            //var userId = User.Identity.GetUserId();

            //Models.UserRolesHelper helper = new Models.UserRolesHelper();


            //// really I need a list of my clients!!!!!  so that is role client and therapistId == user.Id
            ////Therapist needs to create client account with basic information, first name, last name, email address.  Then on account creation, an email is sent to client asking them to register themselves and add any additional information......
            //var users = helper.ListUsersInRole("Client").ToList();

            ////var my clients = users.Where(c => c.TherapyPlan == userId).ToList();

            //TherapyPlanHelper planHelper = new TherapyPlanHelper();
            //var planlist = planHelper.ListTherapyPlansForUser(userId);

            //ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "FullName");

            return View();
        }

        // POST: TherapyPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created,TherapistId, AssignedToUserId, IsDeleted")] TherapyPlan therapyPlan)
        {
            if (ModelState.IsValid)
            {
                // oh man, gotta add a lot more parameters to model and below.  Frequency! , deadline, should I add this on plan creation, or edit the plan with exercises added with deadline, frequency etc.?????  Edit plan and add exercises which ties an exercise to the plan and the plan designates the frequency and due dates.....???? Yeah, bit different than bug tracker.....
                therapyPlan.TherapistId = User.Identity.GetUserId();
                //therapyPlan.AssignedToUserId = 
                therapyPlan.Created = DateTime.Now;
                therapyPlan.IsDeleted = false;
                db.TherapyPlan.Add(therapyPlan);
                db.SaveChanges();
                //return RedirectToAction("Index");  
            }




            //ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "FullName", therapyPlan.AssignedToUserId);


            return View(therapyPlan); 
            //SO bug tracker has below code
            //return RedirectToAction("Index", "AdminProjects");
            // this is for the admin to add and remove users to projects etc.,  I guess we would have to do that, but if app gets popular, then we may want this automated for quicker setup!!!!
        
        }

        // GET: TherapyPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlan therapyPlan = db.TherapyPlan.Find(id);
            if (therapyPlan == null)
            {
                return HttpNotFound();
            }

            Models.UserRolesHelper helper = new Models.UserRolesHelper();
            var therapistList = helper.ListUsersInRole("");
            return View(therapyPlan);
        }

        // POST: TherapyPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created,TherapistId,IsDeleted")] TherapyPlan therapyPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapyPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(therapyPlan);
        }

        // GET: TherapyPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlan therapyPlan = db.TherapyPlan.Find(id);
            if (therapyPlan == null)
            {
                return HttpNotFound();
            }
            return View(therapyPlan);
        }

        // POST: TherapyPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TherapyPlan therapyPlan = db.TherapyPlan.Find(id);
            db.TherapyPlan.Remove(therapyPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: MyProjects
        [Authorize]
        public ActionResult MyTherapyPlans()
        {

            List<PlanIndexViewModel> vms = new List<PlanIndexViewModel>();
            var userId = User.Identity.GetUserId();
            List<TherapyPlan> plans = db.Users.Find(userId).TherapyPlan.ToList();

            foreach (TherapyPlan plan in plans)
            {
                PlanIndexViewModel vm = new PlanIndexViewModel()
                {
                    Plan = plan,
                    Therapist = db.Users.Find(plan.TherapistId),

                    UserId = userId
                };

                vms.Add(vm);
            }
            return View(vms);

            //var tickets = db.Ticket.Where(t => t.Project.PmId == userId).ToList();
            //return View(tickets.ToList());



            //var userId = User.Identity.GetUserId();
            ////return View(dB.Users.Find(userId).Ticket.ToList());

            ////example from assignedProjects controller return View(dB.Users.Find(userId).Project.ToList()); can't figure out why above does not work, need to look at ticket model more compared to project model

            //return View(dB.Users.Find(userId).Project.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
