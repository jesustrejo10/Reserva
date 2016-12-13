using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using FOReserva.Models.Itinerario;

namespace FOReserva.Servicio
{
    public class ManejadorSQLItinerario
    {
        public string stringDeConexion;

        public ManejadorSQLItinerario()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        private SqlConnection conexion = null;

       

        //Procedimiento del Modulo 5 para buscar las ciudades
        public List<Ciudades> buscarCiudades()
        {
            List<Ciudades> ciudades = new List<Ciudades>();

            string queryString = "SELECT [lug_id], [lug_nombre], [vue_fecha_despegue], [vue_fecha_aterrizaje] FROM [dbo].[Boleto], [dbo].[Lugar], [dbo].[Pasajero], [dbo].[Usuario] , [dbo].[Boleto_Vuelo], [dbo].[Vuelo] WHERE [BOL_FK_LUGAR_DESTINO]=[LUG_ID] AND [BOL_FK_PASAJERO]=[PAS_ID] AND [PAS_CORREO]=[USU_CORREO] AND [BOL_FK_BOLETO]=[BOL_ID] AND [BOL_FK_VUELO] = [VUE_ID] AND [PAS_ID]=4455743 ";
          


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
                           //var fecha = reader.GetDateTime(reader.GetOrdinal("vue_fecha_despegue"));
                         //  var fecha1 = reader.GetDateTime(reader.GetOrdinal("vue_fecha_aterrizaje"));
                           // var fecha = reader["vue_fecha_despegue"] as string;
                            //var fecha1 = reader["vue_fecha_aterrizaje"] as string;
                          

                            ciudades.Add(new Ciudades

                            {
                                Name = text,
                                Id = id.ToString(),
                              // Fecha1=fecha,
                              // Fecha2=fecha1,
                               // Fecha1 = fecha.ToShortDateString(),
                                //Fecha2 = fecha1.ToShortDateString(),
                              
                                
                            });

                        }

                    }
                }
            }
            return ciudades;
        }
        /*public List<Fechas> buscarFechas()
        {
            List<Fechas> fechas = new List<Fechas>();

            string queryString = "SELECT [lug_id],[lug_nombre],[vue_fecha_despegue], [vue_fecha_aterrizaje] FROM [dbo].[Boleto], [dbo].[Lugar], [dbo].[Pasajero], [dbo].[Usuario] , [dbo].[Boleto_Vuelo], [dbo].[Vuelo] WHERE [BOL_FK_LUGAR_DESTINO]=[LUG_ID] AND [BOL_FK_PASAJERO]=[PAS_ID] AND [PAS_CORREO]=[USU_CORREO] AND [BOL_FK_BOLETO]=[BOL_ID] AND [BOL_FK_VUELO] = [VUE_ID] AND [PAS_ID]=4455743 ";



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

                            var fecha = reader.GetDateTime(reader.GetOrdinal("vue_fecha_despegue"));
                            var fecha1 = reader.GetDateTime(reader.GetOrdinal("vue_fecha_aterrizaje"));



                            fechas.Add(new Fechas

                            {
                                Fecha1 = fecha.ToShortDateString(),
                                Fecha2 = fecha1.ToShortDateString(),


                            });

                        }

                    }
                }
            }
            return fechas;
        }*/
    }
}