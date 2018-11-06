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
    public class PlanTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanTypes
        public ActionResult Index()
        {
            return View(db.PlanTypes.ToList());
        }

        // GET: PlanTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = db.PlanTypes.Find(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // GET: PlanTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PlanType planType)
        {
            if (ModelState.IsValid)
            {
                db.PlanTypes.Add(planType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planType);
        }

        // GET: PlanTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = db.PlanTypes.Find(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // POST: PlanTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PlanType planType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planType);
        }

        // GET: PlanTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = db.PlanTypes.Find(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // POST: PlanTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanType planType = db.PlanTypes.Find(id);
            db.PlanTypes.Remove(planType);
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
