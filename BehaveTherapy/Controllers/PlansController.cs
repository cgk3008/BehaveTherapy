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

            var clients = userRoles.ListUsersInRole("Client").ToList();

          

            ViewBag.AssignedToUserId = new SelectList(clients, "Id", "FullName");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created,TherapistId,IsDeleted,AssignedToUserId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                plan.TherapistId = User.Identity.GetUserId();
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
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created,TherapistId,IsDeleted,AssignedToUserId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
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
