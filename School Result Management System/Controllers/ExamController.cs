using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class ExamController :Controller
    {
        private readonly IClassRepository _classrepo;
        private readonly IExamRepository _examrepo;

        public ExamController(IClassRepository classrepo,IExamRepository examrepo)
        {
            _classrepo = classrepo;
            _examrepo = examrepo;

        }
        public IActionResult Index()
        {
            var exams= _examrepo.GetAllExams();

            List<ExamViewModel> listOfExams= new List<ExamViewModel>();

            foreach(Exam exam in exams)
            {
                listOfExams.Add(new ExamViewModel
                {
                    ExamName = exam.Name,
                    ResultPublished = exam.ResultPublished,
                    ClassName = _classrepo.GetClassById(exam.ClassId).ClassName
                });
                
            }
            return View(listOfExams);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            //List<String> examtypes = new List<string>{
            //    "First Unit Test",
            //    "First Term",
            //    "Second Unit Test",
            //    "Second Term",
            //    "Third Unit Test",
            //    "Third Term",
            //    "Fourth Unit Test",
            //    "Final Term"
            //};
            //ViewBag.ExamType = new SelectList(examtypes);


            var classes= _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExamViewModel examViewModel)
        {

            if (ModelState.IsValid)
            {
                Exam exam = new Exam()
                {
                    Name = examViewModel.ExamName,
                    ClassId = examViewModel.ClassId,
                    ExamYear = examViewModel.ExamYear.Value,
                };

                await _examrepo.AddExamAsync(exam);

                return RedirectToAction("Index");

            }
             
            
            return View(examViewModel);



        }

    }
}
