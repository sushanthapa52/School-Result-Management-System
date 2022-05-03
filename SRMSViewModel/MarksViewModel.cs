using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSViewModel
{
    public  class MarksViewModel
    {
       
        public Subject Subject{ get; set; }

        [Required(ErrorMessage ="Marks is required.")]
        public int Mark { get; set; }

       
    }
}
