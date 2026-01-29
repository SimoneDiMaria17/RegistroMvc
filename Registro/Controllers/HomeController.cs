
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Registro.Models;

namespace Registro.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        public HomeController()
        {
            _userService = new UserService();
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Lezioni");
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

                    return RedirectToAction("Index", "Student");
                }
                ModelState.AddModelError("Password", "Credenziali non valide");
            }

            return View(user);
        }
    }
}