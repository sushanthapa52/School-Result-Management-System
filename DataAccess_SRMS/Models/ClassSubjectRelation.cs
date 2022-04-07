using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSDataAccess.Models
{
    public class ClassSubjectRelation
    {
        public int CS_Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
    }
}
