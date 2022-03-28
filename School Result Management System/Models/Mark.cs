using System;
using System.Collections.Generic;

namespace School_Result_Management_System.Models
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int ResultId { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }

        public virtual Result Result { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
