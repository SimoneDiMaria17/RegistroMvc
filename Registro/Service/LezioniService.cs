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
        public async Task<List<LezioniViewModel>> GetAllLezioni(int userId)
        {
                using (var db = new RegistroEntities2())
                {
                    List<LezioniViewModel> lezioni = await db.Lezione
                        .Select(ls=> new LezioniViewModel()
                        {
                            LezioneId = ls.LezioneId,
                            UserId = ls.UserId,
                            DataLezione = ls.DataLezione,
                        }).Where(l=>l.UserId == userId)
                        .ToListAsync();
                    return lezioni;
                }
            }
        public async Task<List<LezioniStudentiviewModel>> GetStudentsByLezioni(int lezioneId)
        {
            using (var db = new RegistroEntities2())
            {
                return await db.LezioniStudenti
                    .Select(l => new LezioniStudentiviewModel()
                    {
                        LezioneId = l.LezioneId,
                        Studente = l.Studenti,
                        Data = l.Lezione.DataLezione,
                        Presente = l.Presente,
                    })
                    .Where(l => l.LezioneId == lezioneId)
                    .ToListAsync();
            }
       
        }
    }
    
}