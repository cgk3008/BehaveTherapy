using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class Plan
    {

        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
        public string TherapistId { get; set; }
        public bool IsDeleted { get; set; }
        public string AssignedToUserId { get; set; }
        public int? CompanyId { get; set; }
        public int? PlanTypeId { get; set; }
        public int? PlanPriorityId { get; set; }
        public int? PlanStatusId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ApplicationUser Therapist { get; set; }
        public virtual ApplicationUser AssignedToUser { get; set; }
        

        public virtual ICollection<Exercises> Exercises { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<PlanHistory> Histories { get; set; }
        public virtual ICollection<ExerciseLog> Logs { get; set; }

        public Plan()
        {
            Companies = new HashSet<Company>();
            Users = new HashSet<ApplicationUser>();
            Exercises = new HashSet<Exercises>();
            Histories = new HashSet<PlanHistory>();
            Logs = new HashSet<ExerciseLog>();

        }
    }
}