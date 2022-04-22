using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;


namespace School_Result_Management_System.Controllers
{
    public class StudentController : Microsoft.AspNetCore.Mvc.Controller
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
            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = classes;
            ViewBag.Gender = new[] { "Male", "Female", "Unspecified" };
    
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = classes;
            ViewBag.Gender = new[] { "Male", "Female", "Unspecified" };

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
