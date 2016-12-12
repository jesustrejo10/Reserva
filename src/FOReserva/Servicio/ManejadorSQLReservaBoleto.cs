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

        public List<CModeloBoleto> buscarReserva(string origen, string destino, string ida, string vuelta, string clase)
        {

            //hacer catch de errores: si es null(objeto), vacio(lista), 
           
                string query = "Select distinct(bol_id), bol_costo from Boleto b, Vuelo v, Boleto_Vuelo bv, Avion a, Lugar l1, Lugar l2 where b.bol_fk_lugar_origen = l1.lug_id and b.bol_fk_lugar_destino = l2.lug_id and b.bol_id = bv.bol_fk_boleto and bv.bol_fk_vuelo= v.vue_id and b.bol_tipo_boleto = '" + clase + "' and v.vue_fecha_despegue between '" + ida + "' and '" + vuelta + "' and l1.lug_nombre = '" + origen + "'--origen and l2.lug_nombre = '" + destino + "'";

                SqlDataReader read = Executer(query);
                List<CModeloBoleto> lista_res = new List<CModeloBoleto>();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        int id = read.GetInt32(0);
                        float costo = float.Parse(read["bol_costo"].ToString());
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

        public List<CModeloBoleto> buscarDisponibilidad(string clase, string fecha)
        {

            //hacer catch de errores: si es null(objeto), vacio(lista), 

            string query = "Select vue_id, sum(a.avi_pasajeros_turista) - count(b.bol_id) as disponibilidad from Avion a, Boleto b, Boleto_Vuelo bv, Vuelo v where a.avi_id = v.vue_fk_avion and v.vue_id = bv.bol_fk_vuelo and b.bol_id = bv.bol_fk_boleto and b.bol_tipo_boleto = '" + clase + "' and v.vue_fecha_despegue = '" + fecha + "' group by vue_id";


            SqlDataReader read = Executer(query);
            List<CModeloBoleto> lista_res = new List<CModeloBoleto>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    float costo = float.Parse(read["disponibilidad"].ToString());
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
