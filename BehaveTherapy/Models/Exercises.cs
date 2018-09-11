using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class Exercises
    {

        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Title { get; set; }
        [StringLength(400, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string TimeZoneCreated { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? DeadlineDate { get; set; }


        public virtual TherapyPlan Plan { get; set; }



    }
}