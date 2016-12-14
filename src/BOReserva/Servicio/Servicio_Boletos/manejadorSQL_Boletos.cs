using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BOReserva.Models.gestion_boletos;

namespace BOReserva.Servicio.Servicio_Boletos
{
    public class manejadorSQL_Boletos
    {
         public string stringDeConexion;

        public manejadorSQL_Boletos()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        //Procedimiento del Modulo 5 para buscar las ciudades
        public List<CLugar> buscarCiudades()
        {
            List<CLugar> ciudades = new List<CLugar>();

            string queryString = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";

            using (SqlConnection connection = new SqlConnection(stringDeConexion))
            using (SqlCommand cmd = new SqlCommand(queryString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            var text = reader.GetString(reader.GetOrdinal("lug_nombre"));
                            var id = reader.GetInt32(reader.GetOrdinal("lug_id"));
                            ciudades.Add(new CLugar(id.ToString(), text));
                        }

                    }
                }
            }
            return ciudades;
            }

        public List<CBoleto> M05ListarBoletosBD()
        {
            List<CBoleto> listaboletos = new List<CBoleto>();
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT * FROM Boleto";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["bol_fecha"];
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                        CBoleto boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()),Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())),
                                               MBuscarnombrepasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())),
                                               MBuscarapellidopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())), fechaboleto,
                                               Int32.Parse(reader["bol_fk_pasajero"].ToString()), reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                               reader["bol_tipo_boleto"].ToString(),
                                               MBuscarcorreopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())));
                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                con.Close();
                return listaboletos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public String MBuscarnombreciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudad = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                return _ciudad;
            }
        }

        public String MBuscarnombrepasajero(int id)
        {
            String _nombre = "";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT pas_primer_nombre FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _nombre = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _nombre;
            }
            catch (SqlException ex)
            {
                return _nombre;
            }
        }

        public String MBuscarapellidopasajero(int id)
        {
            String _apellido = "";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT pas_primer_apellido FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _apellido = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _apellido;
            }
            catch (SqlException ex)
            {
                return _apellido;
            }
        }

        public String MBuscarcorreopasajero(int id)
        {
            String _correo = "";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT pas_correo FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _correo = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _correo;
            }
            catch (SqlException ex)
            {
                return _correo;
            }
        }

        public CPasajero MBuscarDatosPasajero(int id)
        {
            CPasajero pas = null;
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT * FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["pas_fecha_nacimiento"];
                        DateTime fechanac = Convert.ToDateTime(fecha).Date;
                        pas = new CPasajero (Int32.Parse(reader["pas_id"].ToString()), reader["pas_primer_nombre"].ToString(),
                                             reader["pas_segundo_nombre"].ToString(), reader["pas_primer_apellido"].ToString(),
                                             reader["pas_segundo_apellido"].ToString(), reader["pas_sexo"].ToString(),
                                             fechanac,reader["pas_correo"].ToString());
                    }
                }
                cmd.Dispose();
                con.Close();
                return pas;
            }
            catch (SqlException ex)
            {
                return pas;
            }
        }

        public int M05AgregarBoletoBD(CBoleto boleto)
        {
                return 0;
        }

       public int M05ModificarDatosPasajero(CPasajero pasajero)
       {
           int idaaaa = pasajero._id;
           String va = pasajero._primer_nombre;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "UPDATE Pasajero SET pas_primer_nombre = '"+ pasajero._primer_nombre+"' , pas_segundo_nombre = '" + pasajero._segundo_nombre + "' , pas_primer_apellido = '" + pasajero._primer_apellido +"' , pas_segundo_apellido = '" + pasajero._segundo_apellido + "' , pas_correo = '" + pasajero._correo + "' WHERE pas_id = " + pasajero._id + "";

               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
               return 1;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }

       public CBoleto M05MostrarBoletoBD(int id)
       {
           CBoleto boleto = null;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT * FROM Boleto WHERE bol_id = " + id + "";

               // FALTA OBTENER EL/LOS VUELOS DE ESE BOLETO
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {

                   while (reader.Read())
                   {
                       var fecha = reader["bol_fecha"];
                       List<CVuelo> lista= M05ListarVuelosBoleto(id);
                       CPasajero pasajero = MBuscarDatosPasajero(reader.GetInt32(reader.GetOrdinal("bol_fk_pasajero")));
                       DateTime fechaboleto = Convert.ToDateTime(fecha).Date;

                       boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                              Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())), fechaboleto,
                                              reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                              reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                              reader["bol_tipo_boleto"].ToString());
                       boleto._vuelos = lista;
                       boleto._pasajero = pasajero;
                   }
                   cmd.Dispose();
                   con.Close();
                   return boleto;
               }
           }
           catch (SqlException ex)
           {
               return null;
           }
       }

       public CVuelo MBuscarDatosVuelo(int id)
       {
           CVuelo vuelo = null;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT vue_fecha_despegue, vue_fecha_aterrizaje, vue_fk_ruta FROM Vuelo WHERE vue_id ="+id+"";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       CRuta rut = MBuscarDatosRuta(Int32.Parse(reader["vue_fk_ruta"].ToString()));
                       vuelo = new CVuelo(id, reader.GetDateTime(reader.GetOrdinal("vue_fecha_despegue")),
                                          reader.GetDateTime(reader.GetOrdinal("vue_fecha_aterrizaje")),
                                          Int32.Parse(reader["vue_fk_ruta"].ToString()),
                                          rut._origen, rut._destino, rut._nomOrigen,rut._nomDestino);
                   }
               }
               cmd.Dispose();
               con.Close();
               return vuelo;
           }
           catch (SqlException ex)
           {
               return vuelo;
           }
       }

       public CRuta MBuscarDatosRuta(int id)
       {
           CRuta ruta = null;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT rut_FK_lugar_origen, rut_FK_lugar_destino FROM Ruta WHERE rut_id =" + id + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       ruta = new CRuta(id, Int32.Parse(reader["rut_FK_lugar_origen"].ToString()), Int32.Parse(reader["rut_FK_lugar_destino"].ToString()),
                            MBuscarnombreciudad(Int32.Parse(reader["rut_FK_lugar_origen"].ToString())),
                            MBuscarnombreciudad(Int32.Parse(reader["rut_FK_lugar_destino"].ToString())));
                   }
               }
               cmd.Dispose();
               con.Close();
               return ruta;
           }
           catch (SqlException ex)
           {
               return ruta;
           }
       }

       public String MBuscarTipoBoletoOriginal(int id)
       {
           String tipo = "";
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT bol_tipo_boleto FROM Boleto WHERE bol_id =" + id + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       tipo = reader["bol_tipo_boleto"].ToString();
                   }
               }
               cmd.Dispose();
               con.Close();
               return tipo;
           }
           catch (SqlException ex)
           {
               return tipo;
           }
       }


       public List<CVuelo> M05ListarVuelosBoleto(int id_boleto)
       {
           List<CVuelo> listavuelos = new List<CVuelo>();
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT bol_fk_vuelo FROM Boleto_Vuelo WHERE bol_fk_boleto ="+id_boleto+"";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       CVuelo datosVuelo = MBuscarDatosVuelo(Int32.Parse(reader["bol_fk_vuelo"].ToString()));
                       listavuelos.Add(datosVuelo);
                   }
               }
               cmd.Dispose();
               con.Close();
               int  inte = listavuelos.Count;
               return listavuelos;
           }
           catch (SqlException ex)
           {
               return null;
           }
       }

       public int M05EliminarBoletoBD(int id)
       {
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "DELETE FROM Boleto WHERE bol_id = "+id+"";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                return 0;
            }
        }

       public int MConteoTurista(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num "+
                            "FROM Boleto_Vuelo B, Boleto C "+
                            "WHERE B.bol_fk_vuelo = "+id+
                            " AND C.bol_id = B.bol_fk_boleto "+
                            "AND UPPER(C.bol_tipo_boleto) = UPPER('Turista')";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }

       public int MConteoEjecutivo(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num " +
                            "FROM Boleto_Vuelo B, Boleto C " +
                            "WHERE B.bol_fk_vuelo = " + id +
                            " AND C.bol_id = B.bol_fk_boleto " +
                            "AND UPPER(C.bol_tipo_boleto) = UPPER('Ejecutivo')";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }

       public int MConteoVip(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num " +
                            "FROM Boleto_Vuelo B, Boleto C " +
                            "WHERE B.bol_fk_vuelo = " + id +
                            " AND C.bol_id = B.bol_fk_boleto " +
                            "AND UPPER(C.bol_tipo_boleto) = UPPER('Vip')";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }


       public int MBuscarIdaVuelta(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT bol_ida_vuelta FROM Boleto WHERE bol_id =" + id + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("bol_ida_vuelta")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }

       public int MBuscarCapTurista(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT A.avi_pasajeros_turista num " +
                            "FROM Vuelo V, Avion A " +
                            "WHERE V.vue_id =" +id+
                            " AND V.vue_fk_avion = A.avi_id";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }

       public int MBuscarCapEjecutivo(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT A.avi_pasajeros_ejecutiva num " +
                            "FROM Vuelo V, Avion A " +
                            "WHERE V.vue_id =" + id +
                            " AND V.vue_fk_avion = A.avi_id";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }

       public int MBuscarCapVip(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT A.avi_pasajeros_vip num " +
                            "FROM Vuelo V, Avion A " +
                            "WHERE V.vue_id =" + id +
                            " AND V.vue_fk_avion = A.avi_id";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException ex)
           {
               return _conteo;
           }
       }

       public int M05ModificarTipoBoleto(int id_bol, String tipo)
       {

           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "UPDATE Boleto SET bol_tipo_boleto = '" + tipo + "' WHERE bol_id = " + id_bol +"";

               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
               return 1;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }

       public List<CBoleto> M05ListarBoletosPasajero(int id)
       {
           List<CBoleto> listaboletos = new List<CBoleto>();
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT * FROM Boleto WHERE bol_fk_pasajero = " + id + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       var fecha = reader["bol_fecha"];
                       DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                       CBoleto boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                              Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())),
                                              MBuscarnombrepasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())),
                                              MBuscarapellidopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())), fechaboleto,
                                              Int32.Parse(reader["bol_fk_pasajero"].ToString()), reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                              reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                              reader["bol_tipo_boleto"].ToString(),
                                              MBuscarcorreopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())));
                       listaboletos.Add(boleto);
                   }
               }
               cmd.Dispose();
               con.Close();
               return listaboletos;
           }
           catch (SqlException ex)
           {
               return null;
           }
       }

    } // de la clase
}
