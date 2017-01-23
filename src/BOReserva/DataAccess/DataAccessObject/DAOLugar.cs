using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOLugar : DAO, IDAOLugar
    {
        public DAOLugar() { }

        /*Busca el nombre de una ciudad por el ID*/
        String IDAOLugar.ciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                SqlConnection conexion = Connection.getInstance(_connexionString);
                conexion.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudad = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                return _ciudad;
            }
        }

        List<Entidad> IDAOLugar.buscarCiudades()
        {
            List<Entidad> ciudades = new List<Entidad>();

            string queryString = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";
            
            using (SqlConnection conexion = new SqlConnection(_connexionString))
            using (SqlCommand cmd = new SqlCommand(queryString, conexion))
            {
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            var text = reader.GetString(reader.GetOrdinal("lug_nombre"));
                            var id = reader.GetInt32(reader.GetOrdinal("lug_id"));
                            ciudades.Add(new Lugar(id, text));
                        }

                    }
                }
                conexion.Close();
            }
            return ciudades;
        }
    }
}