using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Mvc;

namespace SRMSViewModel
{
    public class StudentViewModel
    {

        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; } = null!;
        
        [Required(ErrorMessage = "Student Roll Number is required")]

        public string StudentRollNo { get; set; } = null!;


        [Required(ErrorMessage = "Student Email ID is required")]

        public string StudentEmailId { get; set; } = null!;

        [Required(ErrorMessage = "Student Gender is required")]

        public string StudentGender { get; set; } = null!;
        [Required(ErrorMessage = "Student Date of birth is required")]

        public DateTime StudentDob { get; set; }

        [Required(ErrorMessage = "Student Class is required")]

        public IEnumerable<SelectListItem>?  Classes { get; set; } 

        [Required(ErrorMessage = " Classid is required")]
        public int? ClassId { get; set; } 

    }
}
