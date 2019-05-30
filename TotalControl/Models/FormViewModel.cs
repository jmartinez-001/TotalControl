using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class FormViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Procedures")]
        [DataType(DataType.MultilineText)]
        public string Procedures { get; set; }

        [Display(Name = "Required Corrective Actions")]
        [DataType(DataType.MultilineText)]
        public string CorrectiveAction { get; set; }

    }
}