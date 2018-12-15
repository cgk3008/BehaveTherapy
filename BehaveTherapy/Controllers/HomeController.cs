using BehaveTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BehaveTherapy.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var userPlans = db.TherapyPlan.Where(p => p.Users.Any(u => u.Id == userId)).ToList();
            var userExercises = db.Exercises.Where(n => n.AssignedToUserId == userId).ToList();
            //var userPlanNotifications = db.PlanNotifications.Where(n => n.UserId == userId).ToList();



            DashboardViewModel model = new DashboardViewModel()
            {
                Plans = userPlans,
                //PlanNotifications = userPlanNotifications,
                Exercises = userExercises
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult DemoLogin()
        //{
        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult LP()
        //{
        //    return View();
        //}
    }
}