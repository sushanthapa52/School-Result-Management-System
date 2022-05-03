using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;

namespace School_Result_Management_System.Controllers
{
    public class ResultController : Controller
    {
        private readonly IClassRepository _classrepo;
        private readonly IExamRepository _examrepo;

        public ResultController(IClassRepository classrepo, IExamRepository examrepo)
        {
            _classrepo = classrepo;
            _examrepo = examrepo;
        }

       
        public IActionResult Create()
        {
            var exam = _examrepo.GetAllExams();
            IEnumerable<ExamClassRelation> examsList = _examrepo.GetAllExamDetails();
            List<Exam> examList = new List<Exam>();

            foreach (ExamClassRelation examClassRelation in examsList)
             {
                foreach (var examItem in exam)

                {
                    if (examClassRelation.ExamId == examItem.Id)
                    {

                        var data= _examrepo.GetExamById(examClassRelation.ExamId);
                        examList.Add(data);

                    }
                }
            }
            
            ViewBag.Exams = new SelectList(examList, "Id", "Name");

            IEnumerable<Class> classList = _classrepo.GetAllClasses();
            ViewBag.Class = new SelectList(classList, "Id", "ClassName");
            return View();
        }
    }
}
