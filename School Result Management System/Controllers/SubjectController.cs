using Microsoft.AspNetCore.Mvc;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSServices.IServices;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class SubjectController : Controller
    {
        private ISubjectRepository _subjectrepo;
        public SubjectController(ISubjectRepository subjectrepo)
        {
            _subjectrepo = subjectrepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new SubjectViewModel());
        }

        [HttpPost]
        public IActionResult Create(SubjectViewModel model)
        {
            Subject subject = new Subject()
            {
                SubjectName = model.SubjectName
            };


            if (ModelState.IsValid)
            {
                _subjectrepo.AddSubjectAsync(subject);
                return View(new SubjectViewModel());
              
            }
            return View(model);
            
        }
    }
}
