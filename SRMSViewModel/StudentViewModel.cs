
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRMSViewModel
{
    public class StudentViewModel
    {
        [StringLength(100)]

        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; } = null!;
        
        [Required(ErrorMessage = "Student Roll Number is required")]

        public string StudentRollNo { get; set; } = null!;


        [Required(ErrorMessage = "Student Email ID is required")]
        //[ValidEmailAddress]
        [StringLength(50)]

        public string StudentEmailId { get; set; } = null!;

        [Required(ErrorMessage = "Student Gender is required")]

        public string StudentGender { get; set; } = null!;


        [Required(ErrorMessage = "Student Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime? StudentDob { get; set; }

      
        public int ClassId { get; set; }

        public string? classname { get; set; }

        public int StudentId { get; set; }  
    }
}
