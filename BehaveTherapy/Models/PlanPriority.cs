using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanPriority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Plan> Plan { get; set; }
    }
}