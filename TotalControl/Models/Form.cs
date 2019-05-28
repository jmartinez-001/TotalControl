using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Conducted")]
        public DateTime DateConducted { get; set; }

        [Display(Name = "Prepared By")]
        public string PreparedBy { get; set; }

        [Display(Name = "Document Version")]
        public double Version { get; set; }

        [Display(Name = "Procedures")]
        [DataType(DataType.MultilineText)]
        public string Procedures { get; set; }

        [Display(Name = "Required Corrective Actions")]
        [DataType(DataType.MultilineText)]
        public string CorrectiveAction { get; set; }

        [Display(Name = "Corrective Actions Taken")]
        [DataType(DataType.MultilineText)]
        public string ActionsTaken { get; set; }

        [Display(Name = "Comments/ Observations")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<Field> Fields { get; set; }

        public string Signature { get; set; }

        
        
    }
}