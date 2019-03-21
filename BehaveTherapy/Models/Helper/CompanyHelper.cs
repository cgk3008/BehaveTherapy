using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public class CompanyHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        public Exception AddUserToCompany(string userId, int companyId)
        {
            try
            {
                var company = db.Companies.Find(companyId);
                var usr = db.Users.Find(userId);
                company.Users.Add(usr); /*why didn't this work with prj.Users.Add(str);*/
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Exception RemoveUserFromCompany(string userId, int companyId)
        {
            try
            {
                var company = db.Companies.Find(companyId);
                var usr = db.Users.Find(userId);
                company.Users.Remove(usr);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public ICollection<ApplicationUser> ListUsersInCompanyFromPlan(int? planId)
        {
            var companyId = db.Plans.Find(planId).CompanyId.Value;
            return db.Companies.Find(companyId).Users.ToList();
        }

        public ICollection<ApplicationUser> ListClientsInCompany(int companyId)
        {
            //UserRolesHelper helper = new UserRolesHelper();           
            //var clientList = helper.ListUsersInRole("Client");

            //List<ApplicationUser> roleUsers = new List<ApplicationUser>();
            //List<ApplicationUser> users = db.Companies.Find(companyId).Users.ToList();


            //so below gets users in company, but want to drill down to roles and get just clients



            return db.Companies.Find(companyId).Users.ToList(); ;



            //foreach (var u in users)
            //{
            //    if (IsUserInRole(u.Id, Role))
            //    {
            //        roleUsers.Add(u);
            //    }
            //}
            //return roleUsers;


        }

        public Exception ListUserCompanyId(string userId)
        {
            try
            {
                var usr = db.Users.Find(userId);
                //List<Company> companies = db.Users.Find(userId).Plan.

                // var userCompany = db.Users.Where(u => u.)


                //company.Users.Remove(usr);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        //public ICollection<ApplicationUser> ListAdminForCompany(int companyId)
        //{
        //    var admin = db.Companies.Find(companyId)/*.CompanyAdmin*/;
        //    var usr = db.Users.Find(admin).FullName;

        //    return null;
        //}


    }
}