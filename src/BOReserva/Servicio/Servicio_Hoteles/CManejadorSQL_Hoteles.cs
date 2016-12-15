using BOReserva.Models.gestion_hoteles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.Servicio.Servicio_Hoteles
{
    public class CManejadorSQL_Hoteles
    {
        //Inicializo el string de conexion en el constructor
        public CManejadorSQL_Hoteles()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }
        //Atributo que ejecutara la conexion a la bd
        private SqlConnection conexion = null;
        //string que contendra la conexion a la bd
        private string stringDeConexion = null;


        public int LeerPkHotel()
        {
            Debug.WriteLine("PK");
            int pk = 0;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "select max(hot_id) from Hotel";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                int i = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pk = reader.GetInt32(0);
                        Debug.WriteLine(reader[0].ToString());
                        i++;
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return pk;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 0;
            }
        }

        //Procedimiento del Modulo 9 para agregar hoteles a la base de datos.
        public Boolean insertarHotel(CHotel model)
        {
            int pk = LeerPkHotel() + 1;
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query

                query.CommandText = "INSERT INTO Hotel " +
                                     "(hot_id, hot_nombre, hot_url_pagina, hot_email, hot_cantidad_habitaciones , hot_direccion, hot_estrellas, hot_puntuacion, hot_disponibilidad, hot_fk_ciudad) " +
                                     "VALUES (" + pk.ToString() + ",'" + model._nombre + "','" + model._paginaweb + "','" + model._email + "'," +
                                                   model._canthabitaciones.ToString() + ",'" + model._direccion + "'," + model._estrellas.ToString() + ",0,1,15);";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior              
                SqlDataReader lector = query.ExecuteReader();

                Debug.WriteLine("DEGUG SQL" + lector.ToString());
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                /*while(lector.Read())
                {
                      //COMENTADO PORQUE ESTE METODO NO LO APLICA, SERÁ BORRADO DESPUES
                }*/
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public String[] MListarpaisesBD()
        {
            Debug.WriteLine("SERVICIO");
            String[] listapaises = new String[5000];
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT lug_nombre FROM Lugar WHERE lug_tipo_lugar = 'pais'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                int i = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listapaises[i] = reader[0].ToString();
                        Debug.WriteLine(reader[0].ToString());
                        i++;
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listapaises;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        public String[] MListarciudadesBD(String _pais)
        {
            Debug.WriteLine("CIUDADES");
            String[] listaciudades = new String[5000];
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT A.lug_nombre" +
                             "FROM Lugar A, (SELECT lug_id FROM Lugar " +
                                                                "WHERE lug_nombre = '" + _pais + "') C" +
                             "WHERE A.lug_FK_lugar_id =C.lug_id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                int i = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaciudades[i] = reader[0].ToString();
                        i++;
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaciudades;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }


        public String MBuscarnombrePais(int ciudad)
        {
            String _lugar = "No aplica";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT E.lug_nombre FROM LUGAR E, LUGAR C WHERE E.lug_id = C.lug_fk_lugar_id " +
                             "AND C.lug_id = " + ciudad;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                        _lugar = reader[0].ToString(); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _lugar;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _lugar;
            }
        }

        public String MBuscarnombreciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'"; ;
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


        public List<CHotel> MListarHotelesBD()
        {
            List<CHotel> listahoteles = new List<CHotel>();
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Hotel";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJETO hotel SE PASAN LOS ATRIBUTOS ASI reader["<etiqueta de la columna en la tabla Hotel>"]
                        //Y  SE AGREGA a listavehiculos

                        CHotel hotel = new CHotel(Int32.Parse(reader["hot_id"].ToString()),
                            reader["hot_nombre"].ToString(), 
                            reader["hot_url_pagina"].ToString(), 
                            reader["hot_email"].ToString(),
                            Int32.Parse(reader["hot_cantidad_habitaciones"].ToString()), 
                            reader["hot_direccion"].ToString(), 
                            MBuscarnombreciudad(Int32.Parse(reader["hot_fk_ciudad"].ToString())), 
                            MBuscarnombrePais(Int32.Parse(reader["hot_fk_ciudad"].ToString())), 
                            Int32.Parse(reader["hot_estrellas"].ToString()),
                            float.Parse(reader["hot_puntuacion"].ToString()),
                            Int32.Parse(reader["hot_disponibilidad"].ToString()));
                        listahoteles.Add(hotel);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listahoteles;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        /// <summary>
        /// Procedimiento del Modulo 2 para retornar un objeto del tipo CHotel buscado por su respectiva id
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> CHotel el hotel buscado</returns>
        public CHotel consultarHotel(int id)
        {
            Debug.WriteLine("CONSULTAR HOTEL BD");

            CHotel hotelRetorno = null;

            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Hotel";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                                CHotel hotel = new CHotel(Int32.Parse(reader["hot_id"].ToString()),
                                reader["hot_nombre"].ToString(),
                                reader["hot_url_pagina"].ToString(),
                                reader["hot_email"].ToString(),
                                Int32.Parse(reader["hot_cantidad_habitaciones"].ToString()),
                                reader["hot_direccion"].ToString(),
                                MBuscarnombreciudad(Int32.Parse(reader["hot_fk_ciudad"].ToString())),
                                MBuscarnombrePais(Int32.Parse(reader["hot_fk_ciudad"].ToString())),
                                Int32.Parse(reader["hot_estrellas"].ToString()),
                                float.Parse(reader["hot_puntuacion"].ToString()),
                                Int32.Parse(reader["hot_disponibilidad"].ToString()));
                        hotelRetorno = hotel;
                    }
                }
                cmd.Dispose();
                conexion.Close();
                Debug.WriteLine("HOTEL BUENO");
                return hotelRetorno;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("NULL HOTEL");
                conexion.Close();
                return null;
            }
        }

        public bool deshabilitarHotelBD(int pk_hotel)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();

                //ingreso la orden del query                
                String query = "update Hotel set hot_disponibilidad = 0 where hot_id = " + pk_hotel;
                SqlCommand cmd = new SqlCommand(query, conexion);
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = cmd.ExecuteReader();
                Debug.WriteLine("DEGUG SQL" + lector.ToString());
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool activarHotelBD(int pk_hotel)
        {
          
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();

                //ingreso la orden del query                
                String query = "update Hotel set hot_disponibilidad = 1 where hot_id = " + pk_hotel;
                SqlCommand cmd = new SqlCommand(query, conexion);
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = cmd.ExecuteReader();
                Debug.WriteLine("DEGUG SQL" + lector.ToString());
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public CHotel MMostrarhotelBD(int id)
        {
            CHotel hotelRet = null;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Hotel WHERE hot_id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        CHotel hotel = new CHotel(Int32.Parse(reader["hot_id"].ToString()),
                                reader["hot_nombre"].ToString(),
                                reader["hot_url_pagina"].ToString(),
                                reader["hot_email"].ToString(),
                                Int32.Parse(reader["hot_cantidad_habitaciones"].ToString()),
                                reader["hot_direccion"].ToString(),
                                MBuscarnombreciudad(Int32.Parse(reader["hot_fk_ciudad"].ToString())),
                                MBuscarnombrePais(Int32.Parse(reader["hot_fk_ciudad"].ToString())),
                                Int32.Parse(reader["hot_estrellas"].ToString()),
                                float.Parse(reader["hot_puntuacion"].ToString()),
                                Int32.Parse(reader["hot_disponibilidad"].ToString()));
                        hotelRet = hotel;
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return hotelRet;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        public int MModificarhotelBD(CHotel hotel, int id)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "UPDATE Hotel SET hot_nombre ='" + hotel._nombre + "', hot_url_pagina = '" + hotel._paginaweb + "', hot_email = '" + hotel._email + "', hot_cantidad_habitaciones = " + hotel._canthabitaciones + ", hot_direccion = '" + hotel._direccion + "', hot_estrellas = " + hotel._estrellas + " WHERE hot_id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 0;
            }
        }
    }
}
