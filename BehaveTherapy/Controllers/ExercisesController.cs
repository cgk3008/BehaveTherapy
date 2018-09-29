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
    public class ExercisesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        //Post Assign an exercise thru email notification
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AssignTicket([Bind(Include = "Id,Title,Description,Created,Updated,PlanId, AssignedToUserId, StartDate, DeadlineDate, TherapistId, Plan")] Exercises model)
        {

            var exercise = db.Exercises.Find(model.Id);
            if (ModelState.IsValid)
            {
                //db.Entry(model).State = EntityState.Modified;
                exercise.AssignedToUserId = model.AssignedToUserId;
                exercise.StartDate = model.StartDate;
                exercise.DeadlineDate = model.DeadlineDate;
                db.SaveChanges();
            }

            //I need to adjust callback below.  Details page should be ..... Create or assign a Details page.
            var callbackUrl = Url.Action("Details", "Tickets", new { id = exercise.Id }, protocol: Request.Url.Scheme);

            try
            {
                EmailService ems = new EmailService();
                IdentityMessage msg = new IdentityMessage();
                //User user = db.Users.Find(model.AssignedToUserId);
                ApplicationUser user = db.Users.Find(model.AssignedToUserId);

                msg.Body = "New Exercise Assignment." + Environment.NewLine + "Please click the following link to view the details " + "<a href=\"" + callbackUrl + "\">NEW EXERCISE</a>";

                msg.Destination = user.Email;
                msg.Subject = "Assigned Exercise";
                await ems.SendMailAsync(msg);
            }
            catch (Exception ex)
            {
                await Task.FromResult(0);
            }

            //NEED TO CREATE MY EXERCISES PAGE OR DASHBOARD FOR CLIENTS!
            return RedirectToAction("MyExercises");
        }








    }
}