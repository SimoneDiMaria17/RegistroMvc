using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Registro.Models.Database;
using Registro.Models.Lezioni;
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

        public async Task AddStudent(StudentViewModel student)
        {
            using (var db = new RegistroEntities2())
            {
                db.Studenti.Add(new Studenti(){Nome =  student.Nome});
                await db.SaveChangesAsync();
            }
        }
        public async Task PresentStudent(LezionistudentiInput lezione)
        {
            using (var db = new RegistroEntities2())
            {
                LezioniStudenti lez = await db.LezioniStudenti.FirstOrDefaultAsync(l=>
                    l.StudenteId==lezione.StudenteId &&
                    l.LezioneId == lezione.LezioneId);
                if (lez == null)
                {
                    throw new NullReferenceException("Lezione nulla");
                }
                    lez.Presente = lezione.Presente;
                await db.SaveChangesAsync();
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