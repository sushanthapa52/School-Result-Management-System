using System;
using System.Collections.Generic;

namespace SRMSDataAccess.Models
{
    public partial class Result
    {
        public Result()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public decimal ResultPercentage { get; set; }
        public string ResultStatus { get; set; } = null!;
        public string ResultAddedBy { get; set; } = null!;

        public virtual Class Class { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
