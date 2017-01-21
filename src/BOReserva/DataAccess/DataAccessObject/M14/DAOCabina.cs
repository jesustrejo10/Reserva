using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M14;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M14
{
    public class DAOCabina : DAO, IDAOCabina
    {
        int IDAO.Agregar(Entidad e)
        {
            Cabina cabina = (Cabina)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCabinas", con);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nombrecabina", cabina._nombreCabina);
                query.Parameters.AddWithValue("@precio", cabina._precioCabina);
                query.Parameters.AddWithValue("@crucero", cabina._nombreCrucero);
                

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

        Dictionary<int, Entidad> IDAOCabina.ConsultarTodos(int id)
        {
            //List<Crucero> listavehiculos = new List<Crucero>();
            Dictionary<int, Entidad> listaCabinas = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection con = Connection.getInstance(_connexionString);
            Cabina cabina;
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ListarCabinas", con);

                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@idCrucero", id);
                SqlDataReader reader = query.ExecuteReader();
                //int elemento = 0;
                while (reader.Read())
                {
                    cabina = new Cabina(
                        Int32.Parse(reader["id"].ToString()),
                        reader["nombre"].ToString(),
                        float.Parse(reader["precio"].ToString()),
                        reader["estatus"].ToString(),
                        int.Parse(reader["capacidad"].ToString()));
                    listaCabinas.Add(Int32.Parse(reader["id"].ToString()), cabina);
                    //elemento++;
                }
                reader.Close();
                con.Close();
                return listaCabinas;

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