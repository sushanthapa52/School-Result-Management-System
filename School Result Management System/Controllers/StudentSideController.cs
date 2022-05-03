using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class StudentSideController: Controller
    {
        private readonly IStudentRepository _studentrepo;
        private readonly IClassRepository _classrepo;

        public StudentSideController(IStudentRepository studentrepo,IClassRepository classrepo)
        {
            _studentrepo=studentrepo;
            _classrepo = classrepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");
            return View( new StudentLoginViewModel());
        }
    }
}
