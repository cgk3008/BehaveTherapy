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

            //below only works if one l=plan, do not have a Plans/Users table or many to many relationship, what the hell!!!!
            // var userPlans = db.Plans.Where(p => p.Users.Any(u => u.Id == userId)).ToList();
            var userPlans = db.Plans.Where(p => p.TherapistId == userId || p.AssignedToUserId == userId).ToList();


            //below is not what I want
            var userClients = db.Users.Where(u => u.Plan.All(p => p.TherapistId == userId )).ToList();

            //Actually, I want to show client, therapy plan and exercise Titles in Plan with count next to each one.

            //I thought below should work for Client dashboard
            var userExercises = db.Exercises.Where(n => n.AssignedToUserId == userId).ToList();

            //separate dashboard for Company Admin????


            //var userPlanNotifications = db.PlanNotifications.Where(n => n.UserId == userId).ToList();



            DashboardViewModel model = new DashboardViewModel()
            {
                Plans = userPlans,
                //PlanNotifications = userPlanNotifications,
                Exercises = userExercises,
                Users = userClients,
            };

            return View(model);
        }

        //{
        //    var userId = User.Identity.GetUserId();

        //    var userPlans = db.Plans.Where(p => p.TherapistId == userId).ToList();

        //    List<DashboardViewModel> model = new List<DashboardViewModel>();

        //    foreach (var User in db.Users)
        //    {
        //        DashboardViewModel dashmodel = new DashboardViewModel();
        //        dashmodel.User = User;
        //        Plan = userPlans;
        //        model.Add(dashmodel);
        //    }
        //    return View(model);

        //}



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