using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;


namespace School_Result_Management_System.Controllers
{
    [Authorize]
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
            return View(this.GetStudents(1,""));
        }
        [HttpPost]
        public IActionResult Index(int currentPageIndex, string searchString)
        {
            return View(this.GetStudents(currentPageIndex,searchString));
        }

        private SVMwrapper GetStudents(int currentPage, string searchString)
        {
            int maxRows = 4;


            if (!String.IsNullOrEmpty(searchString))
            {
                List<Student> StudentLists = _studentrepo.FilterStudentByName(searchString)
                     .OrderBy(Student => Student.StudentName)
                     .Skip((currentPage - 1) * maxRows)
                     .Take(maxRows).ToList();


                SVMwrapper modell = new SVMwrapper();
                foreach (Student student in StudentLists)
                {

                    modell.Students.Add(new StudentViewModel
                    {
                        StudentId = student.Id,
                        StudentName = student.StudentName,
                        StudentRollNo = student.StudentRollNo,
                        classname = _classrepo.GetClassById(student.ClassId).ClassName

                    });

                }

                double pageCounts = (double)((decimal)_studentrepo.FilterStudentByName(searchString).Count() / Convert.ToDecimal(maxRows));
                modell.PageCount = (int)Math.Ceiling(pageCounts);

                modell.CurrentPageIndex = currentPage;

                return modell;
            }

            List<Student> StudentList = _studentrepo.GetAllStudents()
                         .OrderBy(Student => Student.StudentName)
                         .Skip((currentPage - 1) * maxRows)
                         .Take(maxRows).ToList();


            SVMwrapper model = new SVMwrapper();
            foreach (Student student in StudentList)
            {

                model.Students.Add(new StudentViewModel
                {
                    StudentId = student.Id,
                    StudentName = student.StudentName,
                    StudentRollNo = student.StudentRollNo,
                    classname = _classrepo.GetClassById(student.ClassId).ClassName

                });

            }

            double pageCount = (double)((decimal)_studentrepo.GetAllStudents().Count() / Convert.ToDecimal(maxRows));
            model.PageCount = (int)Math.Ceiling(pageCount);

            model.CurrentPageIndex = currentPage;

            return model;
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
                    StudentDob = model.StudentDob.Value,
                    StudentEmailId = model.StudentEmailId,
                    StudentGender = model.StudentGender,
                };

                if (_studentrepo.RollIdAlreadyExists(Std.StudentRollNo, Std.ClassId))
                {
                    ModelState.AddModelError(string.Empty, "Roll number already exists in the class.");

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

                    Id = model.StudentId,
                    ClassId = model.ClassId,
                    StudentGender = model.StudentGender,
                    StudentEmailId = model.StudentEmailId,
                    StudentDob = model.StudentDob.Value,
                    StudentName = model.StudentName,
                    StudentRollNo = model.StudentRollNo

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

