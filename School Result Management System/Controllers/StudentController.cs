using Microsoft.AspNetCore.Mvc;

namespace School_Result_Management_System.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
