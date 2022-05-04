using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class ResultViewModel
    {
        public Student student { get; set; }
        public string ExamName  { get; set; }
        public int ExamYear { get; set; }

        public string ClassName { get; set; }
        public string StudentName { get; set; }

        public string StudentRollNo { get; set; }



    }
}
