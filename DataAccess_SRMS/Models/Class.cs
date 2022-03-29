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
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
