using System.Collections.Generic;
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

        //public virtual ICollection<TherapyPlan> TherapyPlan {get; set;}
        // comment out to just have one user per company   public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Plan> Plan { get; set; }
        public virtual ICollection<Exercises> Exercises { get; set; }
        public virtual ICollection<PlanNotifications> PlanNotifications { get; set; }
        public virtual ICollection<PlanComments> Comment { get; set; }
        public virtual ICollection<PlanAttachments> Attachment { get; set; }
        public virtual ICollection<PlanHistory> History { get; set; }
        public virtual ICollection<ExerciseLog> ExerciseLogs { get; set;}

        public ApplicationUser()
        {
            //TherapyPlan = new HashSet<TherapyPlan>();
            // comment out so only one user per company      Company = new HashSet<Company>();
            Plan = new HashSet<Plan>();
            Exercises = new HashSet<Exercises>();
            PlanNotifications = new HashSet<PlanNotifications>();
            Comment = new HashSet<PlanComments>();
            Attachment = new HashSet<PlanAttachments>();
            History = new HashSet<PlanHistory>();
            ExerciseLogs = new HashSet<ExerciseLog>();
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

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<PlanNotifications> PlanNotifications { get; set; }
        public DbSet<PlanComments> PlanComments { get; set; }
        public DbSet<PlanAttachments> PlanAttachments { get; set; }
        public DbSet<PlanHistory> PlanHistories { get; set; }
        public DbSet<PlanPriority> PlanPriorities { get; set; }
        public DbSet<PlanStatus> PlanStatus { get; set; }
        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ExerciseLog> ExerciseLogs { get; set; }

     

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }

        



    }


    //public class TherapyDbContext : DbContext
    //{
    //    public TherapyDbContext() : base("TherapyDb-DataAnnotations")
    //    {
    //    }

    //    public DbSet<Plan> Plans { get; set; }
    //    public DbSet<Exercises> Exercises { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //    }

    //}

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{

    //    modelBuilder.Entity<Plan>()
    //                .HasMany<Exercises>(s => s.Exercises)
    //                .WithMany(c => c.Plans)
    //                .Map(cs =>
    //                {
    //                    cs.MapLeftKey("PlanRefId");
    //                    cs.MapRightKey("ExerciseRefId");
    //                    cs.ToTable("PlanExercise");
    //                });

    //}



}