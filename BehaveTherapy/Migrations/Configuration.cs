namespace BehaveTherapy.Migrations
{
    using BehaveTherapy.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BehaveTherapy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BehaveTherapy.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole();

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "CompanyAdmin"))
            {
                role = new IdentityRole { Name = "CompanyAdmin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Client"))
            {
                role = new IdentityRole { Name = "Client" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Therapist"))
            {
                role = new IdentityRole { Name = "Therapist" };
                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.Email == "cgk3008.ck@gmail.com"))
            {
                var user = new ApplicationUser

                {
                    UserName = "cgk3008.ck@gmail.com",
                    Email = "cgk3008.ck@gmail.com",
                    FirstName = "Cliff",
                    LastName = "Koenig",
                    DisplayName = "ADMIN",
                    FullName = "Cliff Koenig"
                };


                userManager.Create(user, "Redd62!");

                userManager.AddToRoles(user.Id,
                    new string[] {
                        "Admin"
                    });
            }


            if (!context.Users.Any(u => u.Email == "rhoov25@gmail.com"))
            {
                var user = new ApplicationUser

                {
                    UserName = "rhoov25@gmail.com",
                    Email = "rhoov25@gmail.com",
                    FirstName = "Rachel",
                    LastName = "Hoover",
                    DisplayName = "ADMIN",
                    FullName = "Rachel Hoover"
                };


                userManager.Create(user, "GeauxLSU86!");

                userManager.AddToRoles(user.Id,
                    new string[] {
                        "Admin"
                    });
            }




            if (!context.Users.Any(u => u.Email == "developer@demo.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "developer@demo.com",
                    Email = "developer@demo.com",
                    FirstName = "Therapist",
                    LastName = "Example",
                    DisplayName = "Anastasia Clementine",
                    FullName = "Anastasia Clementine"
                };

                userManager.Create(user, "Abc&6126!");

                userManager.AddToRoles(user.Id,
                    new string[] {
                        "Therapist"
                    });
            }
            if (!context.Users.Any(u => u.Email == "submitter@demo.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "submitter@demo.com",
                    Email = "submitter@demo.com",
                    FirstName = "Client",
                    LastName = "Example",
                    DisplayName = "Tom Hank",
                    FullName = "Tom Hank"
                };

                userManager.Create(user, "Abc&4323!");

                userManager.AddToRoles(user.Id,
                    new string[] {
                        "Client"
                    });
            }

            if (!context.Users.Any(u => u.Email == "craig228800@gmail.com"))
            {
                var user = new ApplicationUser

                {
                    UserName = "craig228800@gmail.com",
                    Email = "craig228800@gmail.com",
                    FirstName = "Craig",
                    LastName = "Kilborn",
                    DisplayName = "Company ADMIN",
                    FullName = "Craig Kilborn"
                };


                userManager.Create(user, "Ck228800");

                userManager.AddToRoles(user.Id,
                    new string[] {
                        "CompanyAdmin"
                    });
            }


            if (!context.Plans.Any( t => t.Name == "Group 1"))
            {
                var tp = new Plan
                {
                    Name = "Group 1",
                    Created = DateTime.Now,
                    TherapistId = "d24cfa8e-36c0-441e-8454-cb68b349689d",
                    IsDeleted = false,
                    AssignedToUserId = "0ab23451-4ff1-4f7b-9714-19a081b96965"
                };

                context.Plans.Add(new Plan { Name = "Group 1" });                
            }

            if (!context.Companies.Any(t => t.CompanyName == "Test Company22"))
            {
                var comp = new Company
                {
                    CompanyName = "Test Company 22",
                    Address = "22 North Ave",
                    City = "Jacksonville Beach",
                    State = "Florida",
                    ZipCode = "32256",
                    IsDeleted = false,

                    CompanyAdmin = userManager.FindByEmail("craig228800@gmail.com"),
                    
                };

                context.Companies.Add(new Company { CompanyName = "Test Company 22" });


            }


            //if (!context.Priority.Any(u => u.Name == "Urgent"))
            //{ context.Priority.Add(new PlanPriority { Name = "Urgent" }); }

            //if (!context.Priority.Any(u => u.Name == "High"))
            //{ context.Priority.Add(new PlanPriority { Name = "High" }); }

            //if (!context.Priority.Any(u => u.Name == "Medium"))
            //{ context.Priority.Add(new PlanPriority { Name = "Medium" }); }

            //if (!context.Priority.Any(u => u.Name == "Low"))
            //{ context.Priority.Add(new PlanPriority { Name = "Low" }); }



            //if (!context.Type.Any(u => u.Name == "Production Fix"))
            //{ context.Type.Add(new PlanType { Name = "Production Fix" }); }

            //if (!context.Type.Any(u => u.Name == "Project Task"))
            //{ context.Type.Add(new PlanType { Name = "Project Task" }); }

            //if (!context.Type.Any(u => u.Name == "Software Update"))
            //{ context.Type.Add(new PlanType { Name = "Software Update" }); }


            //if (!context.Status.Any(u => u.Name == "New"))
            //{ context.Status.Add(new PlanStatus { Name = "New" }); }

            //if (!context.Status.Any(u => u.Name == "Active"))
            //{ context.Status.Add(new PlanStatus { Name = "In Development" }); }

            //if (!context.Status.Any(u => u.Name == "Completed"))
            //{ context.Status.Add(new PlanStatus { Name = "Completed" }); }


        }
    }
}
