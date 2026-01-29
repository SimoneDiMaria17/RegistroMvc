using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "UserName Necessario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Necessaria")]
        public string Password { get; set; }

    }
}