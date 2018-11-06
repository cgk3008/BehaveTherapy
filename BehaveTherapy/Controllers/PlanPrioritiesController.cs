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
    public class PlanPrioritiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanPriorities
        public ActionResult Index()
        {
            return View(db.PlanPriorities.ToList());
        }

        // GET: PlanPriorities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanPriority planPriority = db.PlanPriorities.Find(id);
            if (planPriority == null)
            {
                return HttpNotFound();
            }
            return View(planPriority);
        }

        // GET: PlanPriorities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanPriorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PlanPriority planPriority)
        {
            if (ModelState.IsValid)
            {
                db.PlanPriorities.Add(planPriority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planPriority);
        }

        // GET: PlanPriorities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanPriority planPriority = db.PlanPriorities.Find(id);
            if (planPriority == null)
            {
                return HttpNotFound();
            }
            return View(planPriority);
        }

        // POST: PlanPriorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PlanPriority planPriority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planPriority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planPriority);
        }

        // GET: PlanPriorities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanPriority planPriority = db.PlanPriorities.Find(id);
            if (planPriority == null)
            {
                return HttpNotFound();
            }
            return View(planPriority);
        }

        // POST: PlanPriorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanPriority planPriority = db.PlanPriorities.Find(id);
            db.PlanPriorities.Remove(planPriority);
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
