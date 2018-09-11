using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class DashboardView_Model
    {
        public IEnumerable<TherapyPlan> Plans { get; set; }
        public IEnumerable<Exercises> Exercises { get; set; }
        public IEnumerable<PlanNotifications> PlanNotifications { get; set; }



    }
}