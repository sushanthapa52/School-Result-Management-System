using System.ComponentModel.DataAnnotations;

namespace SRMSViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [Display(Name ="Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}