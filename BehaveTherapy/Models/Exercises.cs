﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class Exercises
    {

        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Title { get; set; }
        [StringLength(400, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Description { get; set; }
        //public int PlanId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string TimeZoneCreated { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        //How do I log multiple completion dates for one exercise? they will need to repeat several times a month......Do I make a save history helper for this to track changes to database?
        public DateTimeOffset? CompletionDate { get; set; }
        public DateTimeOffset? DeadlineDate { get; set; }
        public string AssignedToUserId { get; set; }
        public bool IsDeleted { get; set; }
        public string FileUrl { get; set; }


        //shit so code just below was preventing the join table of exercises and plans
        //public virtual Plan TherapistId { get; set; }
        //public virtual ApplicationUser AssignedToUser { get; set; }


        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<PlanHistory> Histories { get; set; }
        public virtual ICollection<PlanNotifications> PlanNotifications { get; set; }
        public virtual ICollection<ExerciseLog> Logs { get; set; }

        public Exercises()
        {
            Plans = new HashSet<Plan>();
            Histories = new HashSet<PlanHistory>();
            PlanNotifications = new HashSet<PlanNotifications>();
            Logs = new HashSet<ExerciseLog>();
        }



    }
}