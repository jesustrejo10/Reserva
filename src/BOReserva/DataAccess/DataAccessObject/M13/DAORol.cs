using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Models.gestion_roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAORol: DAO, IDAORol
    {
        public DAORol() { }
        int IDAO.Agregar(Entidad e)
        {
            Rol rol = (Rol)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                String sql = "INSERT INTO Rol VALUES ('" + rol._nombreRol + "')";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch(SqlException ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
        }

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
                String sql = "INSERT INTO Rol_Modulo_Detallado VALUES ('" + idRol + "','" + idPermiso + "')"; ;
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
        }

        //public CListaGenerica<CModulo_detallado> consultarPermisos(String modulo)
        //{
        //    CListaGenerica<CModulo_detallado> modulo_detallado = new CListaGenerica<CModulo_detallado>();
        //    SqlConnection conexion = Connection.getInstance(_connexionString);
        //    try {
        //        conexion.Close();
        //        conexion.Open();
        //        //query es un string que me devolvera la consulta 
        //        System.Diagnostics.Debug.WriteLine(modulo);
        //        String query = "SELECT mod_det_nombre,mod_det_url FROM Modulo_Detallado,Modulo_general WHERE mod_gen_id=fk_mod_gen_id and mod_gen_nombre='" + modulo + "'";
        //        SqlCommand cmd = new SqlCommand(query, conexion);
        //        SqlDataReader lector = cmd.ExecuteReader();
        //        //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
        //        while (lector.Read())
        //        {
        //            var entrada = new CModulo_detallado();
        //            entrada.Nombre = lector.GetSqlString(0).ToString();
        //            entrada.Url = lector.GetSqlString(1).ToString();
        //            modulo_detallado.agregarElemento(entrada);

        //        }
        //        //cierro el lector
        //        lector.Close();
        //        //Cerrar la conexion
        //        conexion.Close();
        //        return modulo_detallado;

        //    }
        //    catch (SqlException e)
        //    {
        //        throw e;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public Entidad Consultar(Entidad e)
        {
            throw new NotImplementedException();
        }

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
                String sql = "select r.rol_id, r.rol_nombre from Rol r";

                SqlCommand cmd = new SqlCommand(sql, conexion);
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

        public List<Entidad> ConsultarPermisos(int idRol)
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Close();
                conexion.Open();
                String sql = "select md.mod_det_nombre, md.mod_det_id from Modulo_Detallado md, Rol r, Rol_Modulo_Detallado rmd " +
                    "where md.mod_det_id = rmd.fk_mod_det_id and r.rol_id = rmd.fk_rol_id and r.rol_id =" + idRol;

                SqlCommand cmd = new SqlCommand(sql, conexion);
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

        public List<Entidad> ListarPermisos()
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Close();
                conexion.Open();
                String sql = "select distinct md.mod_det_nombre, md.mod_det_id from Modulo_Detallado md, Rol r, Rol_Modulo_Detallado rmd " +
                    "where md.mod_det_id = rmd.fk_mod_det_id and r.rol_id = rmd.fk_rol_id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
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

        public Entidad ConsultarModulos(int idModulo)
        {
            List<Entidad> listamodulos;
            Entidad modulo;
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Close();
                conexion.Open();
                String sql = "select distinct mg.mod_gen_nombre, mg.mod_gen_id "+
                            "from Modulo_General mg, Modulo_Detallado md, Rol r, Rol_Modulo_Detallado rmd "+
                            "where mg.mod_gen_id = md.fk_mod_gen_id and md.mod_det_id = rmd.fk_mod_det_id and r.rol_id = rmd.fk_rol_id " +
                            "and md.mod_det_id = " + idModulo;

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listamodulos = new List<Entidad>();
                    while (reader.Read())
                    {
                        int _idmodulo = Int32.Parse(reader["mod_gen_id"].ToString());
                        String _nombremodulo = reader["mod_gen_nombre"].ToString();
                        modulo = FabricaEntidad.crearModulo(_idmodulo, _nombremodulo);
                        listamodulos.Add(modulo);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listamodulos[0];
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Rol rol = new Rol();
            try
            {
                conexion.Close();
                conexion.Open();
                String sql = "select r.rol_id, r.rol_nombre from Rol r where r.rol_id = " + id;

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    String nombreRol;
                    int idRol;

                    while (reader.Read())
                    {
                        idRol = Int32.Parse(reader["rol_id"].ToString());
                        nombreRol = reader["rol_nombre"].ToString();

                        rol = new Rol(
                            idRol,
                            reader["rol_nombre"].ToString()
                        );
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return rol;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

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

        public String eliminarRol(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                eliminarPermiso(id);
                conexion.Open();
                String sql = "DELETE FROM Rol WHERE rol_id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
            }
        }

        public String eliminarPermiso(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Close();
                conexion.Open();
                String sql = "DELETE FROM Rol_Modulo_Detallado WHERE fk_rol_id in (SELECT rol_id from Rol where rol_id=" + id + ")";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
            }
        }

        public List<Entidad> consultarLosPermisosAsignados(int id)
        {
            List<Entidad> listapermisos;
            Entidad permiso;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta 
                String query = "SELECT mod_det_nombre, mod_det_id FROM modulo_detallado,rol_modulo_detallado,rol where mod_det_id=fk_mod_det_id and fk_rol_id=rol_id and rol_id=" + id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                listapermisos = new List<Entidad>();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
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
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}