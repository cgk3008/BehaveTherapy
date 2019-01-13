using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<Plan> Plan { get; set; }
    }
}