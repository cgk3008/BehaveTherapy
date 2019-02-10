using BehaveTherapy.Models;
using BehaveTherapy.Models.Helper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BehaveTherapy.Controllers
{
    public class AddRmvExerciseToPlanController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Plans.Include("Exercises").ToList());
        }

            //GET: AddExercise
            public ActionResult AddExercise(int id)
        {
            var plan = db.Plans.Find(id);
            AddRmvExerciseToPlan AddExercise = new AddRmvExerciseToPlan();           
            PlanHelper helper = new PlanHelper();
            var selected = plan.Exercises;
            AddExercise.Exercises = new MultiSelectList(db.Exercises, "Id", "Title", selected);
            AddExercise.Plan = plan;
            return View(AddExercise);

        }

        //POST: AddExercise
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExercise(AddRmvExerciseToPlan model)
        {
            PlanHelper helper = new PlanHelper();

            foreach (var exerciseadd in model.SelectedExercises)
            {
                helper.AddExerciseToPlan(exerciseadd, model.Plan.Id);
            }
            return RedirectToAction("Index", "Plans");
        }

        //GET: RemoveUser

        //ok i don't want list of users to remove, just the one linked to the user.Id
       public ActionResult RemoveExercise(int exId, int planId)
        {
            var plan = db.Plans.Find(planId);
            AddRmvExerciseToPlan RmvExercise = new AddRmvExerciseToPlan();           
            PlanHelper helper = new PlanHelper();
            var selected = exId;
            RmvExercise.RmvExercise = db.Exercises.Find(exId);
            RmvExercise.Plan = plan;
            return View(RmvExercise);

        }

        //POST: RemoveUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveExercise(AddRmvExerciseToPlan model)
        {

            var plan = db.Plans.Find(model.Plan.Id);
            var exercise = db.Exercises.Find(model.RmvExercise.Id);
            plan.Exercises.Remove(exercise);
            db.SaveChanges();

            return RedirectToAction("Index", "Plans");
        }

    }
}
