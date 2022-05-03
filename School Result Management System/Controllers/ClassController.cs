using Microsoft.AspNetCore.Mvc;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSViewModel;

namespace School_Result_Management_System.Controllers
{
    public class ClassController : Controller
    {
        private IClassRepository _classrepo;


        public ClassController(IClassRepository classrepo)
        {
            _classrepo = classrepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Class> classes = _classrepo.GetAllClasses();
            return View(classes);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ClassViewModel());

        }
        [HttpPost]
        public async Task<IActionResult> Create(ClassViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_classrepo.ClassExists(model.ClassName))
                {
                    ModelState.AddModelError(string.Empty, "Class with the given classname already exists.");
                    return View(model);
                }

                Class newclass = new Class()
                {
                    ClassName = model.ClassName
                };

                await _classrepo.AddClassAsync(newclass);
                return RedirectToAction("Index");
            };
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            Class cl = _classrepo.GetClassById(id);
            return View(cl);

        }

        [HttpPost]
        public IActionResult Edit(Class cl)
        {
            if (ModelState.IsValid)
            {
                _classrepo.UpdateClass(cl);
                return RedirectToAction("Index");
            }

            return View(cl);


        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _classrepo.RemoveClassAsync(id);
                return Redirect("/Class");
            }
            catch (Exception ex)
            {
                Class cls = _classrepo.GetClassById(id);
                ViewBag.ErrorMessage = $"{cls.ClassName} class has been assigned to the students." +
                    $"Please make sure the class hasn't been assigned to any students before deleting it."
                    + $"If you want to delete the class, delete the students to which this class has been assigned and try again";
                return View("Error");
            }

        }





    }
}
