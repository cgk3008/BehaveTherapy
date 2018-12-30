using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanIndexViewModel
    {
        public TherapyPlan Plan { get; set; }
        public ApplicationUser Therapist { get; set; }
        public ApplicationUser AssignedToUser { get; set; }
        //public User UserId { get; set; }
        public string UserId { get; set; }
    }
}