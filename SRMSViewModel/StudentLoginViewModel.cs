using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class StudentLoginViewModel
    {

        [Required]
        public int StudentRollId { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int ExamId { get; set; }

        

        [Required]
        public int ExamYear { get; set; }


    }
}
