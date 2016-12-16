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
         

        //Procedimiento del Modulo 22 para buscar los cruceros
        public List<Cruceros> buscarCruceros()
        {
            //Se instancia una lista de tipo Cruceros
            List<Cruceros> cruceros = new List<Cruceros>();
            // Se crea el Query que se mandara a la base de datos.
            string querystring = "SELECT [cru_id] ,[cru_nombre] FROM [dbo].[Crucero]";
           //Se crea el Lector de la data para la base de datos
            SqlDataReader reader = Executer(querystring);
                    // Se pregunta si el SQLDataReader posee columnas.
                    if (reader.HasRows)
                    {
                        //Se leen los datos en el SqlDataReader.
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

        //Procedimiento del Modulo 22 para buscar los Itinarios
        public List<CReserva_Cruceros> buscarItinerarios(string ncrucero, string fechadeida, string fechadevuelta)
        {
            //Se instancia una lista de tipo CReserva_Cruceros
            List<CReserva_Cruceros> lista_crucerosItinerario = new List<CReserva_Cruceros>();
            // Se crea el Query que se mandara a la base de datos.
            string query = "Select [cru_id],[cru_nombre] as nombreCrucero, [icru_fecha_inicio], [icru_fecha_fin], ori.[lug_nombre] as origen, des.[lug_nombre] as destino, [rut_id] from [dbo].[itinerario_crucero], [dbo].[crucero], [dbo].[ruta], [dbo].[lugar] as ori, [dbo].[lugar] as des where [icru_fk_crucero] = " + ncrucero + " and [cru_id] =" + ncrucero + " and [icru_fecha_inicio]= '" + fechadeida + "' and [icru_estatus]='activo' and [icru_fecha_fin]= '" + fechadevuelta + "' and [rut_id]=[icru_fk_ruta] and des.[lug_id]=[rut_fk_lugar_destino] and ori.[lug_id]=[rut_fk_lugar_origen];";

            //Se crea el Lector de la data para la base de datos
            SqlDataReader read = Executer(query);

            // Se pregunta si el SQLDataReader posee columnas.
                     if (read.HasRows)
                     {
                         //Se leen los datos en el SqlDataReader.
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

        //Procedimiento del Modulo 22 para Crear las Reservas
        public void CrearReserva(CReserva_Cruceros reserva)
        {
            // Se crea el Query que se mandara a la base de datos.
            string query = "INSERT INTO Reserva_Crucero ( rc_fecha, rc_cantidad_pasajeros, fk_usuario, fk_crucero, fk_ruta, fk_fecha, rc_Status) VALUES( GETDATE(), " + reserva._numeroPasajeros + ",1," + reserva._fk_crucero + "," + reserva._fk_ruta + ", convert(date,'" + reserva._fecha_inicio + "'), 'activo')";
            this.Executer(query);
            CloseConnection();
        }

        /*Metodo para eliminar una reserva
         *  idReserva: ID de la reserva a eliminar
         */
        public void eliminarReserva(int idReserva)
        {
            // Se crea el Query que se mandara a la base de datos.
            string query = "DELETE FROM Reserva_Crucero WHERE rc_id = " + idReserva;
            this.Executer(query);
            CloseConnection();
        }

        /*
         *  Metodo para modificar datos de la reserva
         */
        public void modificarReserva(string id_reserva,string pasajero,string estatus)
        {
            // Se crea el Query que se mandara a la base de datos.
            string query = "update Reserva_Crucero set  rc_cantidad_pasajeros = " + pasajero+ ", rc_status = '" + estatus + "' where rc_id =" + id_reserva;
            this.Executer(query);
            CloseConnection();
        }

        /* Metodo para buscar la lista de reservas de un usuario */
        public List<CReserva_Cruceros> buscarReservasCruceros()
        {
            // Se crea el Query que se mandara a la base de datos.
            string query = "select rc_id,rc_fecha, rc_cantidad_pasajeros, ori.lug_nombre as origen, des.lug_nombre as destino, cru_nombre as crucero, icru_fecha_inicio, icru_fecha_fin, rc.fk_usuario, rc_status from reserva_crucero as rc, crucero, itinerario_crucero, ruta, lugar as ori, lugar as des, Usuario where usu_id=fk_usuario and des.lug_id=rut_fk_lugar_destino and ori.lug_id=rut_fk_lugar_origen and rut_id=icru_fk_ruta and icru_fk_crucero=cru_id and icru_fecha_inicio=fk_fecha and icru_fk_crucero=fk_crucero and icru_fk_ruta=fk_ruta";
            //Se crea el Lector de la data para la base de datos
            SqlDataReader read = Executer(query);
            //Se instancia una lista de tipo CReserva_Cruceros
            List<CReserva_Cruceros> lista_reservas = new List<CReserva_Cruceros>();
            // Se pregunta si el SQLDataReader posee columnas.
            if (read.HasRows)
            {
                //Se leen los datos en el SqlDataReader.
                while (read.Read())
                {
                    string idreserva = read.GetInt32(read.GetOrdinal("rc_id")).ToString();
                    string fechaReserva = read.GetDateTime(read.GetOrdinal("rc_fecha")).ToString();
                    int cantidadPasajeros = read.GetInt32(read.GetOrdinal("rc_cantidad_pasajeros"));
                    string nombre_crucero = read.GetString(read.GetOrdinal("crucero"));
           
                    string fechaIda = read.GetDateTime(read.GetOrdinal("icru_fecha_inicio")).ToString();

                    string fechaVuelta = read.GetDateTime(read.GetOrdinal("icru_fecha_fin")).ToString();

                    string lugarOrigen = read.GetString(read.GetOrdinal("origen"));

                    string lugarDestino = read.GetString(read.GetOrdinal("destino"));
                    string estatus = read.GetString(read.GetOrdinal("rc_status"));
         


                    CReserva_Cruceros reserva = new CReserva_Cruceros(idreserva,fechaReserva, cantidadPasajeros, nombre_crucero, lugarOrigen, lugarDestino, fechaIda, fechaVuelta, estatus);

                    lista_reservas.Add(reserva);
                }
            }
            CloseConnection();
            return lista_reservas;
        }


    }
}