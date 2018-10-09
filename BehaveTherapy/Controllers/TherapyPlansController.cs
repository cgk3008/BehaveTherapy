using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BehaveTherapy.Models;

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
            return View();
        }

        // POST: TherapyPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created,TherapistId,IsDeleted")] TherapyPlan therapyPlan)
        {
            if (ModelState.IsValid)
            {
                therapyPlan.Created = DateTime.Now;
                therapyPlan.IsDeleted = false;
                db.TherapyPlan.Add(therapyPlan);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

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
