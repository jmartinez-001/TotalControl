using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalControl.Models
{
    public class ValueStream
    {
        public int Id { get; set; }

        public virtual Employee Coordinator { get; set; } 

        public virtual ICollection<Area> Areas { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
    }
}