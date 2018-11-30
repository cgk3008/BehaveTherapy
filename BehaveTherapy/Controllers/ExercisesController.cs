using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BehaveTherapy.Models;

namespace BehaveTherapy.Controllers
{
    public class ExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exercises
        public ActionResult Index()
        {
            var exercises = db.Exercises.Include(e => e.AssignedToUser).Include(e => e.Plan);
            return View(exercises.ToList());
        }

        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercises exercises = db.Exercises.Find(id);
            if (exercises == null)
            {
                return HttpNotFound();
            }
            return View(exercises);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.PlanId = new SelectList(db.TherapyPlan, "Id", "Name");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,PlanId,Created,Updated,TimeZoneCreated,StartDate,CompletionDate,DeadlineDate,AssignedToUserId")] Exercises exercises, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (UploadImageValidator.IsWebFriendlyImage(image))
                {
                    var fileName = Path.GetFileName(image.FileName);
                    image.SaveAs(Path.Combine(Server.MapPath("~/UploadVideo/"), fileName));
                    exercises.FileUrl = "/UploadVideo/" + fileName;
                }

                exercises.Created = DateTime.Now;

                db.Exercises.Add(exercises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "FirstName", exercises.AssignedToUserId);
            ViewBag.PlanId = new SelectList(db.TherapyPlan, "Id", "Name", exercises.PlanId);
            return View(exercises);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercises exercises = db.Exercises.Find(id);
            if (exercises == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "FirstName", exercises.AssignedToUserId);
            ViewBag.PlanId = new SelectList(db.TherapyPlan, "Id", "Name", exercises.PlanId);
            return View(exercises);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,PlanId,Created,Updated,TimeZoneCreated,StartDate,CompletionDate,DeadlineDate,AssignedToUserId")] Exercises exercises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "FirstName", exercises.AssignedToUserId);
            ViewBag.PlanId = new SelectList(db.TherapyPlan, "Id", "Name", exercises.PlanId);
            return View(exercises);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercises exercises = db.Exercises.Find(id);
            if (exercises == null)
            {
                return HttpNotFound();
            }
            return View(exercises);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercises exercises = db.Exercises.Find(id);
            db.Exercises.Remove(exercises);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        ////Post Assign an exercise thru email notification
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> AssignTicket([Bind(Include = "Id,Title,Description,Created,Updated,PlanId, AssignedToUserId, StartDate, DeadlineDate, TherapistId, Plan")] Exercises model)
        //{

        //    var exercise = db.Exercises.Find(model.Id);
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(model).State = EntityState.Modified;
        //        exercise.AssignedToUserId = model.AssignedToUserId;
        //        exercise.StartDate = model.StartDate;
        //        exercise.DeadlineDate = model.DeadlineDate;
        //        db.SaveChanges();
        //    }

        //    //I need to adjust callback below.  Details page should be ..... Create or assign a Details page.
        //    var callbackUrl = Url.Action("Details", "Tickets", new { id = exercise.Id }, protocol: Request.Url.Scheme);

        //    try
        //    {
        //        EmailService ems = new EmailService();
        //        IdentityMessage msg = new IdentityMessage();
        //        //User user = db.Users.Find(model.AssignedToUserId);
        //        ApplicationUser user = db.Users.Find(model.AssignedToUserId);

        //        msg.Body = "New Exercise Assignment." + Environment.NewLine + "Please click the following link to view the details " + "<a href=\"" + callbackUrl + "\">NEW EXERCISE</a>";

        //        msg.Destination = user.Email;
        //        msg.Subject = "Assigned Exercise";
        //        await ems.SendMailAsync(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        await Task.FromResult(0);
        //    }

        //    //NEED TO CREATE MY EXERCISES PAGE OR DASHBOARD FOR CLIENTS!
        //    return RedirectToAction("MyExercises");
        //}



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
