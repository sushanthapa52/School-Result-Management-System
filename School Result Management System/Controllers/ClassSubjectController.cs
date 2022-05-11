using Microsoft.AspNetCore.Mvc;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ClassSubjectController : Controller
    {
        private readonly ISubjectRepository _subrepo;
        private readonly IClassRepository _classrepo;

        public ClassSubjectController(ISubjectRepository subrepo,IClassRepository classrepo)
        {
            _subrepo = subrepo;
            _classrepo=classrepo;
        }
        public IActionResult Create(int id)
        {

            ClassSubjectViewModel model = new ClassSubjectViewModel()
            {
                SubjectIds = _classrepo.GetSubjectsByClassId(id),
                ClassSubjects = _subrepo.GetAllSubjects().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassSubjectViewModel model,int id)
        {
           

            if (ModelState.IsValid)
            {
             await  _classrepo.AddSubjectsToClassAsync(model.SubjectIds,id);

            }
            model.ClassSubjects = _subrepo.GetAllSubjects().ToList();
            return View(model);


        }
    }
}
