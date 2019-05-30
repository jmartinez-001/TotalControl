using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Parent")]
        [Display(Name = "Parent Section")]
        public int? ParentId { get; set; }

        public virtual Section Parent { get; set; }

        public string Type { get; set; }

        [Display(Name = "Section Name")]
        public string Name { get; set; }

        public virtual ICollection<Section> Children { get; set; }

        [ForeignKey("Team")]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

    }
}