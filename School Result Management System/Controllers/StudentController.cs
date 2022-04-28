using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;
using System.Collections.Generic;


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
            IEnumerable<Student> students = _studentrepo.GetAllStudents();

            List<StudentViewModel> stdList = new List<StudentViewModel>();



            foreach (Student student in students)
            {
                stdList.Add(new StudentViewModel
                {
                    StudentId = student.Id,
                    StudentName = student.StudentName,
                    StudentRollNo = student.StudentRollNo,
                    classname = _classrepo.GetClassById(student.ClassId).ClassName

                });

            }

            return View(stdList);
        }
        [HttpGet]
        public IActionResult Create()
        {


            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            ViewBag.Gender = new[] { "Male", "Female", "Others" };
            return View();




        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {

           var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            ViewBag.Gender = new[] { "Male", "Female", "Others" };

            if (ModelState.IsValid)
            {



                Student Std = new Student()
                {
                    ClassId = model.ClassId,
                    StudentName = model.StudentName,
                    StudentRollNo = model.StudentRollNo,
                    StudentDob = model.StudentDob,
                    StudentEmailId = model.StudentEmailId,
                    StudentGender = model.StudentGender,
                };

                if (_studentrepo.RollIdAlreadyExists(Std.StudentRollNo));
                {
                    ModelState.AddModelError(string.Empty, "Roll number already exists.");

                    return View(model);

                }


                if (_studentrepo.EmailAlreadyExists(Std.StudentEmailId))
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");

                    return View(model);

                }
                await _studentrepo.AddStudentsAsync(Std);
                return RedirectToAction("Index");




            }

            return View(model);

        }

        public IActionResult Edit(int id)
        {
            var classes = _classrepo.GetAllClasses();
            Student student = _studentrepo.GetStudentById(id);
            StudentViewModel model = new StudentViewModel()
            {
                StudentId = student.Id,
                StudentName = student.StudentName,
                StudentRollNo = student.StudentRollNo,
                StudentDob = student.StudentDob,
                StudentEmailId = student.StudentEmailId,
                StudentGender = student.StudentGender,
                ClassId = student.ClassId,


            };
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            ViewBag.Gender = new[] { "Male", "Female", "Others" };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {

            var classes = _classrepo.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            ViewBag.Gender = new[] { "Male", "Female", "Others" };
            if (ModelState.IsValid)

            {

                Student student = new Student
                { 
                   
                    Id=model.StudentId,
                    ClassId=model.ClassId,
                    StudentGender = model.StudentGender,
                    StudentEmailId= model.StudentEmailId,
                    StudentDob=model.StudentDob,
                    StudentName=model.StudentName,
                    StudentRollNo=model.StudentRollNo
                    
                };
               await _studentrepo.UpdateStudentAsync(student);
                
                Redirect("/Student/Index");

            }
            return View(model);

        }
        public IActionResult Delete(int id)
        {
            _studentrepo.RemoveStudent(id);
             return RedirectToAction("Index");
        }
    }
}
