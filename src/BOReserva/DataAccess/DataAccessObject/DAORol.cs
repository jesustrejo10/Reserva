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

        public CListaGenerica<CModulo_detallado> consultarPermisos(String modulo)
        {
            CListaGenerica<CModulo_detallado> modulo_detallado = new CListaGenerica<CModulo_detallado>();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try {
                conexion.Close();
                conexion.Open();
                //query es un string que me devolvera la consulta 
                System.Diagnostics.Debug.WriteLine(modulo);
                String query = "SELECT mod_det_nombre,mod_det_url FROM Modulo_Detallado,Modulo_general WHERE mod_gen_id=fk_mod_gen_id and mod_gen_nombre='" + modulo + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CModulo_detallado();
                    entrada.Nombre = lector.GetSqlString(0).ToString();
                    entrada.Url = lector.GetSqlString(1).ToString();
                    modulo_detallado.agregarElemento(entrada);

                }
                //cierro el lector
                lector.Close();
                //Cerrar la conexion
                conexion.Close();
                return modulo_detallado;

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

        public Entidad Consultar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Entidad Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }
    }
}