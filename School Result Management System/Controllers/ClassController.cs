using Microsoft.AspNetCore.Mvc;

namespace School_Result_Management_System.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
