using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Team Name")]
        public string Name { get; set; }

    }
}