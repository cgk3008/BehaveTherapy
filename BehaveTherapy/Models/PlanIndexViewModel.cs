using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanIndexViewModel
    {


        // I DON'T THINK I AM USING THIS MODEL ANYWHERE, CONFIRM AND DELETE

        
        //public Plan Plan { get; set; }
        public ApplicationUser Therapist { get; set; }
        public ApplicationUser AssignedToUser { get; set; }
        //public User UserId { get; set; }
        public string UserId { get; set; }

        public virtual Plan Plan { get; set; }
    }
}