using BehaveTherapy.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BehaveTherapy.Controllers
{
    public class ExerciseLogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseLog
        public ActionResult Index()
        {
            return View();
        }

        //Post: ExerciseCompleted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExerciseCompleted([Bind(Include = "Id, ExerciseId, PlanId, UserId")] ExerciseLog exerciseLog/*, Exercises exercise, Plan plan*/)

        //int planId, int exerciseId)
        {
            if (ModelState.IsValid)
            {
                //var plan = db.Plans.Find(planId);
                //ExerciseLog exerciseCompleted = new ExerciseLog();
                exerciseLog.UserId = User.Identity.GetUserId();
                exerciseLog.ExerciseCompleteDate = DateTime.Now;

                //db.Logs.Add(exerciseLog);
                db.ExerciseLogs.Add(exerciseLog);
                db.SaveChanges();

                //try
                //{

                //    var exercise = db.ExerciseLog.Find(exerciseId);



                //    plan.Logs.Add(exercise);
                //    db.SaveChanges();
                //    return null;
                //}
                //catch (Exception ex)
                //{
                //    return ex;
                //}
            }

            return RedirectToAction("Details", "Exercises", new { id = exerciseLog.ExerciseId });
        }


    }
}