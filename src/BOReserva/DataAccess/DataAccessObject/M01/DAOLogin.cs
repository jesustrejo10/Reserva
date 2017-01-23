using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.Domain;
using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.Excepciones;
using System.Diagnostics;

namespace BOReserva.DataAccess.DataAccessObject.M01
{
    public class DAOLogin : DAO, IDAOLogin
    {
        private SqlConnection conexion = null;
        private string stringDeConexion = "";

        public DAOLogin()
        {
            this.stringDeConexion = _connexionString;
        }

        #region Metodos convertidos
        /// <summary>
        /// Método que provee la información de un usuario en BD a partir de un correo dado.
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>Una Entidad con la representación completa del usuario encontrado</returns>
        public Entidad Consultar(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            DataTable tablaDeDatos;
            Usuario usuarioSalida = null;
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                //Declaración de entrada para procedimiento almacenado
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoLogin.ConsultarUsuario, listaParametro);

                if (tablaDeDatos.Rows.Count > 1) throw new ExceptionReserva("Reserva-404", "Se esperaba solo una fila", new ArgumentException());
                else if (tablaDeDatos.Rows.Count == 0) throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");

                foreach (DataRow filausuario in tablaDeDatos.Rows) //Solo debería haber uno
                {
                    usuarioSalida = FabricaEntidad.crearUsuario(int.Parse(filausuario[RecursoLogin.usuarioID].ToString()),
                        int.Parse(filausuario[RecursoLogin.usuarioIDRol].ToString()),
                        filausuario[RecursoLogin.usuarioNombre].ToString(),
                        filausuario[RecursoLogin.usuarioApellido].ToString(),
                        filausuario[RecursoLogin.usuarioCorreo].ToString(),
                        filausuario[RecursoLogin.usuarioClave].ToString(),
                        filausuario[RecursoLogin.usuarioFechaCreacion].ToString(),
                        filausuario[RecursoLogin.usuarioActivo].ToString()
                        );
                }
                return usuarioSalida;
            }
            catch (Cvalidar_usuario_Exception ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionReserva("Reserva-404", "Argumento con _idHotel invalido", ex);
            }
            catch (FormatException ex)
            {
                throw new ExceptionReserva("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                throw new ExceptionReserva("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                throw new ExceptionReserva("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw new ExceptionReserva("Reserva-404", "Error al realizar operacion", ex);
            }
        }

        /// <summary>
        /// Método que bloquea a un usuario en la BD luego de suficientes intentos de inicio de sesión.
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>Evalua como True en caso de éxito, SqlException en fallos a la base de datos,
        /// False en cualquier otro caso.</returns>
        public Boolean BloquearUsuario(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            DataTable tablaDeDatos;
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            //Usar M01_BloquearUsuario para reemplazar consulta directa
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoLogin.BloquearUsuario, listaParametro);

                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que incrementa en uno los intentos de inicio de sesión de un usuario.
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>Evalua como True en caso de éxito, False en caso de ocurrir algún problema en la base de datos,
        /// arrojando excepciones de cualquier otro tipo.</returns>
        public Boolean IncrementarIntentos(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                InsertarLogin(usuario); //Chequeo incondicional para intentar insertar login
                EjecutarStoredProcedureTuplas(RecursoLogin.IncrementarIntentos, listaParametro); //Para luego ejecutar el procedimiento
                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Error al incrementar intentos");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que reinicia el número de intentos de inicio de sesión de un usuario.
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>Evalua como True en caso de éxito, False en caso de ocurrir algún problema en la base de datos,
        /// arrojando excepciones de cualquier otro tipo.</returns>
        public Boolean ResetearIntentos(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            DataTable tablaDeDatos;
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoLogin.ResetearIntentos, listaParametro);

                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Error al resetear intentos");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para inserción en tabla Login para usuarios que no lo tengan
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>True cuando hubo éxito en la inserción, False en errores de BD y excepción en cualquier otro caso.</returns>
        public Boolean InsertarLogin(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
                {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                EjecutarStoredProcedureTuplas(RecursoLogin.InsertarLogin, listaParametro); //Para luego ejecutar el procedimiento
                return true;
            }
            catch (ExceptionBD e)
            {
                System.Diagnostics.Debug.WriteLine("Login ya existente");
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al insertar login");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw e;
            }
        }

        /// <summary>
        /// Método para la eliminación de entradas en tabla Login
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>True cuando hubo éxito en la inserción, False en errores de BD y excepción en cualquier otro caso.</returns>
        public Boolean EliminarLogin(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                EjecutarStoredProcedureTuplas(RecursoLogin.EliminarLogin, listaParametro); //Para luego ejecutar el procedimiento
                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Error al eliminar login");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
                //throw e;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al eliminar login");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw e;
            }

        }

        /// <summary>
        /// Método para la consulta de número de intentos de un Login al sistema
        /// </summary>
        /// <param name="_usuario">Representa un objeto Usuario</param>
        /// <returns>Un entero con el número de intentos, 0 en caso de no haber entrada y lanza excepciones de cualquier otro tipo</returns>
        public int NumeroIntentos(Entidad _usuario)
        {
            Usuario usuario = (Usuario)_usuario; //Cast explicito
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                //Se arma lista de parámetros
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                //Para luego ejecutar el procedimiento
                var respuesta = EjecutarStoredProcedureTuplas(RecursoLogin.NumeroIntentos, listaParametro);
                if (respuesta.Rows.Count > 0) //La lista puede retornar vacía, en caso de no existir logins previos, no tenemos nada que hacer en este caso
                {
                    var valor = respuesta.Rows[0].Field<int>(0);
                    return valor;
                }
                else return 0;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Error al consultar número de intentos");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw e;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al consultar número de intentos");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw e;
            }
        }
        #endregion

        #region Métodos por implementar

        public int Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}