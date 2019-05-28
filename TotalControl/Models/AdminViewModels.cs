using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class SectionViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Parent Section")]
        public string Parent { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Team")]
        public string Team { get; set; }


    }
}