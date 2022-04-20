using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;

using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private ISubjectRepository _subjectrepo;
        public SubjectController(ISubjectRepository subjectrepo)
        {
            _subjectrepo = subjectrepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Subject> subjects = _subjectrepo.GetAllSubjects();

            return View(subjects);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new SubjectViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_subjectrepo.SubjectExists(model.SubjectName))
                {
                    ModelState.AddModelError(string.Empty, "Subject with the given subjectname already exists.");
                    return View(model);
                }

                Subject subject = new Subject()
                {
                    SubjectName = model.SubjectName
                };
                await _subjectrepo.AddSubjectAsync(subject);
                return RedirectToAction("Index");

            }


            return View(model);


        }

        public ViewResult Edit(int id)
        {
           Subject subject =  _subjectrepo.GetSubjectById(id);
            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectrepo.UpdateSubject(subject);
                return Redirect("/Subject");
             

            }
            return View(subject);
           

        }



        public IActionResult Delete(int id)
        {

            _subjectrepo.RemoveSubject(id);
            return Redirect("/Subject");

        }
    }
}
