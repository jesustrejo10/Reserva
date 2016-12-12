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


        public int idRutaVuelo( CCrear_Vuelo model)
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
                cmd.Parameters["@CiudadOrigen"].Value = "Madrid";
                cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadDestino"].Value = "Caracas"; 
                
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

        public List<CVuelo> MListarvuelosBD()
        {
            List<CVuelo> listavuelo = new List<CVuelo>();
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Vuelo";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VUELO SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla VUELO>"]
                        //Y  SE AGREGA a listavehiculos
                        CVuelo vuelo = new CVuelo(reader["vue_codigo"].ToString(),MBuscarciudadOrigen(Int32.Parse( reader["vue_fk_ruta"].ToString())), MBuscarciudadDestino(Int32.Parse(reader["vue_fk_ruta"].ToString())), reader["vue_fecha_despegue"].ToString(),
                                               reader["vue_status"].ToString(), reader["vue_fecha_aterrizaje"].ToString(), MBuscaravion(Int32.Parse(reader["vue_fk_avion"].ToString()))
                                               );
                        listavuelo.Add(vuelo);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listavuelo;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        public String MBuscarciudadOrigen(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT C.lug_nombre FROM RUTA R, LUGAR C WHERE R.rut_id = '" + id + "' AND R.rut_FK_lugar_origen = C.lug_id" ; ;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                        _ciudad = reader[0].ToString(); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _ciudad;
            }
        }
        public String MBuscarciudadDestino(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT C.lug_nombre FROM RUTA R, LUGAR C WHERE R.rut_id = '" + id + "' AND R.rut_FK_lugar_destino = C.lug_id"; ;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                        _ciudad = reader[0].ToString(); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _ciudad;
            }
        }

        public String MBuscaravion(int id)
        {
            String _avion = "No aplica";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT A.avi_matricula FROM AVION A, LUGAR C WHERE A.avi_id = '" + id + "'"; ;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                        _avion = reader[0].ToString(); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _avion;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _avion;
            }
        }

        public CVuelo MMostrarvueloBD(String codigovuelo)
        {
            CVuelo vuelo = null;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Vuelo WHERE vue_codigo = '" + codigovuelo + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //SE CREA UN OBJECTO VUELO SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                    //Y  SE AGREGA a vehiculo
                    while (reader.Read())
                    {
                        //var fecha = reader["aut_fecharegistro"];
                        //DateTime fecharegistro = Convert.ToDateTime(fecha).Date;
                        vuelo = new CVuelo(reader["vue_codigo"].ToString(), MBuscarciudadOrigen(Int32.Parse(reader["vue_fk_ruta"].ToString())), MBuscarciudadDestino(Int32.Parse(reader["vue_fk_ruta"].ToString())), reader["vue_fecha_despegue"].ToString(),
                                               reader["vue_status"].ToString(), reader["vue_fecha_aterrizaje"].ToString(), MBuscaravion(Int32.Parse(reader["vue_fk_avion"].ToString()))
                                               );
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return vuelo;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }


        public Boolean MDesactivarVuelo(String CodigoVuelo)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("M04_DesactivarVuelo", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodigoVuelo", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CodigoVuelo"].Value = CodigoVuelo;

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
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
    }



}
