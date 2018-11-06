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
    public class PlanStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanStatus
        public ActionResult Index()
        {
            return View(db.PlanStatus.ToList());
        }

        // GET: PlanStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanStatus planStatus = db.PlanStatus.Find(id);
            if (planStatus == null)
            {
                return HttpNotFound();
            }
            return View(planStatus);
        }

        // GET: PlanStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsCompleted")] PlanStatus planStatus)
        {
            if (ModelState.IsValid)
            {
                db.PlanStatus.Add(planStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planStatus);
        }

        // GET: PlanStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanStatus planStatus = db.PlanStatus.Find(id);
            if (planStatus == null)
            {
                return HttpNotFound();
            }
            return View(planStatus);
        }

        // POST: PlanStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsCompleted")] PlanStatus planStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planStatus);
        }

        // GET: PlanStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanStatus planStatus = db.PlanStatus.Find(id);
            if (planStatus == null)
            {
                return HttpNotFound();
            }
            return View(planStatus);
        }

        // POST: PlanStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanStatus planStatus = db.PlanStatus.Find(id);
            db.PlanStatus.Remove(planStatus);
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
