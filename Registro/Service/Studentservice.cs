using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Registro.Models.Database;
using Registro.Models.Student;

namespace Registro
{
    public class Studentservice
    {
        public async Task<List<StudentViewModel>> GetStudentsByLezione(int idLezione)
        {
            using (var db = new RegistroEntities2())
            {
                return await db.LezioniStudenti.Where(l => l.LezioneId == idLezione)
                    .Select(l => new StudentViewModel()
                    {
                        StudentiID = l.Studenti.StudentiID,
                        Nome = l.Studenti.Nome
                    }).ToListAsync();
            }

            
        }
        public async Task<List<StudentViewModel>> GetAllStudent()
        {
            using (var db = new RegistroEntities2())
            {
                return await db.Studenti.Select(s => new StudentViewModel()
                {
                    StudentiID = s.StudentiID,
                    Nome = s.Nome
                }).ToListAsync();
            }
        }
    }
}