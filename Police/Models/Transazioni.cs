using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class Transazioni
    {
        public decimal Importo { get; set; }

        public static List<Transazioni> ListaImporti { get; set; } = new List<Transazioni>();
        public Transazioni() { }
        public Transazioni(int transazioni)
        {
            Importo = transazioni;
         
        }
    }
}