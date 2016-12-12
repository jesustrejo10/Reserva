using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_seguridad_ingreso;

namespace BOReserva.Models.gestion_usuarios
{
    public class PersistenciaUsuario : ConexionBD
    {
        /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="usuario">Es el objeto que se va a agregar a la BD</param>
        /// <returns>Retorna true si se agrega en la BD</returns>
        public  bool AgregarUsuario(CUsuario usuario)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoUsuario.ParametroNombre, SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroApellido, SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroCorreo, SqlDbType.VarChar, ((CUsuario)usuario).correoUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroContraseña, SqlDbType.VarChar, ((CUsuario)usuario).contraseñaUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroRolID, SqlDbType.Int, ((CUsuario)usuario).rolUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroFecha, SqlDbType.Date, ((CUsuario)usuario).fechaCreacionUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroActivo, SqlDbType.VarChar, ((CUsuario)usuario).activoUsuario, false);
                parametros.Add(parametro);
                List<ResultadoBD> results = EjecutarStoredProcedure(RecursoUsuario.CrearUsuario, parametros);
                Conectar();
            }
            catch (ExceptionM12Reserva ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.ArgumentoInvalido, ex);
            }
            catch (FormatException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.FormatoInvalido, ex);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.Error_Email_Existe, ex);
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.BDError, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.OtroError, ex);
            }
                return true;

        }

        /// <summary>
        /// Método para listar todos los usuarios del BO
        /// </summary>
        /// <returns>Retorna una lista con los usuarios</returns>
        public List<ListarUsuario> ListaUsuarios()
        {
            DataTable resultado;
            ListarUsuario usuario;
            List<ListarUsuario> lista;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoUsuario.ListarUsuarios);
                Conectar();
                if (resultado != null)
                {
                    lista = new List<ListarUsuario>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        DateTime usuFecha = DateTime.Parse(row[RecursoUsuario.FechaUsuario].ToString());
                        string usuAct = row[RecursoUsuario.ActivoUsuario].ToString();
                        string usuRol = row[RecursoUsuario.RolUsuario].ToString();
                        string usuApe = row[RecursoUsuario.ApellidoUsuario].ToString();
                        string usuNom= row[RecursoUsuario.NombreUsuario].ToString();
                        string usuCor = row[RecursoUsuario.CorreoUsuario].ToString();
                        int usuIDRol = int.Parse(row[RecursoUsuario.RolIDUsuario].ToString());
                        int usuID = int.Parse(row[RecursoUsuario.IDUsuario].ToString());
                        usuario = new ListarUsuario();
                        usuario._fechaCreacion = usuFecha;
                        usuario._activo = usuAct;
                        usuario._nombre = usuNom;
                        usuario._apellido = usuApe;
                        usuario._rol = usuRol;
                        usuario._id = usuID;
                        usuario._correo = usuCor;
                        lista.Add(usuario);

                    }
                    return lista;
                }
                
            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.ArgumentoInvalido, ex);
            }
            catch (FormatException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.FormatoInvalido, ex);
            }
            catch (SqlException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.BDError, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.OtroError, ex);
            }
            return null;

        }

        /// <summary>
        /// Borrar usuario por el Id de un usuario
        /// </summary>
        /// <param name="usuID">Es el ID del usuario que se va a borrar de la BD</param>
        /// <returns>Retorna true si es elimanado exitosamente</returns>
        public bool eliminarUsuario(int usuID)
        {
            Parametro parametro = new Parametro();
            try
            {
                List<Parametro> parametros = new List<Parametro>();


                parametro = new Parametro( RecursoUsuario.ParametroID , SqlDbType.Int , usuID.ToString() , false );
                parametros.Add( parametro );

                List<ResultadoBD> resultado = EjecutarStoredProcedure(RecursoUsuario.EliminarUsuario, parametros);

            }
            catch ( ArgumentNullException ex )
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.ArgumentoInvalido, ex);
            }
            catch ( FormatException ex )
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.FormatoInvalido, ex);
            }
            catch ( SqlException ex )
            {
                if (ex.Number == 547)
                    throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.Error_Conflicto_FK, ex);
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.BDError, ex);
            }
            catch ( Exception ex )
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.OtroError, ex);
            }

            return true;
            
        }

        /// <summary>
        /// Consultar un usuario por su ID
        /// </summary>
        /// <param name="usuID">Es el ID del usuario que se va a consultar de la BD</param>
        public CUsuario consultarUsuario(int usuID)
        {
            DataTable resultado;
            CUsuario usuario = new CUsuario();
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoUsuario.ParametroID, SqlDbType.Int, usuID.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoUsuario.ConsultarID, parametros);
                Conectar();
                if (resultado != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        string usuAct = row[RecursoUsuario.ActivoUsuario].ToString();
                        string usuRol = row[RecursoUsuario.RolUsuario].ToString();
                        string usuApe = row[RecursoUsuario.ApellidoUsuario].ToString();
                        string usuNom = row[RecursoUsuario.NombreUsuario].ToString();
                        string usuCor = row[RecursoUsuario.CorreoUsuario].ToString();
                        int usuIDRol = int.Parse(row[RecursoUsuario.RolIDUsuario].ToString());
                        usuario.rolUsuario = usuIDRol;
                        usuario.activoUsuario = usuAct;
                        usuario.nombreUsuario = usuNom;
                        usuario.apellidoUsuario= usuApe;
                        usuario.rolSUsuario = usuRol;
                        usuario.idUsuario = usuID;
                        usuario.correoUsuario = usuCor;
                        return usuario;
                    }
                    
                }

            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.ArgumentoInvalido, ex);
            }
            catch (FormatException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.FormatoInvalido, ex);
            }
            catch (SqlException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.BDError, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.OtroError, ex);
            }
            return null;
        }

        /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="usuario">Es el objeto que se va a agregar a la BD</param>
        /// <returns>Retorna true si se agrega en la BD</returns>
        public bool ModificarUsuario(CUsuario usuario, int id)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoUsuario.ParametroNombre, SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroApellido, SqlDbType.VarChar, ((CUsuario)usuario).apellidoUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroCorreo, SqlDbType.VarChar, ((CUsuario)usuario).correoUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroContraseña, SqlDbType.VarChar, ((CUsuario)usuario).contraseñaUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroRolID, SqlDbType.Int, ((CUsuario)usuario).rolUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroActivo, SqlDbType.VarChar, ((CUsuario)usuario).activoUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoUsuario.ParametroID, SqlDbType.Int, id.ToString(), false);
                parametros.Add(parametro);
                List<ResultadoBD> results = EjecutarStoredProcedure(RecursoUsuario.ModificarUsuario, parametros);
                Conectar();
            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.ArgumentoInvalido, ex);
            }
            catch (FormatException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.FormatoInvalido, ex);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.Error_Email_Existe, ex);
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.BDError, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.OtroError, ex);
            }
            return true;
        }

        /// <summary>
        /// Método para consultar usuario por email
        /// </summary>
        /// <param name="email">Email del usuario a consultar</param>
        /// <returns>Retorna true si existe un usuario con este email/returns>
        public CUsuario consultarUsuario(String email)
        {
            DataTable resultado;
            Parametro parametro;
          
            CUsuario usuario = new CUsuario();

            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoUsuario.ParametroCorreo, SqlDbType.VarChar, email, false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoUsuario.ConsultarEmail, parametros);
                Conectar();
                if (resultado != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        
                        string usuAct = row[RecursoUsuario.ActivoUsuario].ToString();
                        string usuRol = row[RecursoUsuario.RolUsuario].ToString();
                        string usuApe = row[RecursoUsuario.ApellidoUsuario].ToString();
                        string usuNom = row[RecursoUsuario.NombreUsuario].ToString();
                        string usuCor = row[RecursoUsuario.CorreoUsuario].ToString();
                        int usuID = int.Parse(row[RecursoUsuario.IDUsuario].ToString());
                        int usuIDRol = int.Parse(row[RecursoUsuario.RolIDUsuario].ToString());
                        usuario.activoUsuario = usuAct;
                        usuario.nombreUsuario = usuNom;
                        usuario.apellidoUsuario = usuApe;
                        usuario.rolUsuario = usuIDRol;
                        usuario.idUsuario = usuID;
                        usuario.correoUsuario = usuCor;
                        return usuario;
                    }
                    
                }

            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.ArgumentoInvalido, ex);
            }
            catch (FormatException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.FormatoInvalido, ex);
            }
            catch (SqlException ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.BDError, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionM12Reserva(RecursoUsuario.ExceptionM12, RecursoUsuario.OtroError, ex);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        
    }
}