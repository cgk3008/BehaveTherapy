using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class PlanAttachments
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public int UserId { get; set; }
        public string FileUrl { get; set; }

        public virtual Exercises Exercise { get; set; }
        public virtual ApplicationUser User { get; set; }



    }
}