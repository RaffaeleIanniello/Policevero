using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class Anagrafica
    {
        public int idAnagrafica { get; set; }
        public string cognome { get; set; }
        public string nome { get; set; }
        public string indirizzo { get; set; }
        public string citta { get; set; }
        public int CAP { get; set; }
        public string CF { get; set; }


        public static List<Anagrafica> ListaAnagrafica { get; set; } = new List<Anagrafica>();
        public Anagrafica() { }
        public Anagrafica(int idAnagrafica, string cognome, string nome, string indirizzo, string citta, int cAP, string cF)
        {
            this.idAnagrafica = idAnagrafica;
            this.cognome = cognome;
            this.nome = nome;
            this.indirizzo = indirizzo;
            this.citta = citta;
            CAP = cAP;
            CF = cF;
        }
    }
}