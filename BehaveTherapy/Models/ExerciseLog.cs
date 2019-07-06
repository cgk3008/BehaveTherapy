using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class ExerciseLog
    {
        public int Id { get; set; }
        public DateTimeOffset ExerciseCompleteDate { get; set; }
        public int PlanId { get; set; }
        public int ExerciseId { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Exercises> Exercises { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<PlanHistory> PlanHistories { get; set; }

        public ExerciseLog()
        {
            
            Users = new HashSet<ApplicationUser>();
            Exercises = new HashSet<Exercises>();
            Plans = new HashSet<Plan>();
            PlanHistories = new HashSet<PlanHistory>();

        }

    }
}