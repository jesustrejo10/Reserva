using BOReserva.DataAccess.DataAccessObject.M04;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Excepciones.M04;
using BOReserva.Excepciones;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOVuelo : DAO, IDAOVuelo, IDAO
    {
        #region override DAO
        /// <summary>
        /// Metodo para ejecutar un procedimiento almacenado en la bd que devuelve un DataTable
        /// </summary>
        /// <param name="parametros">Lista de parametros que se le va a asociar</param>
        /// <param name="query">Cadena con el query a ejecutar</param>
        public new DataTable EjecutarStoredProcedureTuplas(string query, List<Parametro> parametros)
        {
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
                        dataAdapter.Fill(dataTable);
                        System.Diagnostics.Debug.WriteLine(dataAdapter);
                        System.Diagnostics.Debug.WriteLine(dataTable);
                    }

                    return dataTable;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
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
        /// <summary>
        /// Agrega una entidad vuelo en la bd
        /// </summary>
        /// <param name="vuelo">Entidad a agregar</param>
        /// <returns>uno si se agrego correctamente</returns>
        public int Agregar(Entidad vuelo)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroCodVuelo, SqlDbType.VarChar, ((Vuelo)vuelo).CodigoVuelo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroIdRuta, SqlDbType.Int, ((Vuelo)vuelo).getRuta._idRuta.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroFechaDespegue, SqlDbType.DateTime, ((Vuelo)vuelo).FechaDespegue.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroFechaAterrizaje, SqlDbType.DateTime, ((Vuelo)vuelo).FechaAterrizaje.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroStatus, SqlDbType.VarChar, ((Vuelo)vuelo).StatusVuelo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroIdAvion, SqlDbType.Int, ((Vuelo)vuelo).getAvion._id.ToString(), false);
                parametros.Add(parametro);
                List<ResultadoBD> results = EjecutarStoredProcedure(RecursoVuelo.CrearVuelo, parametros);
                Conectar();
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return 1;
        }

        /// <summary>
        /// Metodo para modificar un vuelo
        /// </summary>
        /// <param name="vuelo">Entidad vuelo a modificar</param>
        /// <returns>Retorna la entidad modificada</returns>
        public Entidad Modificar(Entidad vuelo)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdVuelo, SqlDbType.Int, ((Vuelo)vuelo)._id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroCodVuelo, SqlDbType.VarChar, ((Vuelo)vuelo).CodigoVuelo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroIdRuta, SqlDbType.Int, ((Vuelo)vuelo).getRuta._idRuta.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroFechaDespegue, SqlDbType.DateTime, ((Vuelo)vuelo).FechaDespegue.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroFechaAterrizaje, SqlDbType.DateTime, ((Vuelo)vuelo).FechaAterrizaje.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroStatus, SqlDbType.VarChar, ((Vuelo)vuelo).StatusVuelo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroIdAvion, SqlDbType.Int, ((Vuelo)vuelo).getAvion._id.ToString(), false);
                parametros.Add(parametro);
                List<ResultadoBD> results = EjecutarStoredProcedure(RecursoVuelo.ModificarVuelo, parametros);
                Conectar();
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorMensajeArgumento, ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorMensajeArgumento, ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04("Reserva-404", "Argumento con valor invalido", ex);
            }
            return vuelo;
        }

        /// <summary>
        /// Metodo para consultar un vuelo por su id en la bd
        /// </summary>
        /// <param name="id">id del vuelo a consultar</param>
        /// <returns>Entidad consultada</returns>
        Entidad IDAO.Consultar(int id)
        {
            DataTable resultado;
            Entidad vuelo;
            Entidad avion;
            Entidad ruta;
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdVuelo, SqlDbType.Int, id.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.BuscaVueloID, parametros);
                Conectar();
                if (resultado != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        string codVuelo = row[RecursoVuelo.ParametroCodVuelo].ToString();
                        DateTime fechaDespegue = DateTime.Parse(row[RecursoVuelo.ParametroFechaAterrizaje].ToString());
                        DateTime fechaAterrizaje = DateTime.Parse(row[RecursoVuelo.ParametroFechaDespegue].ToString());
                        string aviMatricula = row[RecursoVuelo.ParametroaAMatricula].ToString();
                        string status = row[RecursoVuelo.ParametroStatus].ToString();
                        int idRuta= int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        string ciudadO = row[RecursoVuelo.ParametroCOrigen].ToString();
                        string usuCor = row[RecursoVuelo.ParametroCDestino].ToString();
                        int idAvion= int.Parse(row[RecursoVuelo.ParametroIdAvion].ToString());
                        string ciudadD = row[RecursoVuelo.ParametroCDestino].ToString();
                        //cambiar
                        avion = FabricaEntidad.InstanciarAvion(idAvion, aviMatricula, "", 0, 0, 0, 0, 0, 0, 0, 0);
                        avion._id = idAvion;
                        ((Avion)avion)._matricula = aviMatricula;
                        ruta = FabricaEntidad.InstanciarRuta(idRuta, 0, "", "", ciudadO, ciudadD);
                        vuelo = (Vuelo)FabricaEntidad.InstanciarVuelo(id, codVuelo, (Ruta)ruta, fechaDespegue, status, fechaAterrizaje, 
                                                                      (Avion)avion);
                        return vuelo;
                    }

                }

            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return null;
        }

        /// <summary>
        /// no implementado
        /// </summary>
        /// <param name="e"></param>
        /// <returns>NotImplementedException</returns>
        public Entidad Consultar(Entidad e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar todos los vuelos registrados en la base de datos
        /// </summary>
        /// <returns>Lista con todos los vuelos</returns>
        public List<Entidad> ConsultarTodos()
        {
            DataTable resultado;
            Entidad objVuelo;
            List<Entidad> lista;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.ListarVuelos);
                Conectar();
                if (resultado != null)
                {
                    lista = new List<Entidad>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        DateTime fechaDespegue = DateTime.Parse(row[RecursoVuelo.ParametroFechaDespegue].ToString());
                        string codigoVuelo = row[RecursoVuelo.ParametroCodVuelo].ToString();
                        string status = row[RecursoVuelo.ParametroStatus].ToString();
                        DateTime fechaAterrizaje = DateTime.Parse(row[RecursoVuelo.ParametroFechaAterrizaje].ToString());
                        int id = int.Parse(row[RecursoVuelo.ParametroIdVuelo].ToString());
                        int idAvion = int.Parse(row[RecursoVuelo.ParametroIdAvion].ToString());
                        int idRuta = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        int idCiudadO = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        int idCiudadD = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        String ciudadD = row[RecursoVuelo.ParametroCDestino].ToString();
                        String ciudadO = row[RecursoVuelo.ParametroCOrigen].ToString();
                        String matAvion = row[RecursoVuelo.ParametroaAMatricula].ToString();
                        String modAvion = row[RecursoVuelo.ParametroAModelo].ToString();
                        /*int capTurista = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        int capVip = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        int capEjecutiva = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());*/
                        //ATENCIÓN, CAMBIAR POR FABRICA CUANDO MANDEN EL METODO///////////////////////////////
                        Avion avion = new Avion(idAvion, matAvion, modAvion, 0, 0, 0,
                                0, 0, 0, 0, 0);
                        Ruta ruta = new Ruta(idRuta, 0, null, null, ciudadO, ciudadD);
                        //////////////////////////////////////////////////////////////////////////////////////
                        objVuelo = FabricaEntidad.InstanciarVuelo(id, codigoVuelo, ruta, fechaDespegue, status,
                                                             fechaAterrizaje, avion);
                        lista.Add(objVuelo);
                    }
                    return lista;
                }

            }
            catch (ExceptionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return null;
        }

        /// <summary>
        /// Borrar vuelo por id
        /// </summary>
        /// <param name="vueID">Es el ID del vuelo a eliminar/param>
        /// <returns>Retorna true si es elimanado exitosamente</returns>
        public bool Eliminar(Entidad vuelo)
        {
            Parametro parametro = new Parametro();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdVuelo, SqlDbType.Int, vuelo._id.ToString(), false);
                parametros.Add(parametro);
                List<ResultadoBD> resultado = EjecutarStoredProcedure(RecursoVuelo.EliminarVuelo, parametros);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw  ex;
                throw  ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }

            return true;

        }

        /// <summary>
        /// Metodo que cambia el status del vuelo de activo a inactivo y viceversa
        /// </summary>
        /// <param name="vuelo"> id del vuelo</param>
        /// <returns> true si se cambio el status correctamente correctamente</returns>
        public bool CambiarStatus(int vuelo)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdVuelo, SqlDbType.VarChar, vuelo.ToString(), false);
                parametros.Add(parametro);
                List<ResultadoBD> results = EjecutarStoredProcedure(RecursoVuelo.CambiarStatus, parametros);
                Conectar();
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return true;
        }

        /// <summary>
        /// Metodo para consultar las ciudades origen con rutas activas
        /// </summary>
        /// <returns>lista de ciudades origen con rutas activas</returns>
        public List<Entidad> ConsultarLugarOrigen()
        {
            DataTable resultado;
            List<Entidad> lista;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.ListarLugarO);
                Conectar();
                if (resultado != null)
                {
                    lista = new List<Entidad>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        int id = int.Parse(row[RecursoVuelo.ParametroIdOrigen].ToString());
                        String ciudadO = row[RecursoVuelo.ParametroCOrigen].ToString();
                        lista.Add(FabricaEntidad.InstanciarCiudad(id, ciudadO));
                    }
                    return lista;
                }

            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return null;
        }

        /// <summary>
        /// Metodo que busca los lugares destino para un lugar origen especifico
        /// </summary>
        /// <returns>lista de lugares</returns>
        public List<Entidad> ConsultarLugarDestino(int lugarO)
        {
            DataTable resultado;
            List<Entidad> lista;
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdOrigen, SqlDbType.VarChar, lugarO.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.ListarLugarD, parametros);
                Conectar();
                if (resultado != null)
                {
                    lista = new List<Entidad>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        int id = int.Parse(row[RecursoVuelo.ParametroIdRuta].ToString());
                        String ciudadO = row[RecursoVuelo.ParametroCDestino].ToString();
                        lista.Add(FabricaEntidad.InstanciarCiudad(id, ciudadO));
                    }
                    return lista;
                }

            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return null;
        }

        /// <summary>
        /// Busca los aviones capaces de volar la ruta escogida
        /// </summary>
        /// <param name="idRuta"></param>
        /// <returns></returns>
        public List<Entidad> ConsultarAvionRuta(int idRuta)
        {
            DataTable resultado;
            List<Entidad> lista;
            Parametro parametro;
            Avion avion;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdRuta, SqlDbType.VarChar, idRuta.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.BuscarAvionRuta, parametros);
                Conectar();
                if (resultado != null)
                {
                    lista = new List<Entidad>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        int id = int.Parse(row[RecursoVuelo.ParametroIdAvion].ToString());
                        String modelo = row[RecursoVuelo.ParametroAModelo].ToString();
                        String matricula = row[RecursoVuelo.ParametroaAMatricula].ToString();
                        float velMaxima = float.Parse(row[RecursoVuelo.ParametroVelMaxima].ToString());
                        //CAMBIAR POR FABRICA AVION
                        avion = (Avion)FabricaEntidad.InstanciarAvion(0,"","",0,0,0,0,0,0,0,0);
                        avion._modelo = modelo;
                        avion._matricula = matricula;
                        avion._velocidadMaxima = velMaxima;
                        avion._id = id;
                        lista.Add(avion);
                    }
                    return lista;
                }

            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                if (ex.Number == 55567)
                    throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorAvionRuta, ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return null;
        }

       /// <summary>
       /// Metodo para consultar los datos del aterrizaje 
       /// </summary>
       /// <param name="idRuta"></param>
       /// <param name="fechaTiempo"></param>
       /// <param name="idAvion"></param>
       /// <returns>Entidad Vuelo con la informacion del aterrizaje</returns>
        public Entidad ConsultarDatosAterrizaje(int idRuta, DateTime fechaTiempo, int idAvion)
        {
            DataTable resultado;
            Entidad entidad;
            Parametro parametro;
            Avion avion;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdRuta, SqlDbType.Int, idRuta.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroFechaDespegue, SqlDbType.DateTime, fechaTiempo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroIdAvion, SqlDbType.Int, idAvion.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.FechaAterrizaje, parametros);
                Conectar();
                if (resultado != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        DateTime fechaAterrizaje = DateTime.Parse(row[0].ToString());
                        avion = (Avion)FabricaEntidad.InstanciarAvion(0, "", "", 0, 0, 0, 0, 0, 0, 0, 0);
                        avion._id = idAvion;
                        entidad = FabricaEntidad.InstanciarVuelo(fechaAterrizaje, avion);
                        return entidad;
                    }
                }

            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorCampoVacio, ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }
            return null;
        }

        /// <summary>
        /// Borrar vuelo por id
        /// </summary>
        /// <param name="vueID">Es el ID del vuelo a eliminar/param>
        /// <returns>Retorna true si es elimanado exitosamente</returns>
        public bool BuscarCodigo(String codigo)
        {
            Parametro parametro = new Parametro();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroCodVuelo, SqlDbType.VarChar, codigo.ToString(), false);
                parametros.Add(parametro);
                List<ResultadoBD> resultado = EjecutarStoredProcedure(RecursoVuelo.BuscarCodigo, parametros);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                if (ex.Number == 55567)
                    throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorAvionRuta, ex);
                if (ex.Number == 55566)
                    throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorCodigoDuplicado, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM04(RecursoVuelo.ErrorDaoVuelo, RecursoVuelo.ErrorGeneralBD, ex);
            }

            return true;

        }
        
    }
}