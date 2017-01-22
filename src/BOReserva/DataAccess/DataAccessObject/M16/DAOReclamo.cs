using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M16;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones.M16;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace BOReserva.DataAccess.DataAccessObject
{
    /// <summary>
    /// Clase encargada de las consultas a BD por parte del M16 
    /// </summary>
    public class DAOReclamo : DAO, IDAOReclamo
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public DAOReclamo() {}

        /// <summary>
        /// Metodo para hacer el insert de un reclamo en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>Integer con el codigo de respuesta</returns>
        int IDAO.Agregar(Entidad e)
        {
            Reclamo reclamo = (Reclamo)e;
            reclamo._estadoReclamo = 1;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_titulo, SqlDbType.VarChar, reclamo._tituloReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_descripcion, SqlDbType.VarChar, reclamo._detalleReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_estatus, SqlDbType.Int, reclamo._estadoReclamo.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fk_usuario, SqlDbType.Int, reclamo._usuario.ToString(), false));

                EjecutarStoredProcedure(M16Reclamos.procedimientoAgregarReclamo, listaParametro);
                return 1;
            }
            catch (SqlException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex); 
            }
            catch (ArgumentNullException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para consultar un reclamo en la BD
        /// </summary>
        /// <param name="id">id del reclamo</param>
        /// <returns> reclamo </returns>
        Entidad IDAO.Consultar(int id)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            int rec_id, rec_estatus, rec_fk_usuario;
            String rec_titulo, rec_descripcion, rec_fecha;
            Entidad reclamoE = FabricaEntidad.InstanciarReclamo();
            Reclamo reclamo = (Reclamo)reclamoE;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, id.ToString(), false));
                DataTable filaReclamo = EjecutarStoredProcedureTuplas(M16Reclamos.procedimientoConsultarReclamoPorId, parametro);
                DataRow Fila = filaReclamo.Rows[0];

                rec_id = int.Parse(Fila[M16Reclamos.recId].ToString());
                rec_estatus = int.Parse(Fila[M16Reclamos.recEstatus].ToString());
                rec_fk_usuario = int.Parse(Fila[M16Reclamos.recFkUsuario].ToString());
                rec_titulo = Fila[M16Reclamos.rectitulo].ToString();
                rec_descripcion = Fila[M16Reclamos.recDescripcion].ToString();
                String[] divisor = Fila[M16Reclamos.recFecha].ToString().Split(' ');
                rec_fecha = divisor[0];
                reclamo = (Reclamo)FabricaEntidad.InstanciarReclamo(rec_id, rec_titulo, rec_descripcion, rec_fecha, rec_estatus, rec_fk_usuario);

                return reclamo;
            }
            catch (SqlException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para modificar un reclamo
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>retorna el reclamo</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            Reclamo reclamo = (Reclamo)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_titulo, SqlDbType.VarChar, reclamo._tituloReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_descripcion, SqlDbType.VarChar, reclamo._detalleReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, reclamo._id.ToString(), false));
                EjecutarStoredProcedure(M16Reclamos.procedimientoModificarReclamo, listaParametro);
                return reclamo;
            }
            catch (SqlException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para consultar todos los reclamos en la BD
        /// </summary>
        /// <returns> Lista de reclamos</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            List<Reclamo> listareclamos = new List<Reclamo>();
            Dictionary<int, Entidad> listaReclamos = new Dictionary<int, Entidad>();
            SqlConnection conexion = Connection.getInstance(_connexionString);

            List<Reclamo> reclamos = FabricaEntidad.InstanciarListaReclamo();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            DataTable tablaDeDatos;
            int rec_id, rec_estatus, rec_fk_usuario;
            String rec_titulo, rec_descripcion, rec_fecha;
            int placeholder = 0;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, placeholder.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(M16Reclamos.procedimientoConsultarReclamos, parametro);
                foreach (DataRow filaReclamo in tablaDeDatos.Rows)
                {
                    rec_id = int.Parse(filaReclamo[M16Reclamos.recId].ToString());
                    rec_estatus = int.Parse(filaReclamo[M16Reclamos.recEstatus].ToString());
                    rec_fk_usuario = int.Parse(filaReclamo[M16Reclamos.recFkUsuario].ToString());
                    rec_titulo = filaReclamo[M16Reclamos.rectitulo].ToString();
                    rec_descripcion = filaReclamo[M16Reclamos.recDescripcion].ToString();
                    String[] divisor = filaReclamo[M16Reclamos.recFecha].ToString().Split(' ');
                    rec_fecha = divisor[0];
                    Reclamo reclamo = (Reclamo)FabricaEntidad.InstanciarReclamo(rec_id, rec_titulo, rec_descripcion, rec_fecha, rec_estatus, rec_fk_usuario);
                    listaReclamos.Add(rec_id, reclamo);
                }
                return listaReclamos;
            }
            catch (SqlException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
        }
           
        /// <summary>
        /// Método para eliminar reclamo 
        /// </summary>
        /// <param name="id">id del reclamo</param>
        /// <returns>retorna 1 si eliminó correctamente</returns>
        public int Eliminar(int id)
        {
            try
            {
                List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(M16Reclamos.procedimientoEliminarReclamo, parametro);
                return 1;
            }
            catch (SqlException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para actualizar el estado de un reclamo
        /// </summary>
        /// <param name="id"> recibe el id del reclamo</param>
        /// <param name="estado">recibe el estado del reclamo</param>
        /// <returns>retorna un entero</returns>
        public int modificarEstado(int id, int estado)
        {
            try
            {
                List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, id.ToString(), false));
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_estatus, SqlDbType.Int, estado.ToString(), false));
                EjecutarStoredProcedure(M16Reclamos.procedimientoActualizarReclamo, parametro);
                return 1;
            }
            catch (SqlException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM16(ex.Message, ex);
            }
        }
      
    }

}