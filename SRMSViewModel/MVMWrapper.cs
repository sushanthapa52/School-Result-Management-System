using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class MVMWrapper
    {
        public List<MarksViewModel> mvmlist { get; set; }
        public MVMWrapper()
        {
            mvmlist = new List<MarksViewModel>();
        }
        public int ResultId { get; set; }

    }
}
