using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Registro.Models.Lezioni;

namespace Registro.Controllers
{
    public class LezioniController : Controller
    {
        public readonly LezioniService _lezioniService;
        

        public LezioniController()
        {
            _lezioniService = new LezioniService();
        }
        // GET
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            List<LezioniViewModel> lezioni = await _lezioniService.GetAllLezioni(User.Identity.Name);
            return View(lezioni);
        }
    }
}