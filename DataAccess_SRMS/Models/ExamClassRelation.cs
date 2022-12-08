using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSDataAccess.Models
{
    public class ExamClassRelation
    {

        public int Id { get; set; }
        public int ExamId { get; set; }
        public int ClassID { get; set; }

        public bool ResultPublished { get; set; }

        public int ExamYear { get; set; }

    }
}
