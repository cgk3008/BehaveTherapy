using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public class PlanHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Exception AddUserToCompany(string userId, int planId)
        {
            try
            {
                var plan = db.Plans.Find(planId);
                var usr = db.Users.Find(userId);
                plan.Users.Add(usr); /*why didn't this work with prj.Users.Add(str);*/
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Exception RemoveUserFromCompany(string userId, int planId)
        {
            try
            {
                var plan = db.Plans.Find(planId);
                var usr = db.Users.Find(userId);
                plan.Users.Remove(usr);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public ICollection<ApplicationUser> ListUsersInPlan(int planId)
        {
            return db.Plans.Find(planId).Users.ToList();
        }

        //public ICollection<ApplicationUser> MyClients(int userId)
        //{
        //    //userId is the Therapist, next we want a list of users that are clients in the same company and have a planId created by the logged in Therapist (userId)

        //    var myCompanies = db.Companies.Where( c => c.Users. == userId )


        //    return db.Users.Find(userId)
        //}


    }
}