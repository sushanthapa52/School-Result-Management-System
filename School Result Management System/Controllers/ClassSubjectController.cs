using Microsoft.AspNetCore.Mvc;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class ClassSubjectController : Controller
    {
        private readonly ISubjectRepository _subrepo;
        private readonly IClassRepository _classrepo;

        public ClassSubjectController(ISubjectRepository subrepo,IClassRepository classrepo)
        {
            _subrepo = subrepo;
            _classrepo=classrepo;
        }
        public IActionResult Create()
        {

            ClassSubjectViewModel model = new ClassSubjectViewModel()
            {
                Classes = _classrepo.GetAllClasses().ToList(),
                ClassSubjects = _subrepo.GetAllSubjects().ToList()
            };
            return View(model);
        }
    }
}
