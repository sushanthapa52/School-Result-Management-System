using System;
using System.Collections.Generic;

namespace SRMSDataAccess.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public string SubjectName { get; set; } = null!;
        public string SubjectStatus { get; set; } = null!;
        public DateTime SubjectCreatedOn { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
