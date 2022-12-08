using System;
using System.Collections.Generic;

namespace SRMSDataAccess.Models
{
    public partial class Class
    {
        public Class()
        {
            Results = new HashSet<Result>();
            Students = new HashSet<Student>();
         
        }

        public int Id { get; set; }
        public string? ClassName { get; set; }
       

        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Student> Students { get; set; }
      
    }
}
