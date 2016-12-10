using FOReserva.Models.Autos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;


namespace FOReserva.Servicio
{

    /*Clase para el manejo Reservas de Automoviles en DB*/
    public class ManejadorSQLReservaAutomovil : manejadorSQL
    {
        public string stringDeConexion;

        public ManejadorSQLReservaAutomovil()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";

        }

        public List<CLugar> buscarCiudades() 
        {
            List<CLugar> ciudades = new List<CLugar>();
            string consulta = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";
            using (SqlConnection connection = new SqlConnection(stringDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, connection))
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
                            ciudades.Add(new CLugar(id.ToString(), text));
                        } 
                     
                    }
                }
                connection.Close();
             }
            
            return ciudades;

           }


    }
}