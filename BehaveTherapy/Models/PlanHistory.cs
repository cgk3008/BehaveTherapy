using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanHistory
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTimeOffset Changed { get; set; }
        public string UserId { get; set; }


        public virtual Exercises Exercise { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}