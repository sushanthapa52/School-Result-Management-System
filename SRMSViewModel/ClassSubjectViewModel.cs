using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class ClassSubjectViewModel
    {
       

       
        public List<int>? SubjectIds { get; set; }

        public List<Subject>? ClassSubjects { get; set; } 

    }
}
