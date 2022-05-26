using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class SVMwrapper
    {
        public List<StudentViewModel> Students
        {
            get; set;
        }

        public SVMwrapper()
        {
            Students = new List<StudentViewModel>();
        }
        public int PageCount { get; set; }

        public int CurrentPageIndex { get; set; }
       
    }
}
