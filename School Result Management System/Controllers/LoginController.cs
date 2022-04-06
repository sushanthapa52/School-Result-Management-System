using Microsoft.AspNetCore.Mvc;
using SchoolResultManagementSystem.Models;
using SRMSServices.IServices;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService; 
        }
        public IActionResult Index()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult Index(UserViewModel model)
        {
            if (!model.UserName.Contains('@'))
            {
                ModelState.AddModelError("Email", "Invalid Email Format");
                return View(model);

            }

         

            if (ModelState.IsValid)
            {
                var user = _userService.SignInValidation(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "invalid username and password");
                    return View(model);
                }
                //user identity task remaining.
                return RedirectToAction("Index", "Dashboard");

            }

            return View(model);
        

        }
    }
}
