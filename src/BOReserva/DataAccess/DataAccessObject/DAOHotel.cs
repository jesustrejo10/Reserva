using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOHotel : DAO, IDAOHotel
    {

        public DAOHotel() { }


        int IDAO.Agregar(Entidad e)
        {
            Hotel hotel = (Hotel)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Hotel " +
                                     "(hot_id, hot_nombre, hot_url_pagina, hot_email, hot_cantidad_habitaciones , hot_direccion, hot_estrellas, hot_puntuacion, hot_disponibilidad, hot_fk_ciudad) " +
                                     "VALUES (NEXT VALUE FOR hotel_sequence,'" + hotel._nombre + "','" + hotel._paginaWeb + "','" + hotel._email + "'," +
                                                   hotel._capacidad + ",'" + hotel._direccion + "'," + hotel._clasificacion + ",0,1," + hotel._ciudad._id + ");";


                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 5;
            }
        }

        Entidad IDAO.Modificar(Entidad e)
        {
            Hotel hotel = (Hotel)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "UPDATE Hotel SET hot_nombre = '" + hotel._nombre + "', hot_url_pagina = '" + hotel._paginaWeb +
                            "', hot_email = '" + hotel._email + "', hot_cantidad_habitaciones = '" + hotel._capacidad + "', hot_direccion = '" + hotel._direccion +
                            "', hot_estrellas = " + hotel._clasificacion +
                            " WHERE hot_id = " + hotel._id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                hotel._nombre = "1";
                Entidad resultado = hotel;
                return resultado;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                hotel._nombre = ex.Message;
                Entidad resultado = hotel;
                return resultado;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Hotel hotel = new Hotel();
            try
            {
                conexion.Open();
                String sql = "SELECT H.*, C.lug_id as id_ciudad, C.lug_nombre as nombre_ciudad, P.lug_id as id_pais, P.lug_nombre as nombre_pais " +
                             "FROM HOTEL H, LUGAR C, LUGAR P " +
                             "WHERE H.hot_fk_ciudad = C.lug_id and C.lug_fk_lugar_id = P.lug_id AND H.HOT_ID = "+ id;

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Pais pais;
                    Ciudad ciudad;
                    int idCiudad;
                    String nombreCiudad;
                    int idPais;
                    String nombrePais;

                    int idHotel;
                    int capacidad;
                    int clasificacion;
                    String nombreHotel;
                    String direccionHotel;
                    String paginaWebHotel;
                    String emailHotel;

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        idPais = Int32.Parse(reader["id_pais"].ToString());
                        nombrePais = reader["nombre_pais"].ToString();
                        pais = new Pais(idPais, nombrePais);

                        idCiudad = Int32.Parse(reader["id_ciudad"].ToString());
                        nombreCiudad = reader["nombre_ciudad"].ToString();
                        ciudad = new Ciudad(idCiudad, nombreCiudad, pais);
                        idHotel = Int32.Parse(reader["hot_id"].ToString());

                        hotel = new Hotel(
                            idHotel,
                            reader["hot_nombre"].ToString(),
                            reader["hot_direccion"].ToString(),
                            reader["hot_email"].ToString(),
                            reader["hot_url_pagina"].ToString(),
                            Int32.Parse(reader["hot_estrellas"].ToString()),
                            Int32.Parse(reader["hot_cantidad_habitaciones"].ToString()),
                            ciudad
                        );
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return hotel;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            List<Hotel> listavehiculos = new List<Hotel>();
            Dictionary<int, Entidad> listaHoteles = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Open();
                String sql = "SELECT H.*, C.lug_id as id_ciudad, C.lug_nombre as nombre_ciudad, P.lug_id as id_pais, P.lug_nombre as nombre_pais " +
                                "FROM HOTEL H, LUGAR C, LUGAR P " +
                                "WHERE H.hot_fk_ciudad = C.lug_id and C.lug_fk_lugar_id = P.lug_id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Pais pais;
                    Ciudad ciudad;
                    Hotel hotel;
                    int idCiudad;
                    String nombreCiudad;
                    int idPais;
                    String nombrePais;

                    int idHotel;
                    int capacidad;
                    int clasificacion;
                    String nombreHotel;
                    String direccionHotel;
                    String paginaWebHotel;
                    String emailHotel;

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        idPais = Int32.Parse(reader["id_pais"].ToString());
                        nombrePais = reader["nombre_pais"].ToString();
                        pais = new Pais(idPais, nombrePais);

                        idCiudad = Int32.Parse(reader["id_ciudad"].ToString());
                        nombreCiudad = reader["nombre_ciudad"].ToString();
                        ciudad = new Ciudad(idCiudad, nombreCiudad, pais);
                        idHotel = Int32.Parse(reader["hot_id"].ToString());

                        hotel = new Hotel(
                            idHotel,
                            reader["hot_nombre"].ToString(),
                            reader["hot_direccion"].ToString(),
                            reader["hot_email"].ToString(),
                            reader["hot_url_pagina"].ToString(),
                            Int32.Parse(reader["hot_estrellas"].ToString()),
                            Int32.Parse(reader["hot_cantidad_habitaciones"].ToString()),
                            ciudad
                        );
                        listaHoteles.Add(idHotel, hotel);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaHoteles;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }
    }
}