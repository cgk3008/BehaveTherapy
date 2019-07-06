using BehaveTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        ////Post: ExerciseCompleted
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExerciseCompleted(int planId, int exerciseId)
        //{
        //    var plan = db.Plans.Find(planId);
        //    ExerciseLog ExerciseCompleted = new ExerciseLog();

        //    try
        //    {
        //        var plan = db.Plans.Find(planId);
        //        var exercise = db.Exercises.Find(exerciseId);

        //        plan.Logs.Add(exercise);
        //        db.SaveChanges();
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex;
        //    }


        //}


    }
}