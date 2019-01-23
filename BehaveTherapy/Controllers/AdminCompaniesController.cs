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
    public class AdminCompaniesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //Jeez look at all this code I don't need!!!!
            //List<AdminIndexViewModel> model = new List<AdminIndexViewModel>();
            //ProjectHelper helper = new ProjectHelper();

            //foreach (var Project in dB.Project)
            //{
            //    AdminIndexViewModel vm = new AdminIndexViewModel();
            //    vm.Project = Project;
            //    vm.Users = helper.ListProjectsForUser(User.Id);
            //    model.Add(vm);
            //}   

            return View(db.Companies.Include("Users").ToList());



            //ok need to adjust Users to User. go to project and adjust dB context reference, ok Antonio helped me do this. Change one, then build then go through error list. Then updated database.
        }

        public ActionResult MyCompany()
        {
            //List<CompanyIndexViewModel> vmodel = new List<CompanyIndexViewModel>();
            //var userId = User.Identity.GetUserId();
            //List<Company> companies = db.Users.Find(userId).Company.ToList();

            //foreach (Company company in companies)
            //{
            //    CompanyIndexViewModel vm = new CompanyIndexViewModel()
            //    {
            //        Company = company,
            //        CompanyAdmin = db.Users.Find(company.CompanyAdmin),
            //        UserId = userId
            //    };
            //    vmodel.Add(vm);
            //}
            //return View(vmodel);

            var userId = User.Identity.GetUserId();

            var userCompId = db.Users.Where( u => u.Company.Where( c => c.))

            //var company = db.Users.Find(userId).Company;

            if (User.IsInRole("CompanyAdmin"))
            {
                var myCompany = db.Companies.Where(c => c.CompanyAdmin.Id == userId).ToList();
                return View(myCompany);
            }

            if (User.IsInRole("Therapist"))
            {
                var myCompany = db.Companies.Where(c => c.Id == 
                return View(myCompany);
            }


            else //temperory test if redirect works
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //GET: AddUser
        public ActionResult AddToCompany(int id)
        {
            var company = db.Companies.Find(id);
            AdminCompany AdminCompany = new AdminCompany();
            CompanyHelper helper = new CompanyHelper();
            var selected = company.Users;
            AdminCompany.Users = new MultiSelectList(db.Users, "Id", "FullName", selected);
            AdminCompany.Company = company;
            return View(AdminCompany);

        }

        //POST: AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCompany(AdminCompany model)
        {

            CompanyHelper helper = new CompanyHelper();


            foreach (var useradd in model.SelectedUsers)
            {
                helper.AddUserToCompany(useradd, model.Company.Id);
            }
            return RedirectToAction("Index", "AdminCompanies");
        }

        //GET: RemoveUser

        //ok i don't want list of users to remove, just the one linked to the user.Id
        public ActionResult RemoveUser(int id, string userId)
        {


            AdminCompany AdminCompany = new AdminCompany();
            var company = db.Companies.Find(id);
            Company rmvuser = new Company();
            var selected = userId;
            AdminCompany.RmvUser = db.Users.Find(userId);
            AdminCompany.Company = company;

            return View(AdminCompany);
        }

        //POST: RemoveUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUser(AdminCompany model)
        {

            var company = db.Companies.Find(model.Company.Id);
            var usr = db.Users.Find(model.RmvUser.Id);
            company.Users.Remove(usr);
            db.SaveChanges();

            return RedirectToAction("Index", "AdminCompanies");
        }

    }
}
