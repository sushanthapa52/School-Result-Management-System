using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class StudentSideController: Controller
    {
        private readonly IStudentRepository _studentrepo;
        private readonly IClassRepository _classrepo;
        private readonly IResultRepository _resultrepo;
        private readonly IExamRepository _examrepo;

        public StudentSideController(IStudentRepository studentrepo,IClassRepository classrepo, IResultRepository resultrepo, IExamRepository examrepo)
        {
            _studentrepo=studentrepo;
            _classrepo = classrepo;
            _resultrepo = resultrepo;
            _examrepo = examrepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");
            return View( new StudentLoginViewModel());
        }
        [HttpPost]

        public IActionResult Index(StudentLoginViewModel studentLoginViewModel)
        {

            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            if (ModelState.IsValid)
            {


                var student = _studentrepo.CheckStudentClassRollNo(studentLoginViewModel.StudentRollId, studentLoginViewModel.ClassId);
                if (student != null)
                {


                    var result   = _resultrepo.GetResult(student.Id);
                    var exam= _examrepo.GetExamById(result.ExamId);
                    var examClass = _examrepo.GetExamClassById(result.ExamId);


                    ResultViewModel model  = new ResultViewModel()
                    {
                        student = student,
                        ClassName = _classrepo.GetClassById(student.ClassId).ClassName,
                        ExamName = exam.Name,
                        ExamYear= examClass.ExamYear
                       

                     };

                    return View("ResultView", model);
                }
                ModelState.AddModelError("", "Student not found.");

            }  
            return View(studentLoginViewModel);
        }


        }
    }

