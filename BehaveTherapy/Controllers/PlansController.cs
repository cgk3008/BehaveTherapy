using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BehaveTherapy.Models;
using BehaveTherapy.Models.Helper;
using Microsoft.AspNet.Identity;

namespace BehaveTherapy.Controllers
{
    public class PlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plans
        public ActionResult Index()
        {
            //List<PlanIndexViewModel> model = new List<PlanIndexViewModel>();
            ////UserRolesHelper helper = new UserRolesHelper();

            //foreach (var User in db.Users)
            //{
            //    PlanIndexViewModel vm = new PlanIndexViewModel();
            //    //vm.Plan = plan;
            //    vm.Therapist = User;
            //    vm.AssignedToUser = User;
            //    model.Add(vm);
            //}
            //return View(model);



            return View(db.Plans.ToList());

            //List<PlanIndexViewModel> pmodel = new List<PlanIndexViewModel>();
            //var userId = User.Identity.GetUserId();
            //var plans = db.Plans.ToList();
            ////List<Plan> plans = db.Users.Find(userId).Plan.ToList();

            //foreach (Plan plan in plans)
            //{
            //    PlanIndexViewModel planModel = new PlanIndexViewModel()
            //    {
            //        //Plan = plan,
            //        Therapist = db.Users.Find(plan.TherapistId),
            //        AssignedToUser = db.Users.Find(plan.AssignedToUserId)

            //    };

            //    pmodel.Add(planModel);
            //}
            //return View(pmodel);
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            UserRolesHelper userRoles = new UserRolesHelper();

            var therapists = userRoles.ListUsersInRole("Therapist").ToList();
            ViewBag.TherapistId = new SelectList(therapists, "Id", "FullName");

            var clients = userRoles.ListUsersInRole("Client").ToList();   
            ViewBag.AssignedToUserId = new SelectList(clients, "Id", "FullName");

            var companies = db.Companies.ToList();
            ViewBag.CompanyId = new SelectList(companies, "Id", "CompanyName");


            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created,TherapistId,IsDeleted,AssignedToUserId, CompanyId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                //plan.TherapistId = User.Identity.GetUserId();
                //ApplicationUser user = db.Users.Find(plan.TherapistId);
                //plan.Users.Add(user);
                var userId = User.Identity.GetUserId();
                

                plan.Created = DateTime.Now;
                db.Plans.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }

            CompanyHelper compHelper = new CompanyHelper();
            var companyUsers = compHelper.ListUsersInCompanyFromPlan(id);
            ViewBag.AssignedToUserId = new SelectList(companyUsers, "Id", "FullName", plan.AssignedToUserId);

            UserRolesHelper userRoles = new UserRolesHelper();
            var therapists = userRoles.ListUsersInRole("Therapist").ToList();
            ViewBag.TherapistId = new SelectList(therapists, "Id", "FullName", plan.TherapistId);

            var clients = userRoles.ListUsersInRole("Client").ToList();
            ViewBag.AssignedToUserId = new SelectList(clients, "Id", "FullName");

            var companies = db.Companies.ToList();
            ViewBag.CompanyId = new SelectList(companies, "Id", "CompanyName");
            //ViewBag.PlanPriorityId = new SelectList(db.PlanPriorities, "Id", "Name", plan.PlanPriorityId);  
            //ViewBag.PlanStatusId = new SelectList(db.PlanStatus, "Id", "Name", plan.PlanStatusId);
            //ViewBag.PlanType = new SelectList(db.PlanTypes, "Id", "Name", plan.PlanTypeId);

            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created,TherapistId,IsDeleted,AssignedToUserId, CompanyId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                plan.CreateHistories();

                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();

                //for notifiation of changes to ticket PM and asssigned developer
                //var callbackUrl = Url.Action("Details", "Tickets", new { id = model.Id }, protocol: Request.Url.Scheme);
                //    try
                //    {
                //        EmailService ems = new EmailService();
                //        IdentityMessage msg = new IdentityMessage();
                //        //User user = db.Users.Find(model.AssignedToUserId);
                //        User user = db.Users.Find(model.AssignedToUserId);

