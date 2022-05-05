using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class ResultController : Controller
    {
        private readonly IClassRepository _classrepo;
        private readonly IExamRepository _examrepo;
        private readonly IStudentRepository _sturepo;
        private readonly ISubjectRepository _subrepo;
        private readonly IResultRepository _resultrepo;

        public ResultController(IClassRepository classrepo, IExamRepository examrepo, IStudentRepository studentrepo,ISubjectRepository subrepo,IResultRepository resultrepo)
        {
            _classrepo = classrepo;
            _examrepo = examrepo;
            _sturepo = studentrepo; 
            _subrepo = subrepo;
            _resultrepo = resultrepo;   
        }


        public void DropdownMenu()
        {
            
            ViewBag.Exams = new SelectList(_examrepo.GetAllExams(), "Id", "Name");

      
            ViewBag.Class = new SelectList(_classrepo.GetAllClasses(), "Id", "ClassName");

        }

        public IActionResult Create()
        {


            DropdownMenu();

            return View();




        }

        [HttpPost]
        public IActionResult Create(ExamViewModel model)
        {

            DropdownMenu();


            List<ExamClassRelation> registeredExams = _examrepo.GetAllExamDetails().ToList();

            var Exam = registeredExams.Find(x => x.ExamId == model.Examid && x.ClassID == model.ClassID && x.ExamYear == model.ExamYear);
            TempData["ClassId"] = model.ClassID;
            TempData["ExamId"] = model.Examid;
            if (Exam != null)
                return RedirectToAction("StudentByclass");
            ModelState.AddModelError(" ", "The exam is not registered yet. please add the exam first");
            return View(model);




        }

        public ViewResult StudentByClass()
        {
            List<Student> students = _sturepo.GetAllStudents().Where(x => x.ClassId == Convert.ToInt32(TempData.Peek("ClassId"))).ToList();
            ResultWrapper rw = new ResultWrapper
            {
               StudentList=students,
               ClassId= Convert.ToInt32(TempData.Peek("ClassId")),
               ExamId= Convert.ToInt32(TempData["ExamId"])
            };
           
           
            return View(rw);
        }

        //public async Task<IActionResult> AddResults(int id,int classid, int examid)
        //{

        //Result result = new Result()
        //{
        //    ClassId = classid,
        //    ExamId = examid,
        //    StudentId = id
        //};

        //var model = await _resultrepo.AddResultAsync(result);



        //    return RedirectToAction("AssignMarks", "Mark"); ;


        //}


    }
}
