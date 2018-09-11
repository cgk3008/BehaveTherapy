﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BehaveTherapy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<TherapyPlan> TherapyPlan {get; set;}
        public virtual ICollection<Exercises> Exercises { get; set; }
        public virtual ICollection<PlanNotifications> PlanNotifications { get; set; }

        public ApplicationUser()
        {
            TherapyPlan = new HashSet<TherapyPlan>();
            Exercises = new HashSet<Exercises>();
            PlanNotifications = new HashSet<PlanNotifications>();
        }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            userIdentity.AddClaim(new Claim("Name", FullName));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

public DbSet<TherapyPlan> TherapPlan { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<PlanNotifications> PlanNotifications { get; set; }

    }
}