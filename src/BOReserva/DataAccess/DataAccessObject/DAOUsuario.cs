using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M12;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M12;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    /// <summary>
    /// Clase para el manejo de los usuarios en la BD
    /// </summary>
    public class DAOUsuario : DAO, IDAOUsuario
    {
        /// <summary>
        /// Constructor del metodo
        /// </summary>
        public DAOUsuario()
        {
        }

        /*int IDAO.Agregar(Entidad e)
        {
            Usuario usuario = (Usuario)e;
            
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();

                usuario.fechaCreacionf = DateTime.Now;

                String sql = "INSERT INTO Usuario VALUES ('" + usuario.nombre + "','" + usuario.apellido + "','" + usuario.correo + "','" + usuario.contrasena + "','"+ usuario.rol +"','" + usuario.fechaCreacionf.ToString("yyyy-MM-dd") + "','" + usuario.activo + "')";
                
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
        }*/

        /// <summary>
        /// Ejemplo para los Store Procedure
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int IDAO.Agregar(Entidad e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            Usuario usuario = (Usuario)e;

            try
            {
                usuario.fechaCreacionf = DateTime.Now;
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_nombre, SqlDbType.VarChar, usuario.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_apellido, SqlDbType.VarChar, usuario.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_correo, SqlDbType.VarChar, usuario.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_contraseña, SqlDbType.VarChar, usuario.contrasena, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_fk_rol, SqlDbType.Int, usuario.rol.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_fechaCreacion, SqlDbType.Date, usuario.fechaCreacionf.ToString("yyyy-MM-dd"), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_activo, SqlDbType.VarChar, usuario.activo, false));
                //listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_id, SqlDbType.Int, usuario.id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM12.ProcedimientoAgregarUsuario, listaParametro);
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());

                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());

                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());

                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());

                return 5;
            }
        }

        /*Dictionary<int, Entidad> IDAO.ConsultarTodos()
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
        }*/

        /// <summary>
        /// Metodo implementado de IDAO para consultar los usuarios de la BD
        /// </summary>
        /// <returns>Retorna el listado de usuarios</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaUsuarios = new Dictionary<int, Entidad>();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            Rol rol;
            Usuario usuario;
            int idRol;
            String nombreRol;

            int idUsuario;

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM12.ProcedimientoVisualizarUsuario, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    idRol = Int32.Parse(row[RecursoDAOM12.id_rol].ToString());
                    nombreRol = row[RecursoDAOM12.nombre_rol].ToString();
                    rol = new Rol(idRol, nombreRol);

                    idUsuario = Int32.Parse(row["usu_id"].ToString());
                    usuario = new Usuario(
                            idUsuario,
                            row["usu_nombre"].ToString(),
                            row["usu_apellido"].ToString(),
                            row["usu_correo"].ToString(),
                            row["usu_contraseña"].ToString(),
                            rol,
                            Convert.ToDateTime(row["usu_fechaCreacion"]),
                            row["usu_activo"].ToString()
                            );
                    listaUsuarios.Add(idUsuario, usuario);

                }
                return listaUsuarios;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());

                return null;
            }
        }

        /*Entidad IDAO.Modificar(Entidad e)
        {
            Usuario usuario = (Usuario)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "UPDATE Usuario " +
                                "SET usu_nombre = '"+ usuario.nombre +"', usu_apellido = '"+ usuario.apellido +"', usu_correo = '"+ usuario.correo +"', usu_contraseña = '"+ usuario.contrasena +"', usu_fk_rol = "+ usuario.rol +", usu_activo = '"+ usuario.activo+"' where usu_id = "+ usuario._id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                conexion.Close();
                
                usuario.nombre = "1";
                Entidad resultado = usuario;
                
                return resultado;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                usuario.nombre = ex.Message;
                Entidad resultado = usuario;
                return resultado;
            }
        }*/

        /// <summary>
        /// Metodo implementado de IDAO para modificar usuarios de la BD
        /// </summary>
        /// <param name="e">Usuario a modificar</param>
        /// <returns>Retorna el usuario</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            Usuario usuario = (Usuario)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_nombre, SqlDbType.VarChar, usuario.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_apellido, SqlDbType.VarChar, usuario.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_correo, SqlDbType.VarChar, usuario.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_contraseña, SqlDbType.VarChar, usuario.contrasena, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_fk_rol, SqlDbType.Int, usuario.rol.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_activo, SqlDbType.VarChar, usuario.activo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_id, SqlDbType.Int, usuario._id.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM12.ProcedimientoEditarUsuario, listaParametro);

                usuario.nombre = "1";
                return usuario;
            }
            catch (SqlException ex)
            {
                usuario.nombre = ex.Message;
                Entidad resultado = usuario;
                return resultado;
            }
        }

        /*Entidad IDAO.Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Usuario usuario = new Usuario();
            try
            {
                conexion.Open();
                String sql = "SELECT usu_nombre as nombre, usu_apellido as apellido, usu_correo as email, usu_contraseña as Contraseña, rol_nombre as rol, rol_id as id_rol, usu_activo as status FROM Usuario, Rol WHERE rol_id=usu_fk_rol and usu_id=" + id;

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Rol rol;
                    int idRol;
                    String nombreRol;

                    int idUsuario = id;

                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        //public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
                        idRol = Int32.Parse(reader["id_rol"].ToString());
                        nombreRol = reader["rol"].ToString();
                        rol = new Rol(idRol, nombreRol);


                        usuario = new Usuario(
                            idUsuario,
                            reader["nombre"].ToString(),
                            reader["apellido"].ToString(),
                            reader["email"].ToString(),
                            reader["Contraseña"].ToString(),
                            rol,
                            reader["status"].ToString()
                        );
                    }
                }
                
                cmd.Dispose();
                conexion.Close();
                return usuario;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }*/


        /// <summary>
        /// Metodo implementado de IDAO para consultar un usuario de la BD
        /// </summary>
        /// <param name="id">Id del usuario a buscar</param>
        /// <returns>Retorna el usuario</returns>
        Entidad IDAO.Consultar(int id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            Usuario usuario;
            Rol rol;
            int idRol;
            String nombreRol;

            int idUsuario;

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_id, SqlDbType.Int, id.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM12.ProcedimientoVisualizarUnUsuario, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    idRol = Int32.Parse(row[RecursoDAOM12.id_rol].ToString());
                    nombreRol = row[RecursoDAOM12.nombre_rol].ToString();
                    rol = new Rol(idRol, nombreRol);

                    idUsuario = Int32.Parse(row["usu_id"].ToString());
                    usuario = new Usuario(
                            idUsuario,
                            row["usu_nombre"].ToString(),
                            row["usu_apellido"].ToString(),
                            row["usu_correo"].ToString(),
                            row["usu_contraseña"].ToString(),
                            rol,
                            Convert.ToDateTime(row["usu_fechaCreacion"]),
                            row["usu_activo"].ToString()
                            );

                    return usuario;
                }
                return null;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());

                return null;
            }
        }

        // public String eliminarUsuario(int id)
        /*string IDAOUsuario.eliminarUsuario(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "DELETE FROM Usuario WHERE usu_id = " + id;
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
        }*/

        /// <summary>
        /// Metodo implementado de IDAO para eliminar hoteles de la BD
        /// </summary>
        /// <param name="id">Id del hotel a eliminar</param>
        /// <returns>Retorna un string</returns>
        string IDAOUsuario.eliminarUsuario(int id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_id, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM12.ProcedimientoBorrarUsuario, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {

                return ex.Message;
            }
        }


        /*public String statusUsuario(Entidad e, string status)
        {
            Usuario usuario = (Usuario)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "UPDATE Usuario SET usu_activo = '" + status + "' WHERE usu_id = " + usuario._id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                usuario.nombre = "1";
                Entidad resultado = usuario;
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                usuario.nombre = ex.Message;
                Entidad resultado = usuario;
                return ex.Message;
            }
        }*/


        /// <summary>
        /// Metodo implementado de IDAO para cambiar el status de los usuarios de la BD
        /// </summary>
        /// <param name="e">Usuario a modificar</param>
        /// <param name="disponibilidad">status nuevo</param>
        /// <returns></returns>
        string IDAOUsuario.statusUsuario(Entidad e, string status)
        {
            Usuario usuario = (Usuario)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_activo, SqlDbType.VarChar, status, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM12.usu_id, SqlDbType.Int, usuario._id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM12.ProcedimientoStatusUsuario, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {

                usuario.nombre = ex.Message;
                Entidad resultado = usuario;
                return ex.Message;
            }
        }

    }
}