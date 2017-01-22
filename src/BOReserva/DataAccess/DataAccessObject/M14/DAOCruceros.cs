using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BOReserva.DataAccess.DataAccessObject
{

    /// <summary>
    /// Clase Dao crucceros para realizar los procedimientos de base de datos
    /// </summary>
    public class DAOCruceros : DAO, IDAOCruceros
    {
        public DAOCruceros()
        { }

        bool IDAOCruceros.ValidarCrucero(String nombre) {

            return true;        
        }

        int IDAO.Agregar(Entidad e)
        {
            Crucero crucero = (Crucero)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCrucero", con);

                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@nombrecrucero", crucero._nombreCrucero);
                query.Parameters.AddWithValue("@compania", crucero._companiaCrucero);
                query.Parameters.AddWithValue("@capacidad", crucero._capacidadCrucero);
                query.Parameters.AddWithValue("@imagen", "");
                
                query.ExecuteNonQuery();
                
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();                
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {                
                Debug.WriteLine(ex.ToString());
                con.Close();
                return 0;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Crucero crucero = new Crucero();
            try
            {
                conexion.Open();
                String sql = "SELECT C.* " +
                             "FROM CRUCERO C " +
                             "WHERE C.CRU_ID = " + id;

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    int idCrucero;
                    

                    while (reader.Read())
                    {
                        idCrucero = Int32.Parse(reader["cru_id"].ToString());

                        crucero = new Crucero(id,
                            reader["cru_nombre"].ToString(),
                            reader["cru_compania"].ToString(),
                            Int32.Parse(reader["cru_capacidad"].ToString()),
                            reader["cru_estatus"].ToString()
                        );
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return crucero;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            //List<Crucero> listavehiculos = new List<Crucero>();
            Dictionary<int, Entidad> listaCruceros = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection con = Connection.getInstance(_connexionString);
            Crucero crucero;
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ListarCruceros", con);

                query.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = query.ExecuteReader();
                //int elemento = 0;
                while (reader.Read())
                    {
                        crucero = new Crucero(
                            Int32.Parse(reader["id"].ToString()),
                            reader["nombre"].ToString(),
                            reader["compania"].ToString(),
                            int.Parse(reader["capacidad"].ToString()),
                            reader["estatus"].ToString());
                        listaCruceros.Add(Int32.Parse(reader["id"].ToString()), crucero);
                        //elemento++;
                    }
                    reader.Close();
                    con.Close();
                    return listaCruceros;

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