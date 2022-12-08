using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
   public class ResultWrapper
    {

        public List<Student> StudentList { get; set; }
        public int ClassId { get; set; }
        
        public int ExamId { get; set; }
    }
}
