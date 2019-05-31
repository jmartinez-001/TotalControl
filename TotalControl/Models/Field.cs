using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Field Subject")]
        public string Subject { get; set; }

        public string Entry { get; set; }

        public bool? NonApplicable { get; set; }
    }
}