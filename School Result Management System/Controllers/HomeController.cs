using Microsoft.AspNetCore.Mvc;
using SchoolResultManagementSystem.Models;
using SRMSRepositories.IRepositories;
using System.Diagnostics;

namespace SchoolResultManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

     

        public IActionResult Index()
        {
            return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}