using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M02;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M02;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOAvion : DAO, IDAOAvion
    {
        public DAOAvion() { }

        #region IDAO.Agregar
        /// <summary>
        /// AgregarAvion para los Store Procedure
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int IDAO.Agregar(Entidad e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            Avion avion = (Avion)e;

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_matricula, SqlDbType.VarChar, avion._matricula, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_modelo, SqlDbType.VarChar, avion._modelo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_pasajeros_turista, SqlDbType.Int, avion._capacidadTurista.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_pasajeros_ejecutiva, SqlDbType.Int, avion._capacidadEjecutiva.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_pasajeros_vip, SqlDbType.Int, avion._capacidadVIP.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_cap_equipaje, SqlDbType.Float, avion._capacidadEquipaje.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_max_dist, SqlDbType.Float, avion._distanciaMaximaVuelo.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_max_vel, SqlDbType.Float, avion._velocidadMaxima.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_max_comb, SqlDbType.Float, avion._capacidadCombustible.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM02.ProcedimientoAgregarAvion, listaParametro);
                return 1;
            }
            catch (SqlException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (Exception ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
        
        }
        #endregion

        #region IDAO.Modificar
        /// <summary>
        /// Metodo de DAO para modificar Avion
        /// </summary>
        Entidad IDAO.Modificar(Entidad e)
        {
            Avion avion = (Avion)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_id, SqlDbType.Int, avion._id.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_matricula, SqlDbType.VarChar, avion._matricula, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_modelo, SqlDbType.VarChar, avion._modelo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_pasajeros_turista, SqlDbType.Int, avion._capacidadTurista.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_pasajeros_ejecutiva, SqlDbType.Int, avion._capacidadEjecutiva.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_pasajeros_vip, SqlDbType.Int, avion._capacidadVIP.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_cap_equipaje, SqlDbType.Float, avion._capacidadEquipaje.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_max_dist, SqlDbType.Float, avion._distanciaMaximaVuelo.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_max_vel, SqlDbType.Float, avion._velocidadMaxima.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_max_comb, SqlDbType.Float, avion._capacidadCombustible.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM02.ProcedimientoModificarAvion, listaParametro);

                avion._matricula = "1";
                return avion;
            }
            catch (SqlException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (Exception ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
        }
        #endregion

        #region IDAO.Consultar
        /// <summary>
        /// Metodo de DAO para consultar Avion
        /// </summary>
        Entidad IDAO.Consultar(int id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            Avion avion;
            int idAvion;

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_id, SqlDbType.Int, id.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM02.ProcedimientoConsultarID, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    idAvion = Int32.Parse(row["id"].ToString());
                    avion = new Avion(
                    idAvion,
                    row["matricula"].ToString(),
                    row["modelo"].ToString(),
                    Int32.Parse(row["pturista"].ToString()),
                    Int32.Parse(row["pejecutiva"].ToString()),
                    Int32.Parse(row["pvip"].ToString()),
                    float.Parse(row["equipaje"].ToString()),
                    float.Parse(row["maxdistancia"].ToString()),
                    float.Parse(row["maxvelocidad"].ToString()),
                    float.Parse(row["maxcombustible"].ToString()));

                    return avion;
                }
                return null;
            }
            catch (SqlException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (Exception ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
        }
        #endregion

        #region IDAO.ConsultarTodos
        /// <summary>
        /// Metodo diccionario del DAO para consultar todos los Aviones
        /// </summary>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaAviones = new Dictionary<int, Entidad>();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            Avion avion;
            int idAvion;

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM02.ProcedimientoConsultarAvion, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    idAvion = Int32.Parse(row["avi_id"].ToString());
                    avion = new Avion(
                    idAvion,
                    row["avi_matricula"].ToString(),
                    row["avi_modelo"].ToString(),
                    Int32.Parse(row["avi_pasajeros_turista"].ToString()),
                    Int32.Parse(row["avi_pasajeros_ejecutiva"].ToString()),
                    Int32.Parse(row["avi_pasajeros_vip"].ToString()),
                    float.Parse(row["avi_cap_equipaje"].ToString()),
                    float.Parse(row["avi_max_dist"].ToString()),
                    float.Parse(row["avi_max_vel"].ToString()),
                    float.Parse(row["avi_max_comb"].ToString()),
                    Int32.Parse(row["avi_disponibilidad"].ToString()));
                    listaAviones.Add(idAvion, avion);

                }
                return listaAviones;
            }
            catch (SqlException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (Exception ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
        }
        #endregion

        #region IDAO.eliminarAvion
        /// </summary>
        string IDAOAvion.eliminarAvion(int id)
        {
            {
                List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

                try
                {
                    listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_id, SqlDbType.Int, id.ToString(), false));
                    EjecutarStoredProcedure(RecursoDAOM02.ProcedimientoEliminarAvion, listaParametro);

                    return "1";
                }
                catch (SqlException ex)
                {
                    return ex.Message;
                }
            }
        }
#endregion

        #region IDAO.disponiblidadAvion
        /// <summary>
        /// Metodo de DAO para cambiar disponibilidad del Avion
        /// </summary>
        string IDAOAvion.disponibilidadAvion(Entidad e,int disponibilidad)
        {
            Avion avion = (Avion)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_id, SqlDbType.Int, avion._id.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM02.avi_disponibilidad, SqlDbType.Int, disponibilidad.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM02.ProcedimientoDisponibilidad, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
            catch (Exception ex)
            {
                try { Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); }

                catch (LogException exi)
                { throw new ReservaExceptionM02(ex.Message, exi); }

                throw new ReservaExceptionM02(ex.Message, ex);
            }
        }
        #endregion
    }
}