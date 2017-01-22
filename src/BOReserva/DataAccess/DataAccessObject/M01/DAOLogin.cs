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
                throw new ExceptionReserva("Reserva-404", "Argumento con valor invalido", ex);
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
            int filasAfectadas;
            List<Model.Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoLogin.correo, SqlDbType.VarChar, usuario.correo.ToString(), false));

                filasAfectadas = EjecutarStoredProcedureTuplasFilasAfectadas(RecursoLogin.IncrementarIntentos, listaParametro);

                if (filasAfectadas < 1)
                {
                    InsertarLogin(usuario.correo);
                    EjecutarStoredProcedureTuplasFilasAfectadas(RecursoLogin.IncrementarIntentos, listaParametro);
                }
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
        #endregion

        #region Métodos por convertir

        public Cgestion_seguridad_ingreso UsuarioEnBD(String usuario)
        {
            //Usar M01_ConsultarUsuario para reemplazar consulta directa
            String usuarioBD = "", nombreBD = "", apellidoBD = "", claveBD = "", statusBD = "";
            int idUsuario = 0, rolUsuario = 0;
            try
            {
                Conectar();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //SqlCommand cmd = new SqlCommand("Select usu_correo, usu_nombre, usu_apellido ,usu_contraseña, usu_activo from Usuario where usu_correo like @usu_correo AND usu_fk_rol IS NOT NULL", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlCommand cmd = new SqlCommand("Select usu_correo, usu_nombre, usu_apellido ,usu_contraseña, usu_activo, usu_id, usu_fk_rol from Usuario where usu_correo like @usu_correo AND usu_fk_rol NOT BETWEEN 2 AND 3", conexion);
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    usuarioBD = lector.GetString(0);
                    nombreBD = lector.GetString(1);
                    apellidoBD = lector.GetString(2);
                    claveBD = lector.GetString(3);

                    System.Diagnostics.Debug.WriteLine("Correo " + usuarioBD + " contrasena " + claveBD);

                    statusBD = lector.GetString(4);
                    idUsuario = lector.GetInt32(5);
                    rolUsuario = lector.GetInt32(6);

                }
                lector.Close();
                conexion.Close();
                return new Cgestion_seguridad_ingreso(usuarioBD, claveBD, nombreBD, apellidoBD, statusBD, idUsuario, rolUsuario);
            }
            catch (SqlException e)
            {
                throw e;
                //  return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Boolean BloquearUsuario(String usuario)
        {
            //Usar M01_BloquearUsuario para reemplazar consulta directa
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Update Usuario set usu_activo='Inactivo' where usu_correo like @usu_correo", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
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

        public Boolean InsertarLogin(String usuario)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Insert into Login(log_idusuario,log_sesion,log_intentos) values((Select usu_id from Usuario where usu_correo like @usu_correo),0,0);", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
                throw e;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Boolean EliminarLogin(String usuario)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("DELETE from Login WHERE log_idusuario=1", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
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

        public Boolean IncrementarIntentos(String usuario)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Update Login set log_intentos=log_intentos+1 where log_idusuario=(Select usu_id from Usuario where usu_correo like @usu_correo)", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;              
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                if (cmd.ExecuteNonQuery() < 1)
                {
                    InsertarLogin(usuario);
                    cmd.ExecuteNonQuery();
                }
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("El error esta en incrementar intentos");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean ResetearIntentos(String usuario)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Update Login set log_intentos=0 where log_idusuario=(Select usu_id from Usuario where usu_correo like @usu_correo)", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;              
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
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

        public int NumeroIntentos(String usuario)
        {
            int intentos = 0;
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select log_intentos from Login where log_idusuario=(Select usu_id from Usuario where usu_correo like @usu_correo)", conexion);
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                if (cmd.ExecuteScalar() == null)
                {
                    InsertarLogin(usuario);
                }
                else
                    intentos = Convert.ToInt32(cmd.ExecuteScalar());
                System.Diagnostics.Debug.WriteLine(intentos);
                conexion.Close();
                return intentos;
            }
            catch (SqlException e)
            {
                throw e;
                // return -1;
            }
            catch (Exception e)
            {
                return -1;
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

        #region Metodos Auxiliares

        public int EjecutarStoredProcedureTuplasFilasAfectadas(string query, List<Parametro> parametros)
        {
            SqlCommand comando;
            try
            {
                Conectar();
                DataTable dataTable = new DataTable();
                using (conexion)
                {

                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    AsignarParametros(parametros);
                    conexion.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                    {
                        return dataAdapter.Fill(dataTable);
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
            }
            finally
            {
                Desconectar();
            }

        }
        #endregion
    }
}