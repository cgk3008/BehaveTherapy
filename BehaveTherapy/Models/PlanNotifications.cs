using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanNotifications
    {
        public int Id { get; set; }
        public int TherapyPlanId { get; set; }
        public int UserId { get; set; }

        public virtual Plan Plan{ get; set; }
        public virtual Exercises Exericess { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}