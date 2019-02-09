using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BehaveTherapy.Models;
using BehaveTherapy.Models.Helper;
using Microsoft.AspNet.Identity;

namespace BehaveTherapy.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        //// GET: My Companies
        //public ActionResult CompanyIndex()
        //{
        //    var userId = User.Identity.GetUserId();

        //    var userCompany = db.Users.FirstOrDefault( c => c.)

        //    return View(db.Companies.Where( c => c.Id == db.Users.).ToList());
        //}





        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,Address,City,State,ZipCode,IsDeleted")] Company company)
        {
            if (ModelState.IsValid /*&& company.Register.Equals(true)*/)
            {
                var user = User.Identity.GetUserId();

                //CompanyHelper helper = new CompanyHelper();

                //helper.AddUserToCompany(company.Users.Where(u => u.Id == user).ToString(), company.Id);

                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
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
            return RedirectToAction("Index", "Companies");
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,Address,City,State,ZipCode,IsDeleted")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            //var users = db.Companies.Where(u => u.Id == id).Any();
            //if ( users == true)
            //{
            //    return 
            //}
            

            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: MyCompanies
        //[Authorize]
        //public ActionResult MyCompany()
        //{
        //    List<CompanyIndexViewModel> vmodel = new List<CompanyIndexViewModel>();
        //    var userId = User.Identity.GetUserId();
        //    var userObject = db.Users.Where(u => u.Id == userId);

        //    var userCompanyId = userObject.FirstOrDefault();
        //    //    revise this now that Compnay notin users????  List<Company> companies = db.Users.Find(userId).Company.ToList();
        //    List<Company> companies = db.Companies.Where( c => c.Id == )

        //    foreach (Company company in companies)
        //    {
        //        CompanyIndexViewModel vm = new CompanyIndexViewModel()
        //        {
        //            Company = company,
        //            CompanyAdmin = db.Users.Find(company/*.CompanyAdmin*/),
        //            UserId = userId
        //        };
        //        vmodel.Add(vm);
        //    }
        //    return View(vmodel);
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
