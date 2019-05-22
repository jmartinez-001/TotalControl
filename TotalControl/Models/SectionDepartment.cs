using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class SectionDepartment
    {
        [Key]
        public int Section { get; set; }   

        [Key]
        public int Department { get; set; }      

               
    }
}