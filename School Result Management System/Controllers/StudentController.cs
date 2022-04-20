using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentrepo;
        private readonly IClassRepository _classrepo;

        public StudentController(IStudentRepository studentrepo, IClassRepository classrepo)
        {
            _studentrepo = studentrepo;
            _classrepo = classrepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students= _studentrepo.GetAllStudents();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var studentViewModel = new StudentViewModel()

            {

                //Classes =_classrepo.GetAllClasses().ToList().Select(x =>
                //                    new SelectListItem
                //                    {
                //                        Value = x.Id.ToString(),
                //                        Text = x.ClassName
                //                    })
            };
            return View(studentViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student Std = new Student()
                {  
                    ClassId= model.ClassId,
                    StudentName = model.StudentName,
                    StudentRollNo= model.StudentRollNo,
                    StudentDob =model.StudentDob,
                    StudentEmailId=model.StudentEmailId,
                    StudentGender=model.StudentGender,
                };
                await _studentrepo.AddStudentsAsync(Std);
                return RedirectToAction("Index");


            }

            return View(model);

        }
    }
}
