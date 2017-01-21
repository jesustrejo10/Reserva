using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System.Data.SqlClient;
using System;


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
    }
}