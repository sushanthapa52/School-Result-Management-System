using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
public class ClassSubjectViewModel
    {
        public string? ClassName { get; set; }

        public List<Subject>? subjects { get; set; } 
    }
}
