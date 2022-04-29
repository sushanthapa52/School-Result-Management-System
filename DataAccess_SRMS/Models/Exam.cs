using System;
using System.Collections.Generic;

namespace SRMSDataAccess.Models
{
    public partial class Exam
    {
        public int Id { get; set; }
        public int ExamYear { get; set; }
        public string Name { get; set; } = null!;
        public bool ResultPublished { get; set; }
        public int ClassId { get; set; }
    }
}
