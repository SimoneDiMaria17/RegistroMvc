namespace Registro.Models.Lezioni
{
    public class LezionistudentiInput
    {
        public int StudenteId { get; set; }
        public int LezioneId{ get; set; }
        public bool Presente { get; set; }
    }
}