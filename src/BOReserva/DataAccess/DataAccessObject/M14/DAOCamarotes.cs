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
    public class DAOCamarotes : DAO, IDAOCamarote
    {
        int IDAO.Agregar(Entidad e) {
            Camarote camarote = (Camarote)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCamarote", con);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@cantidad_camas", camarote._cantidadCama);
                query.Parameters.AddWithValue("@tipo_cama", camarote._tipoCama);
                query.Parameters.AddWithValue("@cabina", camarote._nombreCabina);


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

        Dictionary<int, Entidad> IDAOCamarote.ConsultarTodos(int id)
        {
            //List<Crucero> listavehiculos = new List<Crucero>();
            Dictionary<int, Entidad> listaCamarote = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection con = Connection.getInstance(_connexionString);
            Camarote camarote;
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ListarCamarote", con);
                
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@idCabina", id);
                SqlDataReader reader = query.ExecuteReader();
                //int elemento = 0;
                while (reader.Read())
                {
                    camarote = new Camarote(
                        Int32.Parse(reader["id"].ToString()),
                        Int32.Parse(reader["cantidadCama"].ToString()),
                        reader["tipoCama"].ToString(),
                        reader["estatus"].ToString(),
                       reader["nombreCabina"].ToString()+ "-" + Int32.Parse(reader["id"].ToString()));
                    listaCamarote.Add(Int32.Parse(reader["id"].ToString()), camarote);
                    //elemento++;
                }
                reader.Close();
                con.Close();
                return listaCamarote;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                con.Close();
                return null;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            SqlConnection con = Connection.getInstance(_connexionString);
            Camarote Camarote = new Camarote();
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ConsultarCamaroteID", con);

                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();
                SqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    Camarote = new Camarote(id,
                        int.Parse(reader["cam_cantidad_cama"].ToString()),
                        reader["cam_tipo_cama"].ToString(),
                        reader["cam_estatus"].ToString(),
                        reader["cab_nombre"].ToString()
                    );
                }
                reader.Close();
                con.Close();
                return Camarote;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                con.Close();
                return null;
            }
        }

        /// <summary>
        /// Metodo implementado de IDAO para modificar cruceros de la BD
        /// </summary>
        /// <param name="e">Cabina a modificar</param>
        /// <returns>Retorna la Cabina</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            SqlConnection con = Connection.getInstance(_connexionString);
            Camarote camarote = (Camarote)e;

            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_ModificarCamarote", con);

                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("@idCamarote", camarote._id);
                query.Parameters.AddWithValue("@CantidadCama", camarote._cantidadCama);
                query.Parameters.AddWithValue("@TipoCama", camarote._tipoCama);
                query.Parameters.AddWithValue("@EstadoCamarote", camarote._estatus);

                query.ExecuteNonQuery();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
                con.Close();
                return camarote;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}