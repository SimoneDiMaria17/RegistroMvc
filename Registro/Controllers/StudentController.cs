using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Registro.Models.Database;
using Registro.Models.Lezioni;
using Registro.Models.Student;

namespace Registro.Controllers
{
    public class StudentController : Controller
    {
        private readonly Studentservice _studentservice;
        public StudentController()
        {
            _studentservice = new Studentservice();
        }
        // GET
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Index(int id)
        {
           List<StudentViewModel> student = await _studentservice.GetStudentsByLezione(id);
            return View(student);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(List<LezionistudentiInput> lezionistudentiInput)
        {
            foreach (LezionistudentiInput lezione in lezionistudentiInput)
            {
                _studentservice.PresentStudent(lezione);
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task CreateStudent(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                _studentservice.AddStudent(studentViewModel);
            }
        }
    }
}