using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class PersistenciaUsuario : ConexionBD
    {
        /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="usuario">Es el objeto que se va a agregar a la BD</param>
        /// <returns>Retorna true si se agrega en la BD</returns>
        public bool AgregarUsuario(CUsuario usuario)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro("@nombre", SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro("@apellido", SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro("@correo", SqlDbType.VarChar, ((CUsuario)usuario).correoUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro("@contraseña", SqlDbType.VarChar, ((CUsuario)usuario).contraseñaUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro("@rol", SqlDbType.Int, ((CUsuario)usuario).rolUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro("@fecha", SqlDbType.Date, ((CUsuario)usuario).fechaCreacionUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro("@activo", SqlDbType.VarChar, ((CUsuario)usuario).activoUsuario, false);
                parametros.Add(parametro);
                List<ResultadoBD> results = EjecutarStoredProcedure("M12_CrearUsuario", parametros);
                Conectar();
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                return true;

        }

        /// <summary>
        /// Método para listar todos los usuarios del BO
        /// </summary>
        /// <returns>Retorna un datatable con la informacion de los usuarios</returns>
        public List<ListarUsuario> ListaUsuarios()
        {
            DataTable resultado;
            ListarUsuario usuario;
            List<ListarUsuario> lista;
            try
            {
                resultado = EjecutarStoredProcedureTuplas("M12_ListarUsuarios");
                Conectar();
                if (resultado != null)
                {
                    lista = new List<ListarUsuario>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        DateTime usuFecha = DateTime.Parse(row["fecha"].ToString());
                        string usuAct = row["activo"].ToString();
                        string usuRol = row["rol"].ToString();
                        string usuApe = row["apellido"].ToString();
                        string usuNom= row["nombre"].ToString();
                        string usuCor = row["correo"].ToString();
                        int usuIDRol = int.Parse(row["rolID"].ToString());
                        int usuID = int.Parse(row["usuID"].ToString());
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
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
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


                parametro = new Parametro( "@id" , SqlDbType.Int , usuID.ToString() , false );
                parametros.Add( parametro );

                List<ResultadoBD> resultado = EjecutarStoredProcedure("M12_EliminarUsuario", parametros);

            }
            catch ( ArgumentNullException ex )
            {
                throw ex;
            }
            catch ( FormatException ex )
            {
                throw ex;
            }
            catch ( SqlException ex )
            {
                throw ex;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

            return true;
            
        }
    }
}