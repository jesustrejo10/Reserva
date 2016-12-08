using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace BOReserva.Servicio.Servicio_Boletos
{
    public class manejadorSQL_Boletos
    {
         public string stringDeConexion;

        public manejadorSQL_Boletos()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        //Procedimiento del Modulo 5 para buscar las ciudades
        public List<Ciudades> buscarCiudades()
        {
            List<Ciudades> ciudades = new List<Ciudades>(); 
           
            string queryString = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";

            using (SqlConnection connection = new SqlConnection(stringDeConexion))
            using (SqlCommand cmd = new SqlCommand(queryString, connection))
            {
                connection.Open();
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
                            ciudades.Add(new Ciudades
                            {
                                Name = text,
                                Id = id.ToString()
                            });
                          
                        } 
                     
                    }
                }
            }
            return ciudades;
            }
        
    }
}