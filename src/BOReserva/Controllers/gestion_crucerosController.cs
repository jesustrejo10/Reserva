using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_crucerosController : Controller
    {
        // GET: gestion_cruceros
        public ActionResult M24_GestionCruceros()
        {
            return PartialView();
        }

        public ActionResult M24_ListarCruceros()
        {
            return PartialView();
        }

        //public DataTable fillDataTable(string table)
        //{
        //    string query = "SELECT * FROM dstut.dbo." + table;

        //    SqlConnection sqlConn = new SqlConnection(conSTR);
        //    sqlConn.Open();
        //    SqlCommand cmd = new SqlCommand(query, sqlConn);

        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    sqlConn.Close();
        //    return dt;
        //}
    }
}