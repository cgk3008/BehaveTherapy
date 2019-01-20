using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BehaveTherapy.Models
{
    public class AdminCompany
    {

        public virtual Company Company { get; set; }

        public MultiSelectList Users { get; set; }
        public string[] SelectedUsers { get; set; }
        public ApplicationUser RmvUser { get; set; }
    }
}