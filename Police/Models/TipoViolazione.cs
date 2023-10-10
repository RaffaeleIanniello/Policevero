using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class TipoViolazione
    {
        public int IdViolazione { get; set; }
        public string Descrizione { get; set; }

        public static List<TipoViolazione> ListaTipoViolazione { get; set; } = new List<TipoViolazione>();
        public TipoViolazione() { }
        public TipoViolazione(int IdViolazione, string Descrizione)
        {
            this.IdViolazione = IdViolazione;
            this.Descrizione = Descrizione;
        }


    }
}