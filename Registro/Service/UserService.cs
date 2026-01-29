using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Registro.Models;
using Registro.Models.Database;

namespace Registro
{
    public class UserService
    {
        public async Task<int> GetIdByUsername(string username)
        {
            using (var db = new RegistroEntities2())
            {
                return await db.User
                    .Where(u => u.Username == username)
                    .Select(u => u.UserId)
                    .FirstAsync();
            }
        }
        public async Task<bool> CheckUserPassword(UserLoginModel user)
        {
            using (var db = new RegistroEntities2())
            {
                return await db.User.AnyAsync(u => u.Username == user.Username && u.Password == user.Password);
            }
        }
    }
}