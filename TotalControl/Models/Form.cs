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

        public Form()
        {
            Fields = new List<Field>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.Now;    
       
        [Display(Name = "Document Version")]
        public double Version { get; set; } = 1.0;

        [Display(Name = "Procedures")]
        [DataType(DataType.MultilineText)]
        public string Procedures { get; set; }

        [Display(Name = "Required Corrective Actions")]
        [DataType(DataType.MultilineText)]
        public string CorrectiveAction { get; set; }     
           
        public IList<Field> Fields { get; set; }            
        
    }
}