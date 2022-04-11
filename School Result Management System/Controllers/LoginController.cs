using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolResultManagementSystem.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;
using System.Security.Claims;

namespace School_Result_Management_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userrepo;
        public LoginController(IUserRepository userrepo)
        {
            _userrepo = userrepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new UserViewModel());
            }
            return RedirectToAction("Index", "Dashboard");

        }

        [HttpPost]
        public async  Task<IActionResult> Index(UserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = _userrepo.CheckUser(model.UserName, model.Password);

                if (user!=null)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));

                    var principle = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, principle,new AuthenticationProperties
                 {
                     IsPersistent = model.RememberMe
                 });

                    return RedirectToAction("Index", "Dashboard");
                }
               
                ModelState.AddModelError(" ", "invalid username and password");
                return View(model);

            }

            return View(model);


        }
    }
}
