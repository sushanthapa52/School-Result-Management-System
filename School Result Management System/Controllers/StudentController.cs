using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;
using System.Collections.Generic;


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

            List<StudentViewModel> stdList = new List<StudentViewModel>();



            foreach(Student student in students)
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

        public IActionResult Edit(int id)
        {
            var classes = _classrepo.GetAllClasses();
            Student student = _studentrepo.GetStudentById(id);
            ViewBag.Classes = new SelectList(classes, "Id", "ClassName");

            ViewBag.Gender = new[] { "Male", "Female", "Others" };


           
       
            return View(student);

        }

     
    }
}
