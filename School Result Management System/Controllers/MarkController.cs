using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    [Authorize]
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
            Result result = _resultrepo.ResultExists(examid, id, classid);
            List<int> subjectIds = _classrepo.GetSubjectsByClassId(classid);

            if (result!=null)
            {
                int resultId = result.Id;
                List<Mark> marks = _markrepo.MarksList(resultId);
                MVMWrapper model = new MVMWrapper();

                if (marks.Count==0)
                {
                    foreach (int sid in subjectIds)
                    {

                        model.mvmlist.Add(new MarksViewModel
                        {
                            Subject = _subrepo.GetAllSubjects().FirstOrDefault(x => x.Id == sid),
                            Mark = 0

                        });
                    }
                    model.ResultId = resultId;
                    return View(model);
                }
                foreach (Mark mark in marks)
                {
                    model.mvmlist.Add(new MarksViewModel
                    {
                        Subject = _subrepo.GetAllSubjects().FirstOrDefault(x => x.Id == mark.SubjectId),
                        Mark = mark.Marks

                    });
                }
                return View(model);

            }

            else
            {
                Result res = await _resultrepo.AddResultAsync(new Result()
                {
                    ClassId = classid,
                    ExamId = examid,
                    StudentId = id
                });

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
