using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }

        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }

        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        
        public static List<Verbale> ListaVerbale { get; set; } = new List<Verbale>();
        public Verbale() { }    
        public Verbale(int idVerbale, DateTime dataViolazione, string indirizzoViolazione, string nominativoAgente, DateTime dataTrascrizioneVerbale, decimal importo, int decurtamentoPunti)
        {
            IdVerbale = idVerbale;
            DataViolazione = dataViolazione;
            IndirizzoViolazione = indirizzoViolazione;
            NominativoAgente = nominativoAgente;
            DataTrascrizioneVerbale = dataTrascrizioneVerbale;
            Importo = importo;
            DecurtamentoPunti = decurtamentoPunti;
        }
        
    }
}