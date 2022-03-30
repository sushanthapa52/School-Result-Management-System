using Microsoft.AspNetCore.Mvc;
using SchoolResultManagementSystem.Models;
using SRMSServices.IServices;

namespace SchoolResultManagementSystem.Controllers
{
    public class TestController : Controller
    {

        //IStudentService _studentService;
        //public TestController(IStudentService studentService)
        //{
        //    _studentService = studentService;

        //}
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TestViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm]TestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Result = model.Number1 + model.Number2;
            return View(model);
        }
    }
}
