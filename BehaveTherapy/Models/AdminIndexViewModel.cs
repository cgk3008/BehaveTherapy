using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class AdminIndexViewModel
    {
        public ApplicationUser User { get; set; }
        public ICollection<string> Roles { get; set; }
        public TherapyPlan TherapyPlan { get; set; }
        public ICollection<string> Users { get; set; }

    }
}