                //        msg.Body = "New Ticket Change." + Environment.NewLine + "Please click the following link to view the details " + "<a href=\"" + callbackUrl + "\">CHANGE TO YOUR TICKET</a>";

                //        msg.Destination = user.Email;
                //        msg.Subject = "Changes to your ticket";
                //        await ems.SendMailAsync(msg);
                //    }
                //    catch (Exception ex)
                //    {
                //        await Task.FromResult(0);
                //    }
                //    if (User.IsInRole("Admin"))
                //    {
                //        return RedirectToAction("Index");
                //    }
                //    else
                //    {
                //        return RedirectToAction("MyTickets");
                //    }
                //}

                //ViewBag.OwnerUserId = new SelectList(db.Users, "Id", "FullName", model.OwnerUserId);
                //ViewBag.TicketPriorityId = new SelectList(db.Priority, "Id", "Name", model.TicketPriorityId);
                //ViewBag.ProjectId = new SelectList(db.Project, "Id", "Name", model.ProjectId);
                //ViewBag.TicketStatusId = new SelectList(db.Status, "Id", "Name", model.TicketStatusId);
                //ViewBag.TicketTypeId = new SelectList(db.Type, "Id", "Name", model.TicketTypeId);
                //return View(model);

                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            //return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plans.Find(id);
            db.Plans.Remove(plan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Projects/SoftDelete
        public ActionResult SoftDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Projects/SoftDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        //"Id,Name,Created,TherapistId,IsDeleted,AssignedToUserId, CompanyId")] Plan plan)
        public ActionResult SoftDelete([Bind(Include = "Id, Name, Created, TherapistId,IsDeleted, AssignedToUserId, CompanyId")] Plan plan)
        {
            if (ModelState.IsValid)
            {

                db.Entry(plan).State = EntityState.Modified;
                plan.IsDeleted = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(plan);
        }


        // GET: MyProjects
        [Authorize]
        public ActionResult MyPlans()
        {

            List<PlanIndexViewModel> vms = new List<PlanIndexViewModel>();
            var userId = User.Identity.GetUserId();
          

            //Likely need to add company id call for Company Admin to view plans in Index!!!! similar to below
            List<Plan> plans = db.Plans.Where( u => u.TherapistId == userId || u.AssignedToUserId == userId).ToList();
            //List<Exercises> exercises = db.Exercises.Where( e => e.Id == plans.)



            foreach (Plan plan in plans)
            {
                PlanIndexViewModel vm = new PlanIndexViewModel()
                {
                    Plan = plan,
                    Therapist = db.Users.Find(plan.TherapistId),
                    //why was I making code below so difficult, already had the exercies in the plan object!!!!
                    Exercises = plan.Exercises.ToList(),
                    //Exercises = db.Exercises.Where( e => e.Plans.Where(p => p.Id == plan.Id)),
                    UserId = userId
                };

                vms.Add(vm);
            }
            return View(vms);

        }

        // GET: MyProjects
        [Authorize]
        public ActionResult MyPlansSoftDeleteIndex()
        {

            List<PlanIndexViewModel> vms = new List<PlanIndexViewModel>();
            var userId = User.Identity.GetUserId();


            //Likely need to add company id call for Company Admin to view plans in Index!!!! similar to below
            List<Plan> plans = db.Plans.Where(u => u.TherapistId == userId || u.AssignedToUserId == userId).ToList();
            //List<Exercises> exercises = db.Exercises.Where( e => e.Id == plans.)



            foreach (Plan plan in plans)
            {
                PlanIndexViewModel vm = new PlanIndexViewModel()
                {
                    Plan = plan,
                    Therapist = db.Users.Find(plan.TherapistId),
                    //why was I making code below so difficult, already had the exercies in the plan object!!!!
                    Exercises = plan.Exercises.ToList(),
                    //Exercises = db.Exercises.Where( e => e.Plans.Where(p => p.Id == plan.Id)),
                    UserId = userId
                };

                vms.Add(vm);
            }
            return View(vms);

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
