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
        public List<MarksViewModel> mvmList { get; set; }
        public ResultViewModel()
        {
            mvmList = new List<MarksViewModel>();
        }
        public string StudentName { get; set; }
        public int RollNo { get; set; }
        public ExamClassRelation Exam { get; set; }
        public string ExamName { get; set; }
        public int ExamYear { get; set; }
        public string ClassName { get; set; }
        public int ResultId { get; set; }
     





    }
}
