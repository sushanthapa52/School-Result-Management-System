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
        private readonly IResultRepository _resultrepo;

        public MarkController(IClassRepository classrepo, ISubjectRepository subrepo, IResultRepository resultrepo, IMarkRepository markrepo)
        {
            _classrepo = classrepo;
            _subrepo = subrepo;
            _markrepo = markrepo;
            _resultrepo = resultrepo;

        }


        public async Task<IActionResult> AssignMarks(int id, int classid, int examid)
        {
            Result result = new Result()
            {
                ClassId = classid,
                ExamId = examid,
                StudentId = id
            };

            Result res = await _resultrepo.AddResultAsync(result);

            List<int> subjectIds = _classrepo.GetSubjectsByClassId(classid);
            List<Subject> subjects = new List<Subject>();
            MVMWrapper model = new MVMWrapper()
            {
                ResultId = res.Id
            };
            foreach (int sid in subjectIds)
            {

                model.mvmlist.Add(new MarksViewModel
                {
                    Subject = _subrepo.GetAllSubjects().FirstOrDefault(x => x.Id == sid),
                    Mark = 0

                });
            }


            return View(model);
        }


        [HttpPost]
        public IActionResult AssignMarks(MVMWrapper model)
        {
            if (ModelState.IsValid)
            {

                List<Mark> marks = new List<Mark>();
                foreach (MarksViewModel mvm in model.mvmlist)
                {
                    marks.Add(new Mark()
                    {
                        ResultId = model.ResultId,
                        SubjectId = mvm.Subject.Id,
                        Marks = mvm.Mark
                    });
                }
                _markrepo.AddMarks(marks);
            }


            return View(model);
        }
    }
}
