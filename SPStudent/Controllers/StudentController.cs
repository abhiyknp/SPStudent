using Microsoft.AspNetCore.Mvc;
using SPStudent.Models;


namespace SPStudent.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer objStudentDAL = new StudentDataAccessLayer(); // GET: /<controller>/
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Student objStudent)
        {
            if (ModelState.IsValid)
            {
                objStudentDAL.AddStudent(objStudent);
                return RedirectToAction("Index");
            }
            return View(objStudent);
        }
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            students = objStudentDAL.GetAllStudents().ToList();
            return View(students);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = objStudentDAL.GetStudentData(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Student objstudent)
        {
            if (id != objstudent.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objStudentDAL.UpdateStudent(objstudent);
                return RedirectToAction("Index");
            }
            return View(objStudentDAL);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student objstudent = objStudentDAL.GetStudentData(id);

            if (objstudent == null)
            {
                return NotFound();
            }
            return View(objstudent);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student objstudent = objStudentDAL.GetStudentData(id);

            if (objstudent == null)
            {
                return NotFound();
            }
            return View(objstudent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objStudentDAL.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
