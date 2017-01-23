using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System.Data.SqlClient;
using System;
using BOReserva.Excepciones.M08;

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

        public int obtenerIDlugar(String lugar)
        {
            try
            {
                int id = 0;
                SqlConnection conexion = Conectar();
                conexion.Open();
                String sql = "select lug_id FROM Lugar  where lug_nombre = '" + lugar + "';";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = int.Parse(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return id;
            }
            catch (SqlException ex)
            {
                throw new ReservaExceptionM08(ex.Message, ex);
            }
        }
    }
}