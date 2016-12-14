using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using FOReserva.Models.Cruceros;

namespace FOReserva.Servicio
{
    public class manejadorSQLCrucero : manejadorSQL
    {
         public string stringDeConexion;

        public manejadorSQLCrucero()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        //Procedimiento del Modulo 22 para buscar los cruceros
        public List<Cruceros> buscarCruceros()
        {
            List<Cruceros> cruceros = new List<Cruceros>();

            string querystring = "SELECT [cru_id] ,[cru_nombre] FROM [dbo].[Crucero]";



            SqlDataReader reader = Executer(querystring);
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            var text = reader.GetString(reader.GetOrdinal("cru_nombre"));
                            var id = reader.GetInt32(reader.GetOrdinal("cru_id"));
                            cruceros.Add(new Cruceros
                            {
                                id = id.ToString(),
                                Name = text
                            });
                        }

                    }
                    CloseConnection();
                
            
            return cruceros;
            }

        public List<CReserva_Cruceros> buscarItinerarios(string ncrucero, string fechadeida, string fechadevuelta)
        {
            List<CReserva_Cruceros> lista_crucerosItinerario = new List<CReserva_Cruceros>();
            string query = "Select [cru_id],[cru_nombre] as nombreCrucero, [icru_fecha_inicio], [icru_fecha_fin], ori.[lug_nombre] as origen, des.[lug_nombre] as destino, [rut_id] from [dbo].[itinerario_crucero], [dbo].[crucero], [dbo].[ruta], [dbo].[lugar] as ori, [dbo].[lugar] as des where [icru_fk_crucero] = " + ncrucero + " and [cru_id] =" + ncrucero + " and [icru_fecha_inicio]= '" + fechadeida + "' and [icru_estatus]='activo' and [icru_fecha_fin]= '" + fechadevuelta + "' and [rut_id]=[icru_fk_ruta] and des.[lug_id]=[rut_fk_lugar_destino] and ori.[lug_id]=[rut_fk_lugar_origen];";
             using (SqlConnection connection = new SqlConnection(stringDeConexion))
             using (SqlCommand cmd = new SqlCommand(query, connection))
             {
                 connection.Open();
                 using (SqlDataReader read = cmd.ExecuteReader())
                 {

                     if (read.HasRows)
                     {
                         while (read.Read())
                         {
                             string id_crucero = read.GetInt32(read.GetOrdinal("cru_id")).ToString();
                             string nombre_crucero = read.GetString(read.GetOrdinal("nombreCrucero"));
                             //string fecha = read.GetDateTime(2).Tostring("yyyy-MM-dd");
                             string fechaIda = read.GetDateTime(read.GetOrdinal("icru_fecha_inicio")).ToString();
                             //int cantidad = read.GetInt32(4);
                             string fechaVuelta = read.GetDateTime(read.GetOrdinal("icru_fecha_fin")).ToString();

                             string lugarOrigen = read.GetString(read.GetOrdinal("origen"));

                             string lugarDestino = read.GetString(read.GetOrdinal("destino"));
                             string id_ruta = read.GetInt32(read.GetOrdinal("rut_id")).ToString();
                             Console.WriteLine("NOmbre ", nombre_crucero);


                             CReserva_Cruceros reserva = new CReserva_Cruceros(id_crucero, lugarOrigen, lugarDestino, nombre_crucero, fechadeida, fechadevuelta, id_ruta);
                             lista_crucerosItinerario.Add(reserva);
                         }
                     }
                     return lista_crucerosItinerario;
                 }
             }
        }

        /*Metodo que crea una reserva*/
        public void CrearReserva(CReserva_Cruceros reserva)
        {
            string query = "INSERT INTO Reserva_Crucero ( rc_fecha, rc_cantidad_pasajeros, fk_usuario, fk_crucero, fk_ruta, fk_fecha, rc_Status) VALUES( GETDATE(), " + reserva._numeroPasajeros + ",1," + reserva._fk_crucero + "," + reserva._fk_ruta + ", convert(date,'" + reserva._fecha_inicio + "'), 'activo')";
            this.Executer(query);
            CloseConnection();
        }

        /*Metodo para eliminar una reserva
         *  idReserva: ID de la reserva a eliminar
         */
        public void eliminarReserva(int idReserva)
        {

            string query = "DELETE FROM Reserva_Crucero WHERE rc_id = " + idReserva;
            this.Executer(query);
            CloseConnection();
        }

        /*
         *  Metodo para modificar datos de la reserva
         */
        public void modificarReserva(string id_reserva,string pasajero,string estatus)
        {
            string query = "update Reserva_Crucero set  rc_cantidad_pasajeros = " + pasajero+ ", rc_status = '" + estatus + "' where rc_id =" + id_reserva;
            this.Executer(query);
            CloseConnection();
        }

        /* Metodo para buscar la lista de reservas de un usuario */
        public List<CReserva_Cruceros> buscarReservasCruceros()
        {
            string query = "select rc_id,rc_fecha, rc_cantidad_pasajeros, ori.lug_nombre as origen, des.lug_nombre as destino, cru_nombre as crucero, icru_fecha_inicio, icru_fecha_fin, rc.fk_usuario, rc_status from reserva_crucero as rc, crucero, itinerario_crucero, ruta, lugar as ori, lugar as des, Usuario where usu_id=fk_usuario and des.lug_id=rut_fk_lugar_destino and ori.lug_id=rut_fk_lugar_origen and rut_id=icru_fk_ruta and icru_fk_crucero=cru_id and icru_fecha_inicio=fk_fecha and icru_fk_crucero=fk_crucero and icru_fk_ruta=fk_ruta";
            SqlDataReader read = Executer(query);
            List<CReserva_Cruceros> lista_reservas = new List<CReserva_Cruceros>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    string idreserva = read.GetInt32(read.GetOrdinal("rc_id")).ToString();
                    string fechaReserva = read.GetDateTime(read.GetOrdinal("rc_fecha")).ToString();
                    int cantidadPasajeros = read.GetInt32(read.GetOrdinal("rc_cantidad_pasajeros"));
                    string nombre_crucero = read.GetString(read.GetOrdinal("crucero"));
                    //string fecha = read.GetDateTime(2).Tostring("yyyy-MM-dd");
                    string fechaIda = read.GetDateTime(read.GetOrdinal("icru_fecha_inicio")).ToString();

                    string fechaVuelta = read.GetDateTime(read.GetOrdinal("icru_fecha_fin")).ToString();

                    string lugarOrigen = read.GetString(read.GetOrdinal("origen"));

                    string lugarDestino = read.GetString(read.GetOrdinal("destino"));
                    string estatus = read.GetString(read.GetOrdinal("rc_status"));
                    Console.WriteLine("NOmbre ", nombre_crucero);


                    CReserva_Cruceros reserva = new CReserva_Cruceros(idreserva,fechaReserva, cantidadPasajeros, nombre_crucero, lugarOrigen, lugarDestino, fechaIda, fechaVuelta, estatus);

                    lista_reservas.Add(reserva);
                }
            }
            CloseConnection();
            return lista_reservas;
        }


    }
}