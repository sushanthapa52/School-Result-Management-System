using Microsoft.AspNetCore.Mvc;
using SchoolResultManagementSystem.Models;
using SRMSRepositories.IRepositories;
using SRMSRepositories.Repositories;
using SRMSServices.IServices;

namespace SchoolResultManagementSystem.Controllers
{
    public class TestController : Controller
    {

        //IStudentService _studentService;
        public TestController()
        {
            // _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TestViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] TestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // var result = await _Calc.Sum(model.Number1, model.Number2);
            
            model.Result = model.Number1+model.Number2;
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserViewModel());
        }
    }
}
