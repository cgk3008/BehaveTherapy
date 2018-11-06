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
    public class TherapyPlanHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TherapyPlanHistories
        public ActionResult Index()
        {
            var therapyPlanHistories = db.TherapyPlanHistories.Include(t => t.TherapyPlan).Include(t => t.User);
            return View(therapyPlanHistories.ToList());
        }

        // GET: TherapyPlanHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlanHistory therapyPlanHistory = db.TherapyPlanHistories.Find(id);
            if (therapyPlanHistory == null)
            {
                return HttpNotFound();
            }
            return View(therapyPlanHistory);
        }

        // GET: TherapyPlanHistories/Create
        public ActionResult Create()
        {
            ViewBag.TherapyPlanId = new SelectList(db.TherapyPlan, "Id", "Name");
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            return View();
        }

        // POST: TherapyPlanHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TherapyPlanId,Property,OldValue,NewValue,Changed,UserId")] TherapyPlanHistory therapyPlanHistory)
        {
            if (ModelState.IsValid)
            {
                db.TherapyPlanHistories.Add(therapyPlanHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TherapyPlanId = new SelectList(db.TherapyPlan, "Id", "Name", therapyPlanHistory.TherapyPlanId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", therapyPlanHistory.UserId);
            return View(therapyPlanHistory);
        }

        // GET: TherapyPlanHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlanHistory therapyPlanHistory = db.TherapyPlanHistories.Find(id);
            if (therapyPlanHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.TherapyPlanId = new SelectList(db.TherapyPlan, "Id", "Name", therapyPlanHistory.TherapyPlanId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", therapyPlanHistory.UserId);
            return View(therapyPlanHistory);
        }

        // POST: TherapyPlanHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TherapyPlanId,Property,OldValue,NewValue,Changed,UserId")] TherapyPlanHistory therapyPlanHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapyPlanHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TherapyPlanId = new SelectList(db.TherapyPlan, "Id", "Name", therapyPlanHistory.TherapyPlanId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", therapyPlanHistory.UserId);
            return View(therapyPlanHistory);
        }

        // GET: TherapyPlanHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlanHistory therapyPlanHistory = db.TherapyPlanHistories.Find(id);
            if (therapyPlanHistory == null)
            {
                return HttpNotFound();
            }
            return View(therapyPlanHistory);
        }

        // POST: TherapyPlanHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TherapyPlanHistory therapyPlanHistory = db.TherapyPlanHistories.Find(id);
            db.TherapyPlanHistories.Remove(therapyPlanHistory);
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
