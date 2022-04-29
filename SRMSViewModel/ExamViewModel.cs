using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public  class ExamViewModel
    {
 

        [Required(ErrorMessage = "Exam Year is required")]
        public int? ExamYear { get; set; } = null!;

        [Required(ErrorMessage = "Exam Name is required")]

        public string ExamName { get; set; } = null!;


        public int Examid { get; set; }
        public bool ResultPublished { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }

    }
}
