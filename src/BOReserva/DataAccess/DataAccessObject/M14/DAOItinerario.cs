﻿using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M14;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M14
{
    public class DAOItinerario : DAO, IDAOItinerario
    {

        /// <summary>
        /// Clase Dao itinerario para realizar los procedimientos de base de datos
        /// </summary>

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            //List<Crucero> listavehiculos = new List<Crucero>();
            Dictionary<int, Entidad> listaItinerario = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection con = Connection.getInstance(_connexionString);
            Itinerario itinerario;
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ListarItinerario", con);

                query.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = query.ExecuteReader();
                //int elemento = 0;
                while (reader.Read())
                {
                    itinerario = new Itinerario(
                        Int32.Parse(reader["id"].ToString()),
                        Convert.ToDateTime(reader["fechaInicio"].ToString()),
                        Convert.ToDateTime(reader["fechaFin"].ToString()),
                        reader["estatus"].ToString(),
                        reader["ruta"].ToString(),
                        reader["nombreCrucero"].ToString());
                    listaItinerario.Add(Int32.Parse(reader["id"].ToString()), itinerario);
                    //elemento++;
                }
                reader.Close();
                con.Close();
                return listaItinerario;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                con.Close();
                return null;
            }
        }



        Dictionary<int, Entidad> IDAOItinerario.ConsultarRutasCrucero()
        {
            
            Dictionary<int, Entidad> listaRuta = new Dictionary<int, Entidad>();            
            SqlConnection con = Connection.getInstance(_connexionString);
            Ruta ruta;
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ListarRutas", con);

                query.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = query.ExecuteReader();
                //int elemento = 0;
                while (reader.Read())
                {
                    ruta = new Ruta(
                        reader["origen"].ToString(),                        
                        reader["destino"].ToString(),                        
                        reader["tipo_ruta"].ToString(),
                        reader["estatus"].ToString(),
                        Int32.Parse(reader["distancia"].ToString()),
                        Int32.Parse(reader["id"].ToString()));
                    listaRuta.Add(Int32.Parse(reader["id"].ToString()), ruta);
                    //elemento++;
                }
                reader.Close();
                con.Close();
                return listaRuta;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                con.Close();
                return null;
            }
        }

        

    }
}