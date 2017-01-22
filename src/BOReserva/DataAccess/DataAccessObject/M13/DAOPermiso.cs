using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.M13;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOPermiso : DAO, IDAOPermiso
    {
        ///<summary>
        ///Metodo para agregar un rol a la base de datos
        ///</summary>
        ///<returns>int</returns>
        public new int Agregar(Entidad e)
        {
            Permiso permiso = (Permiso)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.AgregarPermiso, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", permiso.nombrePermiso);
                    cmd.Parameters.AddWithValue("@url", permiso.url);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conexion.Close();
                    return 1;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
        }

        ///<summary>
        ///Metodo para listar los permisos en general
        ///</summary>
        ///<returns>Lista de Entidad</returns>
        public List<Entidad> ConsultarListaPermisos()
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();

                SqlCommand cmd = new SqlCommand(M13_DAOResources.ConsultarListaPermisos, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listapermisos = new List<Entidad>();
                    while (reader.Read())
                    {
                        int _idPermiso = Int32.Parse(reader["mod_det_id"].ToString());
                        String _nombrePermiso = reader["mod_det_nombre"].ToString();
                        String _url = reader["mod_det_url"].ToString();
                        permiso = FabricaEntidad.crearPermiso(_idPermiso, _nombrePermiso, _url);
                        listapermisos.Add(permiso);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listapermisos;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        ///<summary>
        ///Metodo para eliminar un rol 
        ///</summary>
        ///<returns>String</returns>
        public String eliminarPermisoSeleccionado(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.EliminarPermisoSeleccionado, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conexion.Close();
                    return "1";
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return ex.Message;
            }
        }

        ///<summary>
        ///Metodo para eliminar un rol 
        ///</summary>
        ///<returns>String</returns>
        public List<int> validacionPermiso(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            List<int> listaroles;
            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.ValidacionPermiso, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    listaroles = new List<int>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int idRol = Int32.Parse(reader["fk_rol_id"].ToString());
                        listaroles.Add(idRol);
                    }
                    return listaroles;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }
    }
}