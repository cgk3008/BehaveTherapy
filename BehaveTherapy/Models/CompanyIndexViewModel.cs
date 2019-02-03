using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class CompanyIndexViewModel
    {
        public Company Company { get; set; }
        public ApplicationUser CompanyAdmin { get; set; }
        //public User UserId { get; set; }
        public string UserId { get; set; }

    }
}