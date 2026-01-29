using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Registro.Models.Database;
using Registro.Models.Lezioni;
using ModelState = System.Web.WebPages.Html.ModelState;

namespace Registro
{
    public class LezioniService
    {
        public async Task<List<LezioniViewModel>> GetAllLezioni(string username)
        {
                using (var db = new RegistroEntities2())
                {
                    List<LezioniViewModel> lezioni = await db.Lezione
                        .Where(l=>l.User.Username == username)
                        .Select(ls=> new LezioniViewModel()
                        {
                            LezioneId = ls.LezioneId,
                            UserId = ls.UserId,
                            DataLezione = ls.DataLezione,
                        })
                        .OrderByDescending(l=>l.DataLezione)
                        .ToListAsync();
                    return lezioni;
                }
            }
    }
    
}