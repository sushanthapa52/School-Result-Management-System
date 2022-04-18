using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public class ClassViewModel
    {

        [Required(ErrorMessage = "Class Name is required")]
        [Display(Name = "Class")]
        public string ClassName { get; set; } = null!;
    }
}
