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
    public class DAOPasajero : DAO, IDAOPasajero
    {

        public DAOPasajero() { }


        int IDAO.Agregar(Entidad e)
        {
            Pasajero pasajero = (Pasajero)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Pasajero (pas_id,pas_primer_nombre,pas_segundo_nombre,pas_primer_apellido,pas_segundo_apellido,pas_fecha_nacimiento,pas_sexo,pas_correo) VALUES(" + pasajero._id + ",'" + pasajero._primer_nombre + "','" + pasajero._segundo_nombre + "','" + pasajero._primer_apellido + "','" + pasajero._segundo_apellido + "','" + pasajero._fecha_nac.ToString("yyyy/MM/dd") + "','" + pasajero._sexo + "','" + pasajero._correo + "')";

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
            Pasajero pasajero = (Pasajero)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "UPDATE Pasajero SET pas_primer_nombre = '" + pasajero._primer_nombre + "' , pas_segundo_nombre = '" + pasajero._segundo_nombre + "' , pas_primer_apellido = '" + pasajero._primer_apellido + "' , pas_segundo_apellido = '" + pasajero._segundo_apellido + "' , pas_correo = '" + pasajero._correo + "' WHERE pas_id = " + pasajero._id + "";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return pasajero;
            }
            catch (SqlException ex)
            {
                return pasajero;
            }
            throw new NotImplementedException();
        }

        //Entidad IDAO.Consultar(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Dictionary<int, Entidad> IDAO.ConsultarTodos()
        //{
        //    List<Hotel> listavehiculos = new List<Hotel>();
        //    Dictionary<int, Entidad> listaHoteles = new Dictionary<int, Entidad>();
        //    //puedo usar Singleton
        //    SqlConnection conexion = Connection.getInstance(_connexionString);

        //    try
        //    {
        //        conexion.Open();
        //        String sql = "SELECT H.*, C.lug_id as id_ciudad, C.lug_nombre as nombre_ciudad, P.lug_id as id_pais, P.lug_nombre as nombre_pais " +
        //                        "FROM HOTEL H, LUGAR C, LUGAR P " +
        //                        "WHERE H.hot_fk_ciudad = C.lug_id and C.lug_fk_lugar_id = P.lug_id";

        //        SqlCommand cmd = new SqlCommand(sql, conexion);
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            Pais pais;
        //            Ciudad ciudad;
        //            Hotel hotel;
        //            int idCiudad;
        //            String nombreCiudad;
        //            int idPais;
        //            String nombrePais;

        //            int idHotel;
        //            int capacidad;
        //            int clasificacion;
        //            String nombreHotel;
        //            String direccionHotel;
        //            String paginaWebHotel;
        //            String emailHotel;

        //            while (reader.Read())
        //            {
        //                //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
        //                //Y  SE AGREGA a listavehiculos
        //                //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
        //                idPais = Int32.Parse(reader["id_pais"].ToString());
        //                nombrePais = reader["nombre_pais"].ToString();
        //                pais = new Pais(idPais, nombrePais);

        //                idCiudad = Int32.Parse(reader["id_ciudad"].ToString());
        //                nombreCiudad = reader["nombre_ciudad"].ToString();
        //                ciudad = new Ciudad(idCiudad, nombreCiudad, pais);
        //                idHotel = Int32.Parse(reader["hot_id"].ToString());

        //                hotel = new Hotel(
        //                    idHotel,
        //                    reader["hot_nombre"].ToString(),
        //                    reader["hot_direccion"].ToString(),
        //                    reader["hot_email"].ToString(),
        //                    reader["hot_url_pagina"].ToString(),
        //                    Int32.Parse(reader["hot_estrellas"].ToString()),
        //                    Int32.Parse(reader["hot_cantidad_habitaciones"].ToString()),
        //                    ciudad
        //                );
        //                listaHoteles.Add(idHotel, hotel);
        //            }
        //        }
        //        cmd.Dispose();
        //        conexion.Close();
        //        return listaHoteles;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //        conexion.Close();
        //        return null;
        //    }
        //}
    }
}