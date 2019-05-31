using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        [ForeignKey("Section")]
        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }
    }
}