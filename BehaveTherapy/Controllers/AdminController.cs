using BehaveTherapy.Models;
using BehaveTherapy.Models.Helper;
using BehaveTherapy.Models;
using BehaveTherapy.Models.Helper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace BehaveTherapy.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext dB = new ApplicationDbContext();

        public ActionResult Index()
        {

            List<AdminIndexViewModel> model = new List<AdminIndexViewModel>();
            UserRolesHelper helper = new UserRolesHelper();

            foreach (var User in dB.Users)
            {
                AdminIndexViewModel vm = new AdminIndexViewModel();
                vm.User = User;
                vm.Roles = helper.ListRolesForUser(User.Id);
                model.Add(vm);
            }
            return View(model);
        }

        //GET: EditUser
        public ActionResult EditUser(string id)
        {
            var user = dB.Users.Find(id);
            AdminModel AdminModel = new AdminModel();
            UserRolesHelper helper = new UserRolesHelper();
            var selected = helper.ListRolesForUser(id);
            AdminModel.Roles = new MultiSelectList(dB.Roles, "Name", "Name", selected);
            AdminModel.User = new ApplicationUser
            {
                Id = user.Id,
                FullName = user.FullName
            };
            return View(AdminModel);

            //new { id = mod.User.Id })
        }

        //POST: EditUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(AdminModel model) 
        {
            //var user = dB.Users.Find(model.id);
            UserRolesHelper helper = new UserRolesHelper();
            foreach (var rolermv in dB.Roles.Select(r => r.Name).ToList())
            {
                helper.RemoveUserFromRole(model.User.Id, rolermv);
            }
            foreach (var roleadd in model.SelectedRoles)
            {
                helper.AddUserToRole(model.User.Id, roleadd);
            }
            return RedirectToAction("Index");
        }


        ////Get: CreateUser
        //public ActionResult CreateUser()
        //{


        //    return View();
        //}

        //// POST: /CreateUser
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateUser(AdminModel model)
        //{




        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.User.Email, Email = model.User.Email, FullName = model.User.FullName, };
        //        var result = await UserManager.CreateAsync(user, model.User.PasswordHash);
        //        if (result.Succeeded)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
        //            // Send an email with this link
        //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account 

        //            //  add if user email equals allowed email in therapist list then add    UserManager.AddToRole(user.Id, "Therapist");

        //            UserManager.AddToRole(user.Id, "Client");

        //            return RedirectToAction("Index", "Home");
        //        }
        //        AddErrors(result);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}


        //GET: Users not in role
        public ActionResult UsersNotInRole(string id)
        {
            var user = dB.Users.Find(id);
            AdminModel AdminModel = new AdminModel();
            UserRolesHelper helper = new UserRolesHelper();
            var selected = helper.ListUsersNotInRole(id);
            AdminModel.Roles = new MultiSelectList(dB.Roles, "Name", "Name", selected);
            AdminModel.User = new ApplicationUser
            {
                Id = user.Id,
                FullName = user.FullName
            };
            return View(AdminModel);

            //new { id = mod.User.Id })
        }

        //POST: Users not in role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsersNotInRole(AdminModel model)
        {
            //var user = dB.Users.Find(model.id);
            UserRolesHelper helper = new UserRolesHelper();
            foreach (var rolermv in dB.Roles.Select(r => r.Name).ToList())
            {
                helper.RemoveUserFromRole(model.User.Id, rolermv);
            }
            foreach (var roleadd in model.SelectedRoles)
            {
                helper.AddUserToRole(model.User.Id, roleadd);
            }
            return RedirectToAction("Index");
        }

        //GET: Is user in role







    }
}





