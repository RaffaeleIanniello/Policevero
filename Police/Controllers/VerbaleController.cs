using Police.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Police.Controllers
{
    public class VerbaleController : Controller
    {
        // GET: Verbale
        public ActionResult Indice()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand("select * from VERBALE", conn);
            SqlDataReader sqlDataReader;
            conn.Open();

            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Verbale verbale = new Verbale();
                verbale.IdVerbale = Convert.ToInt32(sqlDataReader["IdVerbale"]);
                
                verbale.IndirizzoViolazione = sqlDataReader["IndirizzoViolazione"].ToString();
                verbale.NominativoAgente = sqlDataReader["NominativoAgente"].ToString();
               
                verbale.Importo = Convert.ToInt32(sqlDataReader["Importo"]);




                Verbale.ListaVerbale.Add(verbale);

            }

            return View(Verbale.ListaVerbale);
        }

        [HttpGet]
        public ActionResult Crea()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crea(Verbale v)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO VERBALE VALUES(@IndirizzoViolazione, @NominativoAgente, @Importo)";
            cmd.Parameters.AddWithValue("IndirizzoViolazione", v.IndirizzoViolazione);
            cmd.Parameters.AddWithValue("NominativoAgente", v.NominativoAgente);
            cmd.Parameters.AddWithValue("Importo", v.Importo);



            int inserimento = cmd.ExecuteNonQuery();

            Verbale.ListaVerbale.Add(v);


            conn.Close();
            return RedirectToAction("Indice");





        }
        
    }
}