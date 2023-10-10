using Police.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Police.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand("select * from ANAGRAFICA", conn);
            SqlDataReader sqlDataReader;
            conn.Open();

            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Anagrafica anagrafica = new Anagrafica();
                anagrafica.idAnagrafica = Convert.ToInt32(sqlDataReader["IdAnagrafica"]);
                anagrafica.cognome = sqlDataReader["cognome"].ToString();
                anagrafica.nome = sqlDataReader["nome"].ToString();
                anagrafica.indirizzo = sqlDataReader["indirizzo"].ToString();
                anagrafica.citta = sqlDataReader["citta"].ToString();
                anagrafica.CAP = Convert.ToInt32(sqlDataReader["IdAnagrafica"]);
                



                Anagrafica.ListaAnagrafica.Add(anagrafica);

            }

            return View(Anagrafica.ListaAnagrafica);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Anagrafica a)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO ANAGRAFICA VALUES(@cognome, @nome, @indirizzo, @citta,@CAP,@CF)";
            cmd.Parameters.AddWithValue("cognome", a.cognome);
            cmd.Parameters.AddWithValue("nome", a.nome);
            cmd.Parameters.AddWithValue("indirizzo", a.indirizzo);
            cmd.Parameters.AddWithValue("citta", a.citta);
            cmd.Parameters.AddWithValue("CAP", a.CAP);
            cmd.Parameters.AddWithValue("CF", a.CF);


            int inserimento = cmd.ExecuteNonQuery();

            Anagrafica.ListaAnagrafica.Add(a);

            
            conn.Close();
            return RedirectToAction("Index");

        }

        
    }
}