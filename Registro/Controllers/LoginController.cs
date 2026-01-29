using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Registro.Models;

namespace Registro.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        public LoginController()
        {
            _userService = new UserService();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        //login
        [HttpPost]
        public async Task<ActionResult> Index(UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.CheckUserPassword(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    return RedirectToAction("Index", "Lezioni");
                }
                ModelState.AddModelError("Password", "Credenziali non valide");
            }

            return View(user);
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}