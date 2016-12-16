using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BOReserva.Models.gestion_check_in;

namespace BOReserva.Servicio.Servicio_Boletos
{
    public class manejadorSQL_Check
    {
        private SqlConnection conexion = null;
        private string stringDeConexion = "";
            //"Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        private manejadorSQL bd=new manejadorSQL(); 


        public manejadorSQL_Check()
        {
        this.stringDeConexion=bd.stringDeConexions;  
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

       public int CrearBoardingPass(CBoardingPass pase)
       {

           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "INSERT INTO Pase_Abordaje (pas_fk_boleto,pas_fk_asiento, pas_fk_lugar_origen, pas_fk_lugar_destino,pas_fk_vuelo) " +
                   " VALUES (" + pase._boleto + ",'" + pase._asiento + "'," + pase._origen + "," + pase._destino + ","+ pase._vuelo +")";
               
               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
               return 1;
           }
           catch (SqlException ex)
           {
               String hola = ex.ToString();
               return 0;
           }
       }

       public int MConteoBoarding(int num_bol, int num_vue)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num " +
                            "FROM Pase_Abordaje B " +
                            "WHERE B.pas_fk_vuelo = " + num_vue +
                            " AND B.pas_fk_boleto =" + num_bol + "";
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

       public int IdBoardingPass(int num_bol, int num_vue)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT P.pas_id AS id_pase " +
                            "FROM Pase_Abordaje P " +
                            "WHERE P.pas_fk_vuelo = " + num_vue +
                            " AND  P.pas_fk_boleto =" + num_bol + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("id_pase")); ;
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

       public List<CBoardingPass> M05ListarPasesPasajero(int pasaporte)
       {
           List<CBoardingPass> listaboletos = new List<CBoardingPass>();
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT P.pas_id AS numpas, P.pas_fk_lugar_origen AS origen, P.pas_fk_lugar_destino AS destino, P.pas_fk_vuelo AS vuelo" +
                            " FROM Pase_Abordaje P, Boleto B "+
                            " WHERE B.bol_fk_pasajero = "+ pasaporte +
                            " AND P.pas_fk_boleto = B.bol_id";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       CBoardingPass boleto = new CBoardingPass(Int32.Parse(reader["numpas"].ToString()),
                                              MBuscarnombreciudad(Int32.Parse(reader["origen"].ToString())),
                                              MBuscarnombreciudad(Int32.Parse(reader["destino"].ToString())),
                                              Int32.Parse(reader["vuelo"].ToString()));
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

       public int CrearEquipaje(int id, int peso)
       {

           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "INSERT INTO Equipaje (equ_peso,equ_fk_pase_abordaje) " +
                   " VALUES (" + peso + "," + id + ")";

               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
               return 1;
           }
           catch (SqlException ex)
           {
               String hola = ex.ToString();
               return 0;
           }
       }

       public int MConteoMaletas(int pase)
       {
           int _conteo = -1;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num " +
                            " FROM Equipaje  " +
                            " WHERE equ_fk_pase_abordaje = " + pase + "";
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
    }
}
