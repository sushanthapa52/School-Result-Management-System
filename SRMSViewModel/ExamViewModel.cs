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
        [Required]
        public int Examid { get; set; }
        [Required]

        public int ClassID { get; set; }
        [Required]

        public int ExamYear { get; set; }
        [Required]

        public bool ResultPublished { get; set; }
    }
}
