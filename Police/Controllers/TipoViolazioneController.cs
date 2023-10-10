using Police.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Police.Controllers
{
  
    public class TipoViolazioneController : Controller
    {
        public ActionResult TVol()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand("select * from TIPOVIOLAZIONE", conn);
            SqlDataReader sqlDataReader;
            conn.Open();

            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                TipoViolazione tipoViolazione = new TipoViolazione();
                tipoViolazione.IdViolazione = Convert.ToInt32(sqlDataReader["IdViolazione"]);
                tipoViolazione.Descrizione = sqlDataReader["descrizione"].ToString();
                




                TipoViolazione.ListaTipoViolazione.Add(tipoViolazione);

            }

            return View(TipoViolazione.ListaTipoViolazione);
        }

        [HttpGet]
        public ActionResult CreaTVol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaTVol(TipoViolazione tv)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO TIPOVIOLAZIONE VALUES(@idViolazione, @descrizione)";
            cmd.Parameters.AddWithValue("IdViolazione", tv.IdViolazione);
            cmd.Parameters.AddWithValue("descrizione", tv.Descrizione);
          


            int inserimento = cmd.ExecuteNonQuery();

            TipoViolazione.ListaTipoViolazione.Add(tv);


            conn.Close();
            return RedirectToAction("TVol");

        }

    }
}