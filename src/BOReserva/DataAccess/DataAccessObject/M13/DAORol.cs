using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M13;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Models.gestion_roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    ///<summary>
    ///Clase DAO del modulo de roles, hereda de DAO e implementa la interfaz IDAORol
    ///</summary>
    public class DAORol: DAO, IDAORol
    {
        ///<summary>
        ///Constructor vacio de la clase DAORol
        ///</summary>
        public DAORol() { }

        ///<summary>
        ///Metodo para agregar un rol a la base de datos
        ///</summary>
        ///<returns>int</returns>
        int IDAO.Agregar(Entidad e)
        {
            Rol rol = (Rol)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.AgregarRol, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", rol._nombreRol);
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
        }

        ///<summary>
        ///Metodo para buscar el id de un rol
        ///</summary>
        ///<returns>String</returns>
        public String MBuscarid_IdRol(String rolBuscar)
        {

            String rolIdDevolver = "";
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT rol_id  FROM Rol WHERE rol_nombre = '" + rolBuscar + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    rolIdDevolver = lector["rol_id"].ToString();

                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return rolIdDevolver;
            }
            catch (Exception e)
            {
                return "error";
            }
        }

        ///<summary>
        ///Metodo para buscar el id de un permiso
        ///</summary>
        ///<returns>String</returns>
        public String MBuscarid_Permiso(String permisoBucar)
        {

            String PermisoIdDevolver = "";
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT mod_det_id  FROM modulo_detallado WHERE mod_det_nombre ='" + permisoBucar + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    PermisoIdDevolver = lector["mod_det_id"].ToString();

                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return PermisoIdDevolver;
            }catch(Exception e)
            {
                return "error";
            }
        }

        ///<summary>
        ///Metodo para agregar permisos a un rol ya existente
        ///</summary>
        ///<returns>Entero</returns>
        public int AgregarRolPermiso(Entidad e)
        {
            Rol rol = (Rol)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                string idRol = "";
                string idPermiso = "";

                //Metodo para que busque el id del rol
                idRol = MBuscarid_IdRol(rol._nombreRol);
                //Metodo para que busque el id del permisos
                idPermiso = MBuscarid_Permiso(rol._nombrePermiso);
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.AgregarPermisoRol, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@idPermiso", idPermiso);
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
        }

        ///<summary>
        ///Metodo para consultar roles
        ///</summary>
        ///<returns>Lista de Entidad</returns>
        public List<Entidad> ConsultarRoles()
        {
            List<Entidad> listaroles;
            Entidad rol;
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
               conexion.Close();
               conexion.Open();
                SqlCommand cmd = new SqlCommand(M13_DAOResources.ConsultarRoles, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listaroles = new List<Entidad>();
                    while (reader.Read())
                    {
                        int _idRol = Int32.Parse(reader["rol_id"].ToString());
                        String _nombreRol = reader["rol_nombre"].ToString();
                        rol = FabricaEntidad.crearRol(_idRol, _nombreRol);
                        listaroles.Add(rol);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaroles;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        ///<summary>
        ///Metodo para consultar permisos
        ///</summary>
        ///<returns>Lista de Entidad</returns>
        public List<Entidad> ConsultarPermisos(int idRol)
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.ConsultarPermisos, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", idRol);
                    cmd.ExecuteNonQuery();
                    listapermisos = new List<Entidad>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int _idPermiso = Int32.Parse(reader["mod_det_id"].ToString());
                        String _nombrePermiso = reader["mod_det_nombre"].ToString();
                        permiso = FabricaEntidad.crearPermiso(_idPermiso, _nombrePermiso);
                        listapermisos.Add(permiso);
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return listapermisos;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        ///<summary>
        ///Metodo para listar los permisos en general
        ///</summary>
        ///<returns>Lista de Entidad</returns>
        public List<Entidad> ListarPermisos()
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Close();
                conexion.Open();

                SqlCommand cmd = new SqlCommand(M13_DAOResources.ListarPermisos, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listapermisos = new List<Entidad>();
                    while (reader.Read())
                    {
                        int _idPermiso = Int32.Parse(reader["mod_det_id"].ToString());
                        String _nombrePermiso = reader["mod_det_nombre"].ToString();
                        permiso = FabricaEntidad.crearPermiso(_idPermiso, _nombrePermiso);
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
        }

        ///<summary>
        ///Metodo para consultar un rol especifico
        ///</summary>
        ///<returns>Entidad</returns>
        Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Rol rol = new Rol();
            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.ConsultarRol, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    String nombreRol;
                    int idRol;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        idRol = Int32.Parse(reader["rol_id"].ToString());
                        nombreRol = reader["rol_nombre"].ToString();

                        rol = new Rol(
                            idRol,
                            reader["rol_nombre"].ToString()
                        );
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return rol;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        ///<summary>
        ///Metodo para modificar el nombre de un rol existente
        ///</summary>
        ///<returns>Entidad</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            Rol rol = (Rol)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "update Rol set rol_nombre = "+ "'"+ rol._nombreRol +"'" + "where rol_id = " + rol._idRol;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                rol._nombreRol = "1";
                Entidad resultado = rol;
                return resultado;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                rol._nombreRol = ex.Message;
                Entidad resultado = rol;
                return resultado;
            }
        }

        ///<summary>
        ///Metodo para eliminar un rol 
        ///</summary>
        ///<returns>String</returns>
        public String eliminarRol(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                eliminarPermiso(id);
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.EliminarRol, conexion))
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
        }

        ///<summary>
        ///Metodo para eliminar permiso a un rol existente
        ///</summary>
        ///<returns>String</returns>
        public String eliminarPermiso(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.EliminarPermisos, conexion))
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
        }

        ///<summary>
        ///Metodo para consultar los permisos asignados a un rol
        ///</summary>
        ///<returns>Lista de Entidad</returns>
        public List<Entidad> consultarLosPermisosAsignados(int id)
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                SqlCommand cmd = new SqlCommand(M13_DAOResources.ConsultarPermisosAsociados, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listapermisos = new List<Entidad>();
                    while (reader.Read())
                    {
                        int _idPermiso = Int32.Parse(reader["mod_det_id"].ToString());
                        String _nombrePermiso = reader["mod_det_nombre"].ToString();
                        permiso = FabricaEntidad.crearPermiso(_idPermiso, _nombrePermiso);
                        listapermisos.Add(permiso);
                    }
                    //cierro el lector
                    reader.Close();
                    //Cerrar la conexion
                    conexion.Close();
                    return listapermisos;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///<summary>
        ///Metodo para consultar los permisos que tiene un usuario
        ///</summary>
        ///<returns>Lista de String</returns>
        public List<String> consultarPermisosUsuario(int idUsuario)
        {
            List<String> listapermisos = new List<String>();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(M13_DAOResources.ConsultarPermisosUsuario, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        Debug.WriteLine("id del usuario nombre " + reader["usu_nombre"].ToString());
                        Debug.WriteLine("id del id rol " + reader["rol_nombre"].ToString());
                        Debug.WriteLine("id del id rol " + reader["mod_det_nombre"].ToString());
                        i += 1;
                        Debug.WriteLine("id del usuario " + i);
                        listapermisos.Add(reader["mod_det_nombre"].ToString());
                    }
                    //cierro el lector
                    reader.Close();
                }
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listapermisos;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }

        }
    }
}