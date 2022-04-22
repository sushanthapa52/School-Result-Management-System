
using System.ComponentModel.DataAnnotations;

//using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;

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
        [DataType(DataType.Date)]
        public DateTime StudentDob { get; set; }

       

        [Required(ErrorMessage = "ClassName is required")]
        public int? ClassId { get; set; } 

    }
}
