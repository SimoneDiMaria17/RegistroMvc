using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Registro.Models.Database;
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
        [Authorize]
        public async Task<ActionResult> Index()
        {
           List<StudentViewModel> student = await _studentservice.GetAllStudent();
            return View(student);
        }
    }
}