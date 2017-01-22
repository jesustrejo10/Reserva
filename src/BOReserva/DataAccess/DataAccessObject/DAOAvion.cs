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
    public class DAOAvion : DAO, IDAOAvion
    {
        public DAOAvion() { }

        #region IDAO.Agregar
        /// <summary>
        /// Metodo de DAO para agregar Avion
        /// </summary>
        int IDAO.Agregar(Entidad e)
        {
            Avion avion = (Avion)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Avion VALUES ('" + avion._matricula + "','" + avion._modelo + "'," + avion._capacidadTurista + " , " + avion._capacidadEjecutiva + "," + avion._capacidadVIP + ", " + avion._capacidadEquipaje + ", " + avion._distanciaMaximaVuelo + ", " + avion._velocidadMaxima + ", " + avion._capacidadCombustible + ", 1);";


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
        #endregion

        #region IDAO.Modificar
        /// <summary>
        /// Metodo de DAO para modificar Avion
        /// </summary>
        Entidad IDAO.Modificar(Entidad e)
        {
            Avion avion = (Avion)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "UPDATE Avion SET avi_modelo='" + avion._modelo + "', avi_pasajeros_turista=" + avion._capacidadTurista + ", avi_pasajeros_ejecutiva=" + avion._capacidadEjecutiva + ", avi_pasajeros_vip='" + avion._capacidadVIP + "', avi_cap_equipaje=" + avion._capacidadEquipaje + ", avi_max_dist=" + avion._distanciaMaximaVuelo + ", avi_max_vel=" + avion._velocidadMaxima + ", avi_max_comb=" + avion._capacidadCombustible + " WHERE (avi_matricula='" + avion._matricula + "')";
                /* String sql = "UPDATE Hotel SET hot_nombre = '" + hotel._nombre + "', hot_url_pagina = '" + hotel._paginaWeb +
                            "', hot_email = '" + hotel._email + "', hot_cantidad_habitaciones = '" + hotel._capacidad + "', hot_direccion = '" + hotel._direccion +
                            "', hot_estrellas = " + hotel._clasificacion +
                            " WHERE hot_id = " + hotel._id;*/
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                avion._matricula = "1";
                Entidad resultado = avion;
                return resultado;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                avion._matricula = ex.Message;
                Entidad resultado = avion;
                return resultado;
            }
        }
        #endregion

        #region IDAO.Consultar
        /// <summary>
        /// Metodo de DAO para consultar Avion
        /// </summary>
        Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Avion avion = new Avion();
            try
            {
                conexion.Open();
                //String sql = "SELECT A.*" + 
                //             "FROM Avion A" +  
                //             "WHERE avi_id = " + id;
                String sql = "SELECT avi_id as id, avi_matricula as matricula, avi_modelo as modelo, avi_pasajeros_turista as pturista, avi_pasajeros_ejecutiva as pejecutiva, avi_pasajeros_vip as pvip, avi_cap_equipaje as equipaje, avi_max_dist as maxdistancia, avi_max_vel as maxvelocidad, avi_max_comb as maxcombustible FROM Avion WHERE avi_id = " + id;
                /*String sql = "SELECT H.*, C.lug_id as id_ciudad, C.lug_nombre as nombre_ciudad, P.lug_id as id_pais, P.lug_nombre as nombre_pais " +
                             "FROM HOTEL H, LUGAR C, LUGAR P " +
                             "WHERE H.hot_fk_ciudad = C.lug_id and C.lug_fk_lugar_id = P.lug_id AND H.HOT_ID = " + id;*/

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    /*Pais pais;
                    Ciudad ciudad;
                    int idCiudad;
                    String nombreCiudad;
                    int idPais;
                    String nombrePais;*/

                    int idAvion;
                    /* int capacidad;
                     int clasificacion;
                     String nombreHotel;
                     String direccionHotel;
                     String paginaWebHotel;
                     String emailHotel;*/

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        /*idPais = Int32.Parse(reader["id_pais"].ToString());
                        nombrePais = reader["nombre_pais"].ToString();
                        pais = new Pais(idPais, nombrePais);
                        idCiudad = Int32.Parse(reader["id_ciudad"].ToString());
                        nombreCiudad = reader["nombre_ciudad"].ToString();
                        ciudad = new Ciudad(idCiudad, nombreCiudad, pais);
                        idHotel = Int32.Parse(reader["hot_id"].ToString());*/
                        idAvion = Int32.Parse(reader["id"].ToString());

                        avion = new Avion(
                            idAvion, reader["matricula"].ToString(),
                   reader["modelo"].ToString(), Int32.Parse(reader["pturista"].ToString()),
                   Int32.Parse(reader["pejecutiva"].ToString()), Int32.Parse(reader["pvip"].ToString()),
                   float.Parse(reader["equipaje"].ToString()), float.Parse(reader["maxdistancia"].ToString()),
                   float.Parse(reader["maxvelocidad"].ToString()), float.Parse(reader["maxcombustible"].ToString()));
                        //Int32.Parse(reader["avi_disponibilidad"].ToString()));

                    }
                }
                cmd.Dispose();
                conexion.Close();
                return avion;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }
        #endregion

        #region IDAO.ConsultarTodos
        /// <summary>
        /// Metodo diccionario del DAO para consultar todos los Aviones
        /// </summary>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            List<Avion> listavehiculos = new List<Avion>();
            Dictionary<int, Entidad> listaAviones = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "SELECT A.* FROM Avion A";
                /*String sql = "SELECT H.*, C.lug_id as id_ciudad, C.lug_nombre as nombre_ciudad, P.lug_id as id_pais, P.lug_nombre as nombre_pais " +
                                "FROM HOTEL H, LUGAR C, LUGAR P " +
                                "WHERE H.hot_fk_ciudad = C.lug_id and C.lug_fk_lugar_id = P.lug_id";*/

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    /*Pais pais;
                    Ciudad ciudad;
                    Hotel hotel;
                    int idCiudad;
                    String nombreCiudad;
                    int idPais;
                    String nombrePais;*/
                    Avion avion;

                    int idAvion;
                    /* int capacidad;
                     int clasificacion;
                     String nombreHotel;
                     String direccionHotel;
                     String paginaWebHotel;
                     String emailHotel;*/

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        /* idPais = Int32.Parse(reader["id_pais"].ToString());
                         nombrePais = reader["nombre_pais"].ToString();
                         pais = new Pais(idPais, nombrePais);
                         idCiudad = Int32.Parse(reader["id_ciudad"].ToString());
                         nombreCiudad = reader["nombre_ciudad"].ToString();
                         ciudad = new Ciudad(idCiudad, nombreCiudad, pais);
                         idHotel = Int32.Parse(reader["hot_id"].ToString());*/
                        idAvion = Int32.Parse(reader["avi_id"].ToString());

                        avion = new Avion(
                   idAvion, reader["avi_matricula"].ToString(),
                   reader["avi_modelo"].ToString(),
                   Int32.Parse(reader["avi_pasajeros_turista"].ToString()),
                   Int32.Parse(reader["avi_pasajeros_ejecutiva"].ToString()),
                   Int32.Parse(reader["avi_pasajeros_vip"].ToString()),
                   float.Parse(reader["avi_cap_equipaje"].ToString()),
                   float.Parse(reader["avi_max_dist"].ToString()),
                   float.Parse(reader["avi_max_vel"].ToString()),
                   float.Parse(reader["avi_max_comb"].ToString()),
                   Int32.Parse(reader["avi_disponibilidad"].ToString()));

                        listaAviones.Add(idAvion, avion);



                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaAviones;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }
        #endregion

        #region EliminarAvion
        /// <summary>
        /// Metodo de DAO para eliminar Avion
        /// </summary>
        string IDAOAvion.eliminarAvion(int id)
        //public String EliminarAvion(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "DELETE FROM Avion WHERE avi_id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
            }
        }
        #endregion

        #region disponiblidadAvion
        /// <summary>
        /// Metodo de DAO para cambiar disponibilidad del Avion
        /// </summary>
        public String disponibilidadAvion(Entidad e, int disponibilidad)
        {
            Avion avion = (Avion)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();

                String sql = "UPDATE Avion SET avi_disponibilidad = " + disponibilidad +
                            " WHERE avi_id = " + avion._id;
                /*String sql = "UPDATE Avion SET avi_disponibilidad = " + disponibilidad +
                            " WHERE avi_id = 203";*/
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                avion._matricula = "1";
                Entidad resultado = avion;
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                avion._matricula = ex.Message;
                Entidad resultado = avion;
                return ex.Message;
            }
        }
        #endregion
    }
}