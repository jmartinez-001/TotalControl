using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Date Conducted")]
        public DateTime? DateConducted { get; set; }

        [Display(Name = "Prepared By")]
        public string PreparedBy { get; set; }

        [Display(Name = "Corrective Actions Taken")]
        [DataType(DataType.MultilineText)]
        public string ActionsTaken { get; set; }

        [Display(Name = "Comments/ Observations")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public byte[] Photo { get; set; }

        public string Signature { get; set; }

        [ForeignKey("Form")]
        public int FormId { get; set; }

        public virtual Form Form { get; set; }


    }
}