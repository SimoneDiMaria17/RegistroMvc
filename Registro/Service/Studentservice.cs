using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Registro.Models.Database;
using Registro.Models.Student;

namespace Registro
{
    public class Studentservice
    {
        public async Task<List<StudentViewModel>> GetAllStudent()
        {
            using (var db = new RegistroEntities2())
            {
                List<Studenti> response= await db.Studenti.ToListAsync();
                List<StudentViewModel> student = new List<StudentViewModel>();
                if (response.Count > 0)
                {
                    foreach (Studenti data in response)
                    {
                        student.Add(new StudentViewModel()
                        {
                            StudentiID =  data.StudentiID,
                            Nome =  data.Nome,
                        });
                    }
                }
                return student;
                
            }
        }
    }
}