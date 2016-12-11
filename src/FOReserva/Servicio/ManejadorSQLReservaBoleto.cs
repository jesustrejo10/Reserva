using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using FOReserva.Models.ReservaBoleto;

namespace FOReserva.Servicio
{
    public class ManejadorSQLReservaBoleto : manejadorSQL
    {
        public ManejadorSQLReservaBoleto() : base() { }

        public List<CModeloBoleto> buscarReserva(string origen, string destino, string ida) 
        {
            
            //string query = "Select * from Boleto where fk_pas_if=" + pasaporte + "')";
            string query = "Select b.bol_id, b.bol_costo from Boleto b, Lugar l1, Lugar l2 where b.bol_fk_lugar_origen = l1.lug_id and b.bol_fk_lugar_destino = l2.lug_id and l1.lug_nombre = '"+origen+"' and l2.lug_nombre = '"+destino+"' and b.bol_fecha = '"+ida+"'";

            SqlDataReader read = Executer(query);
            List<CModeloBoleto> lista_res = new List<CModeloBoleto>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    float costo = float.Parse(read["bol_costo"].ToString()) ;
                    CModeloBoleto resv = new CModeloBoleto();
                    resv.Id = id;
                    resv.costo = costo;
                    System.Diagnostics.Debug.WriteLine(resv.Id);
                    System.Diagnostics.Debug.WriteLine(resv.costo);
                    lista_res.Add(resv);
                }
            }
            CloseConnection();
            return lista_res;
        }
    }
}
