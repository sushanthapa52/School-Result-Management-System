using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SRMSRepositories.IRepositories;
using System.Diagnostics;

namespace SchoolResultManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IResultRepository _resultrepo;
        private readonly IStudentRepository _sturepo;
        private readonly ISubjectRepository _subrepo;
        private readonly IClassRepository _classrepo;

        public HomeController(IResultRepository resultrepo,IStudentRepository sturepo,ISubjectRepository subrepo,IClassRepository classrepo)
        {

            _resultrepo = resultrepo;
            _sturepo = sturepo;
            _subrepo = subrepo;
            _classrepo = classrepo;

        }

        public IActionResult Index()
        {
            ViewData["TotalStudents"] = _sturepo.GetAllStudents().Count();

            ViewData["TotalSubjects"] = _subrepo.GetAllSubjects().Count();
            ViewData["TotalClasses"] = _classrepo.GetAllClasses().Count();
            ViewData["TotalResults"] = _resultrepo.GetAllResults().Count();
            return View();
        }

      
     [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View("Error");
        }
    }
}