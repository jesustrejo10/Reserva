using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    public class DAOHotel:  DAO, IDAOHotel {

        public DAOHotel() {}
        protected Connection _connexion;
        protected String _connexionString = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";






        int IDAO.Agregar(Entidad e)
        {

            Hotel hotel = (Hotel)e;
            SqlConnection conexion = new SqlConnection(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Hotel " +
                                     "(hot_id, hot_nombre, hot_url_pagina, hot_email, hot_cantidad_habitaciones , hot_direccion, hot_estrellas, hot_puntuacion, hot_disponibilidad, hot_fk_ciudad) " +
                                     "VALUES (NEXT VALUE FOR hotel_sequence,'" + hotel._nombre + "','" + hotel._paginaWeb + "','" + hotel._email + "'," +
                                                   hotel._capacidad + ",'" + hotel._direccion + "'," + hotel._clasificacion + ",0,1,15);";


                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
        }

        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Consultar(Entidad e)
        {
            throw new NotImplementedException();
        }
    }
}


/**
 */