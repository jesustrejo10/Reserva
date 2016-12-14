using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using FOReserva.Models.Cruceros;

namespace FOReserva.Servicio
{
    public class manejadorSQLCrucero
    {
         public string stringDeConexion;

        public manejadorSQLCrucero()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        //Procedimiento del Modulo 5 para buscar las ciudades
        public List<Cruceros> buscarCruceros()
        {
            List<Cruceros> cruceros = new List<Cruceros>(); 
           
            string queryString = "SELECT [cru_id] ,[cru_nombre] FROM [dbo].[Crucero]";

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
                            var text = reader.GetString(reader.GetOrdinal("cru_nombre"));
                            var id = reader.GetInt32(reader.GetOrdinal("cru_id"));
                            cruceros.Add(new Cruceros
                            {
                                id = id.ToString(),
                                Name = text
                            });
                        } 
                     
                    }
                }
            }
            return cruceros;
            }

        
    }
}