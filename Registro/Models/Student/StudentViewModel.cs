using System.ComponentModel.DataAnnotations;

namespace Registro.Models.Student
{
    public class StudentViewModel
    {
        public int StudentiID { get; set; }
        [Required(ErrorMessage = "Il Nome è obbligatorio.")]
        //[RegularExpression("^([A-Za-z]+)$", ErrorMessage = "Il nome può contenere solo lettere")]
        public string Nome { get; set; }
    }
}