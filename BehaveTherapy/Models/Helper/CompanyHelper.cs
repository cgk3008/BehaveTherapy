using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public class CompanyHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        public ICollection<ApplicationUser> ListUsersInCompany(int companyId)
        {
            return db.Companies.Find(companyId).Users.ToList();
        }

        //public ICollection<ApplicationUser> ListAdminForCompany(int companyId)
        //{
        //    var admin = db.Companies.Find(companyId)/*.CompanyAdmin*/;
        //    var usr = db.Users.Find(admin).FullName;

        //    return null;
        //}


    }
}