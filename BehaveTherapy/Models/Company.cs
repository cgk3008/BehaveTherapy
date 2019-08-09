using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models
{
    public class Company
    {

        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string CompanyName { get; set; }
        [StringLength(200, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Address { get; set; }
        [StringLength(50, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string City { get; set; }
        [StringLength(20, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string State { get; set; }
        [StringLength(10, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string ZipCode { get; set; }
        [StringLength(50, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Phone { get; set; }
        [StringLength(50, ErrorMessage = "The {0} cannot be {1} characters long.")]
        public string Fax { get; set; }


        public bool IsDeleted { get; set; }


        //did I do below code correctly?  Want to link Users for these roles.  I DON"T THINK I NEED THESE, JUST USING ROLE MANAGER AND THEN COMPANY ID!
        ////public virtual ApplicationUser CompanyAdmin { get; set; }
        ////public virtual ApplicationUser Therapist { get; set; }
        ////public virtual ApplicationUser Client { get; set; }

        //public virtual RegisterViewModel Register { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }

        //public ICollection<string> Roles { get; set; }

        public Company()
        {

            Users = new HashSet<ApplicationUser>();
            Plans = new HashSet<Plan>();

        }

    }
}