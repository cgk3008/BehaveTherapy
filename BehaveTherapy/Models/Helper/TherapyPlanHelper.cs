using BehaveTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models.Helper
{
    public class TherapyPlanHelper
    {


        private ApplicationDbContext dB = new ApplicationDbContext();

        public Exception AddUserToTherapyPlan(string userId, int therapyPlanId)
        {
            try
            {
                var prj = dB.TherapyPlan.Find(therapyPlanId);
                var usr = dB.Users.Find(userId);
                prj.Users.Add(usr); /*why didn't this work with prj.Users.Add(str);*/
                dB.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Exception RemoveUserFromTherapyPlan(string userId, int therapyPlanId)
        {
            try
            {
                var prj = dB.TherapyPlan.Find(therapyPlanId);
                var usr = dB.Users.Find(userId);
                prj.Users.Remove(usr);
                dB.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public ICollection<ApplicationUser> ListUsersOnTherapyPlan(int therapyPlanId)
        {
            return dB.TherapyPlan.Find(therapyPlanId).Users.ToList();
        }

        public ICollection<ApplicationUser> ListPmForTherapyPlan(int therapyPlanId)
            //do i need to User above to "string"?
        {
            var therapist = dB.TherapyPlan.Find(therapyPlanId).TherapistId;
            var usr = dB.Users.Find(therapist).FullName;
            //dB.Users.Find(therapist).FullName;

            return null;
        }

        public ICollection<TherapyPlan> ListTherapyPlansForUser(string userId)
        {

            //var isnotdeleted = dB.TherapyPlan.Where(p => p.IsDeleted == false).ToList();
            //var proj = isnotdeleted.Users.Find(userId).
            //    var therapyPlans = dB.Users.Find(userId).TherapyPlan.ToList();

            //if (therapyPlans != null)
            //{
            //    therapyPlans.
            //}

            return dB.Users.Find(userId).TherapyPlan.ToList();

            //all this code simplified above
            //var usr = dB.Users.Find(userId);
            //List<TherapyPlan> ProjUsers = new List<TherapyPlan>();

            //try
            //{
            //    var prj = dB.TherapyPlan.ToList();
            //    foreach (var p in prj)
            //    {
            //        if(p.Users.Contains(usr))
            //        {
            //            ProjUsers.Add(p);
            //        }
            //    }
            //    return ProjUsers;             
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return null;
            //}                
        }
        


        //IsUserOnTherapyPlan
        public bool IsUserOnTherapyPlan(string userId, int therapyPlanId)
        {
            try
            {
                var prj = dB.TherapyPlan.Find(therapyPlanId);
                var usr = dB.Users.Find(userId);
                //prj.User.Find(usr);

                //var result = dB.Users.Find(userId);
                if (prj.Users != null)
                {

                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }



        //UserNotOnTherapyPlan(edited)

        public ICollection<string> ListUsersNotOnTherapyPlan(int therapyPlanId)
        {
            List<string> usersNotProj = new List<string>();
            var users = dB.Users;

            foreach (var u in users)
            {
                if (!IsUserOnTherapyPlan(u.Id, therapyPlanId))
                {
                    usersNotProj.Add(u.DisplayName);
                }
            }
            return usersNotProj;
        }

    }
}