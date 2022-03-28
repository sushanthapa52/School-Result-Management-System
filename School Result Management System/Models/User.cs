using System;
using System.Collections.Generic;

namespace School_Result_Management_System.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserContactNo { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserProfile { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string UserStatus { get; set; } = null!;
        public DateTime UserCreatedOn { get; set; }
    }
}
