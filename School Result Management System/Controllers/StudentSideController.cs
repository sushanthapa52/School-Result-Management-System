using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class StudentSideController : Controller
    {
        private readonly IStudentRepository _studentrepo;
        private readonly IClassRepository _classrepo;
        private readonly IResultRepository _resultrepo;
        private readonly IExamRepository _examrepo;
        private readonly IMarkRepository _markrepo;

        private readonly ISubjectRepository _subrepo;

        public StudentSideController(IStudentRepository studentrepo, IClassRepository classrepo, IResultRepository resultrepo, IExamRepository examrepo, IMarkRepository markrepo, ISubjectRepository subrepo)
        {
            _studentrepo = studentrepo;
            _classrepo = classrepo;
            _resultrepo = resultrepo;
            _examrepo = examrepo;
            _markrepo = markrepo;
            _subrepo = subrepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            ViewBag.Classes = new SelectList(_classrepo.GetAllClasses(), "Id", "ClassName");
            ViewBag.Exams = new SelectList(_examrepo.GetAllExams(), "Id", "Name");
            return View(new StudentLoginViewModel());
        }


        [HttpPost]
        public IActionResult Index(StudentLoginViewModel model)
        {


            ViewBag.Classes = new SelectList(_classrepo.GetAllClasses(), "Id", "ClassName");
            ViewBag.Exams = new SelectList(_examrepo.GetAllExams(), "Id", "Name");
            if (ModelState.IsValid)
            {
                Student student = _studentrepo.CheckStudentClassRollNo(model.StudentRollId, model.ClassId, model.StudentDob);
                if (student != null)
                {

                    ExamClassRelation exam = _examrepo.GetExamByClass(model.ExamId, model.ClassId, model.ExamYear);
                    Result result = _resultrepo.ResultExists(exam.Id, student.Id, model.ClassId);

                 
                    if (result != null)
                    {
                        ResultViewModel resultViewModel = new ResultViewModel()
                        {
                            
                            ExamName = _examrepo.GetExamById(model.ExamId).Name,
                            ExamYear=model.ExamYear,
                            ClassName = _classrepo.GetClassById(model.ClassId).ClassName,
                            ResultId = result.Id,
                           StudentName=student.StudentName,
                           RollNo=student.StudentRollNo

                        };
                        
                        return RedirectToAction("ShowResults", resultViewModel );

                    }

                    ModelState.AddModelError("", "Result not found.");
                    return View(model);
                }
                ModelState.AddModelError("", "Student not found.");
                return View(model);
            }
            return View(model);
        }

        public IActionResult ShowResults(ResultViewModel model)
        {
            List<Mark> marks = _markrepo.GetMarksList(model.ResultId);
            int totalMarksObtained=0, count=0;
            
            int FullMark = model.ExamName.Contains("Unit Test") ? 20 : 100;
            ViewData["FullMark"] = FullMark;
            int PassMark = model.ExamName.Contains("Unit Test") ? 8 : 40;
            ViewData["PassMark"] = PassMark;
            string result = "Pass";
            foreach (Mark mark in marks)
            {
                model.mvmList.Add(new MarksViewModel
                {
                    Subject = _subrepo.GetAllSubjects().FirstOrDefault(x => x.Id == mark.SubjectId),
                    Mark = mark.Marks

                });
                if (mark.Marks < PassMark)
                {
                  result = "Fail";
                }
                totalMarksObtained = totalMarksObtained + mark.Marks;
                count += 1;
            };
         
           
            ViewData["TotalMarksObtained"] = totalMarksObtained;
            ViewData["TotalMarks"] = FullMark * count;
            double percentage= System.Math.Round((float)totalMarksObtained / (FullMark * count) * 100, 2); 
            ViewData["Percentage"] = percentage;
            ViewData["Remarks"] = result;
            return View(model);
        }
    }
}

