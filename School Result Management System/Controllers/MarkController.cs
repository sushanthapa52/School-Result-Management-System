using Microsoft.AspNetCore.Mvc;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class MarkController : Controller
    {
        private readonly IClassRepository _classrepo;
        private readonly ISubjectRepository _subrepo;
        private readonly IMarkRepository _markrepo;

        public MarkController(IClassRepository classrepo,ISubjectRepository subrepo,IMarkRepository markrepo)
        {
            _classrepo = classrepo;
            _subrepo = subrepo;
            _markrepo = markrepo;

        }


        public IActionResult AssignMarks()
        {
            List<int> subjectIds = _classrepo.GetSubjectsByClassId(Convert.ToInt32(TempData["ClassId"]));
            List<Subject> subjects = new List<Subject>();
            List<MarksViewModel> model = new List<MarksViewModel>();
            foreach (int sid in subjectIds)
            {
                //subjects.Add();
                model.Add(new MarksViewModel
                {
                    Subject = _subrepo.GetAllSubjects().FirstOrDefault(x => x.Id == sid),
                    Mark = 0

                });
            }


            return View(model);
        }


        [HttpPost]
        public IActionResult AssignMarks(List<MarksViewModel> model)
        {
            if (ModelState.IsValid)
            {
               
                List<Mark> marks = new List<Mark>();
                foreach (MarksViewModel mvm in model)
                {
                    marks.Add(new Mark()
                    {
                        ResultId = Convert.ToInt32(TempData.Peek("ResultId")),
                        SubjectId = mvm.Subject.Id,
                        Marks = mvm.Mark
                    });
                }
                _markrepo.AddMarksAsync(marks);
            }
           

          return View(model);
        }
    }
}
