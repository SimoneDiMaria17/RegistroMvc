using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Registro.Models.Lezioni;

namespace Registro.Controllers
{
    public class LezioniController : Controller
    {
        public readonly LezioniService _lezioniService;
        public readonly UserService _userService;

        public LezioniController()
        {
            _lezioniService = new LezioniService();
            _userService = new UserService();
        }
        // GET
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            int userid = await _userService.GetIdByUsername(User.Identity.Name);
            List<LezioniViewModel> lezioni = await _lezioniService.GetAllLezioni(userid);
            return View(lezioni);
        }
    }
}