using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class SubjectViewModel
    {


        [Required(ErrorMessage = "Subject Name is required")]
        [Display(Name = "Subject")]
        public string SubjectName { get; set; } = null!;
    }
}
