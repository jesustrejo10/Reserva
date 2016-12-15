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

        public int M05AgregarBoletoBD(CBoleto boleto)
        {
                return 0;         
        }

       public int M05ModificarBoletoBD(CBoleto boleto)
       {
            return 0;
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
                       DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                       boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                              Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())),
                                              MBuscarnombrepasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())),
                                              MBuscarapellidopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())), fechaboleto,
                                              Int32.Parse(reader["bol_fk_pasajero"].ToString()), reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                              reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                              reader["bol_tipo_boleto"].ToString(),
                                              MBuscarcorreopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())));
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
    }
}