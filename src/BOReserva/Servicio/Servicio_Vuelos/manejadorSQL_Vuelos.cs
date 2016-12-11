using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BOReserva.Models.gestion_vuelo;

namespace BOReserva.Servicio.Servicio_Vuelos
{
    public class manejadorSQL_Vuelos
    {
        //Inicializo el string de conexion en el constructor
        public manejadorSQL_Vuelos()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }
        //Atributo que ejecutara la conexion a la bd
        private SqlConnection conexion = null;
        //string que contendra la conexion a la bd
        private string stringDeConexion = null;


        public int idRutaVuelo( string Origen, string Destino)
        {
            try
            {
                int test = 0;
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("M04_BuscaIdRuta", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;
                cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadDestino"].Value = Destino; 
                
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    test = (int)dr.GetSqlInt32(0);
                }
                //cierro el lector
                dr.Close();
                conexion.Close();
                return test;
            }
            catch (SqlException e)
            {
                throw(e);
                
            }
            catch (Exception e)
            {
                throw (e); 
                
            }

        }

        public List<CCrear_Vuelo> consultarDestinos(String Origen)
        {
            try
            {
                var list = new List<CCrear_Vuelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("M04_BuscarDestinos", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;


                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var destinos = new CCrear_Vuelo
                    {
                        _ciudadDestino = dr.GetSqlString(0).ToString(),
                    };
                    list.Add(destinos);
                }
                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                throw e;
                //return null;
            }
        }



        public List<CCrear_Vuelo> buscarAviones(String Origen, String Destino)
        {
            try
            {
                var list = new List<CCrear_Vuelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("M04_ValidarAvionParaRuta", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;
                cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadDestino"].Value = Destino; 
             


                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var matriculas = new CCrear_Vuelo
                    {
                        _matriculaAvion = dr.GetSqlString(0).ToString(),
                    };
                    list.Add(matriculas);
                }
                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                throw e;
                //return null;
            }
        }


         public List<CCrear_Vuelo> cargarOrigenes()
        {
            try
            {
                var list = new List<CCrear_Vuelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT l.lug_nombre FROM Lugar l WHERE l.lug_tipo_lugar = 'ciudad' ORDER BY l.lug_nombre";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = query.ExecuteReader();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               

                while (dr.Read())
                {
                    var destinos = new CCrear_Vuelo
                    {
                        _ciudadOrigen = dr.GetSqlString(0).ToString(),
                    };
                    list.Add(destinos);
                }
                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                throw e;
                //return null;
            }
        }


         public string modeloAvion(string matriculaAvion)
         {
             try
             {
                 string matri = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Modelo", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                {
                    matri = dr.GetSqlString(0).ToString();
                }
                //cierro el lector
                dr.Close();
                conexion.Close();
                return matri;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }


         public string pasajerosAvion(string matriculaAvion)
         {
             try
             {
                 string matri = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Pasajeros", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     matri = dr.GetSqlString(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return matri;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }

            public string fechaVuelo(string fechaDes, string horaDes, string Origen, string Destino, string matriAvion)
            {
             try
             {
                 string fechaA = "";
                 string fecha = ""+fechaDes+" "+horaDes;
                 int resultado = idRutaVuelo(Origen, Destino);
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("M04_CalcularFechaAterrizaje", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@fechaDespegue", System.Data.SqlDbType.DateTime);
                 cmd.Parameters["@fechaDespegue"].Value = fecha;
                 cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@CiudadOrigen"].Value = Origen;
                 cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@CiudadDestino"].Value = Destino; 
                 cmd.Parameters.Add("@matriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@matriculaAvion"].Value = matriAvion;
                 cmd.Parameters.Add("@idRuta", System.Data.SqlDbType.Int, 100);
                 cmd.Parameters["@idRuta"].Value = resultado;

                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     fechaA = dr.GetSqlDateTime(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return fechaA;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }
         public string distanciaAvion(string matriculaAvion)
         {
             try
             {
                 string dist = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Distancia", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     dist = dr.GetSqlString(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return dist;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }


         public string velocidadAvion(string matriculaAvion)
         {
             try
             {
                 string dist = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Velocidad", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     dist = dr.GetSqlString(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return dist;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }




    }

}
