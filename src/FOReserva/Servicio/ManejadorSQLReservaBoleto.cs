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

            //metodo de buscar reservas por lugar de origen, destino, fecha de ida y de vuelta y por clase de vuelo.
           
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

            //metodo para ver la disponibilidad de todos los vuelos de una clase y de una fecha (tambien se le podria agregar vuelo) 

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

        public List<CModeloBoleto> buscarReserva(string pasajero)
        {

            //consultar reserva por numero de pasajero (o correo, no sé)

            string query = "Select reb_id, reb_fecha_reservado, reb_costo, reb_codigo, reb_tipo, l1.lug_nombre as lug_origen, l2.lug_nombre as lug_destino from Reserva_Boleto rb, Lugar l1, Lugar l2 where fk_pas_id = "+pasajero+" and l1.lug_id = rb.fk_origen and l2.lug_id = rb.fk_destino";


            SqlDataReader read = Executer(query);
            List<CModeloBoleto> lista_res = new List<CModeloBoleto>();
            if (read.HasRows)
            {
                
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    DateTime fecha = DateTime.Parse(read["reb_fecha_reservado"].ToString());
                    float costo = float.Parse(read["reb_costo"].ToString());
                    string codigo = read["reb_codigo"].ToString();
                    string tipo = read["reb_tipo"].ToString();
                    string origen = read["lug_origen"].ToString();
                    string destino = read["lug_destino"].ToString();
                    CModeloBoleto resv = new CModeloBoleto();
                    resv.Id = id;
                    resv.costo = costo;
                    resv.codigo = codigo;
                    resv.tipo = tipo;
                    resv.origen = origen;
                    resv.destino = destino;
                    System.Diagnostics.Debug.WriteLine(resv.Id);
                    System.Diagnostics.Debug.WriteLine(resv.fecha);
                    System.Diagnostics.Debug.WriteLine(resv.costo);
                    System.Diagnostics.Debug.WriteLine(resv.codigo);
                    System.Diagnostics.Debug.WriteLine(resv.tipo);
                    System.Diagnostics.Debug.WriteLine(resv.origen);
                    System.Diagnostics.Debug.WriteLine(resv.destino);
                    lista_res.Add(resv);
                }
            }
            CloseConnection();

            return lista_res;
        }

        public List<CModeloBoleto> insertarReserva(DateTime fecha, int idavuelta, float costo, string codigo, string clase, string origen, string destino, int pasaporte) 
        {

            //metodo para insertar reservas  

            string query = "insert into Reserva_Boleto values((Select max(reb_id)+1 from Reserva_Boleto),"+fecha+",0,"+idavuelta+","+costo+",'"+codigo+"','"+clase+"',(Select lug_id from Lugar where lug_nombre='"+origen+"'),(Select lug_id from Lugar where lug_nombre='"+destino+"'),"+pasaporte+")";


            SqlDataReader read = Executer(query);
            List<CModeloBoleto> lista_res = new List<CModeloBoleto>();
            
            CloseConnection();

            return lista_res;
        }

        public List<CLugar> buscarCiudades()
        {

            string query = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";

            SqlDataReader read = Executer(query);

            List<CLugar> ciudades = new List<CLugar>();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    var text = read.GetString(read.GetOrdinal("lug_nombre"));
                    var id = read.GetInt32(read.GetOrdinal("lug_id"));
                    ciudades.Add(new CLugar(id.ToString(), text));
                }

            }
            return ciudades;
        }


    }
}
