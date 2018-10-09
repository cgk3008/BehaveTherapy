using BehaveTherapy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Models
{
    public class AdminModel
    {
        //[Key]
        //public int Id { get; set; }
      
        public ApplicationUser User { get; set; }
        //public List<string> Roles { get; set; }
        public MultiSelectList Roles { get; set; }
        public string[] SelectedRoles { get; set; }

    }


    //public ActionResult
}

