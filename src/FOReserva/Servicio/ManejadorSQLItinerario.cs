using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace FOReserva.Servicio
{
    public class ManejadorSQLItinerario
    {
        public string stringDeConexion;

        public ManejadorSQLItinerario()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        //Procedimiento del Modulo 5 para buscar las ciudades
        public List<Ciudades> buscarCiudades()
        {
            List<Ciudades> ciudades = new List<Ciudades>();



            string queryString = "SELECT [lug_id], [lug_nombre] FROM [dbo].[Boleto], [dbo].[Lugar], [dbo].[Pasajero], [dbo].[Usuario] WHERE [BOL_FK_LUGAR_DESTINO]=[LUG_ID] AND [BOL_FK_PASAJERO]=[PAS_ID] AND [PAS_CORREO]=[USU_CORREO] AND [PAS_ID]=4455743 UNION SELECT [lug_id], [lug_nombre] FROM [dbo].[Lugar], [dbo].[Pasajero], [dbo].[Usuario], [dbo].[Ruta], [dbo].[Reserva_Crucero] WHERE [FK_PASAJERO]=[PAS_ID] AND [PAS_CORREO]=[USU_CORREO] AND [FK_RUTA]=[RUT_ID] AND [RUT_FK_LUGAR_DESTINO]=[LUG_ID] AND [PAS_ID]=4455743";



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
                           /*var fecha1 = reader.GetDataTypeName(reader.GetOrdinal("bol_fecha_partida"));
                            var fecha2 = reader.GetDataTypeName(reader.GetOrdinal("bol_fecha_llegada"));
                            */
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