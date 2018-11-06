using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanType
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<TherapyPlan> TherapyPlan { get; set; }
    }
}