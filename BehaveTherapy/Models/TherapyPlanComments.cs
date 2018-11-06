using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class TherapyPlanComments
    {

        public int Id { get; set; }
        [StringLength(5000, ErrorMessage = "The {0} cannot be over {1} characters long.")]
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public string FileUrl { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TherapyPlan Ticket { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}