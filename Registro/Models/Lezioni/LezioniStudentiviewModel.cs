using System;
using System.Collections.Generic;
using Registro.Models.Database;

namespace Registro.Models.Lezioni
{
    public class LezioniStudentiviewModel
    {
        public int LezioniStudentiId { get; set; }
        public int LezioneId { get; set; }
        public int StudenteId { get; set; }
        public bool Presente { get; set; }
        public DateTime Data { get; set; }
        public Lezione  Lezione { get; set; }
        public Studenti Studente { get; set; }
    }
}