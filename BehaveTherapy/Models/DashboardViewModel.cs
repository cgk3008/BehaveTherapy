using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<Plan> Plans { get; set; }
        public IEnumerable<Exercises> Exercises { get; set; }
        public IEnumerable<PlanNotifications> PlanNotifications { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public ApplicationUser User { get; set; }



    }
}