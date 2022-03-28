using System;
using System.Collections.Generic;

namespace School_Result_Management_System.Models
{
    public partial class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ResultDate { get; set; }
        public string ResultPublished { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime AddedOn { get; set; }
        public int? ClassId { get; set; }
    }
}
