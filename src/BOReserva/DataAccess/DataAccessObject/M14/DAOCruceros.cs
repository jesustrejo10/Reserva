﻿using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOCruceros : DAO, IDAOCruceros
    {
        public DAOCruceros()
        { }

        bool IDAOCruceros.ValidarCrucero(String nombre) {

            return true;        
        }

        
        int IDAO.Agregar(Entidad e)
        {
            Crucero crucero = (Crucero)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCrucero", con);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nombrecrucero", crucero._nombreCrucero);
                query.Parameters.AddWithValue("@compania", crucero._companiaCrucero);
                query.Parameters.AddWithValue("@capacidad", crucero._capacidadCrucero);
                query.Parameters.AddWithValue("@imagen", "");
                
                /*
                query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = model._tipoRuta;
                query.Parameters.Add("@estadoRuta", SqlDbType.VarChar).Value = model._estadoRuta;
                query.Parameters.Add("@distanciaRuta", SqlDbType.Int).Value = model._distanciaRuta;
                 */

                query.ExecuteNonQuery();
                
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();                
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {                
                Debug.WriteLine(ex.ToString());
                con.Close();
                return 0;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Crucero crucero = new Crucero();
            try
            {
                conexion.Open();
                String sql = "SELECT C.* " +
                             "FROM CRUCERO C " +
                             "WHERE C.CRU_ID = " + id;

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    int idCrucero;
                    

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        idCrucero = Int32.Parse(reader["cru_id"].ToString());

                        crucero = new Crucero(
                            reader["cru_nombre"].ToString(),
                            reader["cru_compania"].ToString(),
                            Int32.Parse(reader["cru_capacidad"].ToString()),
                            reader["cru_estatus"].ToString()
                        );
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return crucero;
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
            List<Crucero> listavehiculos = new List<Crucero>();
            Dictionary<int, Entidad> listaCruceros = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Open();
                String sql = "SELECT C.* " +
                                "FROM CRUCERO C ";

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
                            ciudad,
                            Int32.Parse(reader["hot_disponibilidad"].ToString())
                        );
                        listaCruceros.Add(idHotel, hotel);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaCruceros;
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