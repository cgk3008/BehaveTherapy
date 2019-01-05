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
    public class TherapyPlanCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TherapyPlanComments
        public ActionResult Index()
        {
            var therapyPlanComments = db.TherapyPlanComments.Include(t => t.Ticket).Include(t => t.User);
            return View(therapyPlanComments.ToList());
        }

        // GET: TherapyPlanComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlanComments therapyPlanComments = db.TherapyPlanComments.Find(id);
            if (therapyPlanComments == null)
            {
                return HttpNotFound();
            }
            return View(therapyPlanComments);
        }

        // GET: TherapyPlanComments/Create
        public ActionResult Create()
        {
            ViewBag.TicketId = new SelectList(db.Plans, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: TherapyPlanComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Body,Created,Updated,TicketId,UserId,FileUrl,IsDeleted")] TherapyPlanComments therapyPlanComments)
        {
            if (ModelState.IsValid)
            {
                db.TherapyPlanComments.Add(therapyPlanComments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(db.Plans, "Id", "Name", therapyPlanComments.TicketId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", therapyPlanComments.UserId);
            return View(therapyPlanComments);
        }

        // GET: TherapyPlanComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlanComments therapyPlanComments = db.TherapyPlanComments.Find(id);
            if (therapyPlanComments == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.Plans, "Id", "Name", therapyPlanComments.TicketId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", therapyPlanComments.UserId);
            return View(therapyPlanComments);
        }

        // POST: TherapyPlanComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Body,Created,Updated,TicketId,UserId,FileUrl,IsDeleted")] TherapyPlanComments therapyPlanComments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapyPlanComments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.Plans, "Id", "Name", therapyPlanComments.TicketId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", therapyPlanComments.UserId);
            return View(therapyPlanComments);
        }

        // GET: TherapyPlanComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TherapyPlanComments therapyPlanComments = db.TherapyPlanComments.Find(id);
            if (therapyPlanComments == null)
            {
                return HttpNotFound();
            }
            return View(therapyPlanComments);
        }

        // POST: TherapyPlanComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TherapyPlanComments therapyPlanComments = db.TherapyPlanComments.Find(id);
            db.TherapyPlanComments.Remove(therapyPlanComments);
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
