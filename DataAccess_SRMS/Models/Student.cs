﻿using System;
using System.Collections.Generic;

namespace SRMSDataAccess.Models
{
    public partial class Student
    {
        public Student()
        {
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public string StudentName { get; set; } = null!;
        public int StudentRollNo { get; set; } 
        public string StudentEmailId { get; set; } = null!;
        public string StudentGender { get; set; } = null!; 
        public DateTime StudentDob { get; set; }


        public virtual Class Class { get; set; } = null!;
        public virtual ICollection<Result> Results { get; set; }
    }
}
