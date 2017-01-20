using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOUsuario : DAO, IDAOUsuario
    {
        public DAOUsuario()
        {
        }

        int IDAO.Agregar(Entidad e)
        {
            Usuario usuario = (Usuario)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                usuario._fechaCreacion = DateTime.Today;
                String sql = "INSERT INTO Usuario VALUES ('" + usuario._nombre + "','" + usuario._apellido + "','" + usuario._correo + "','" + usuario._contrasena + "',1,'" + usuario._fechaCreacion + "','" + usuario._activo + "')";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 5;
            }
        }

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaUsuarios = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);

            try
            {
                conexion.Open();
                String sql = "Select usu_id as idusuario, usu_nombre as nombre , usu_apellido as apellido , usu_correo as correo , rol_nombre as rolnombre, rol_id as idrol, usu_fechacreacion as fecha , usu_activo as activo " +
                     "FROM Usuario, Rol WHERE usu_fk_rol= rol_id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Rol rol;
                    Usuario usuario;
                    int idRol;
                    String nombreRol;
                  

                    int idUsuario;

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        idRol = Int32.Parse(reader["idrol"].ToString());
                        nombreRol = reader["rolnombre"].ToString();
                        rol = new Rol(idRol, nombreRol);

                       idUsuario = Int32.Parse(reader["idusuario"].ToString());

                        usuario = new Usuario(
                            reader["nombre"].ToString(),
                            reader["apellido"].ToString(), 
                            reader["correo"].ToString(),
                            rol,
                            Convert.ToDateTime(reader["fecha"]),
                            reader["activo"].ToString()
                           
                        );
                        listaUsuarios.Add(idUsuario,usuario);
                    
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaUsuarios;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }
    }
}