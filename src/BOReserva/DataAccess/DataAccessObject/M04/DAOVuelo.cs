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

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOVuelo : DAO, IDAOVuelo, IDAO
    {
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
                        Ruta ruta = new Ruta(idRuta, ciudadO, ciudadD, null, null, 0);
                        //////////////////////////////////////////////////////////////////////////////////////
                        objVuelo = FabricaEntidad.InstanciarVuelo(id, codigoVuelo, ruta, fechaDespegue, status,
                                                             fechaAterrizaje, avion);
                        lista.Add(objVuelo);
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
            catch (SqlException ex)
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
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw  ex;
                throw  ex;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
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
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
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
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
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
                        avion = new Avion(id, matricula, modelo, 0, 0, 0, 0, 0, velMaxima, 0, 0);
                        lista.Add(avion);
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
            catch (SqlException ex)
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
        /// Busca los datos del avion y la fecha de aterriaje para un avion y ruta determinado
        /// </summary>
        /// <param name="idRuta"></param>
        /// <returns></returns>
        public Entidad ConsultarDatosAterrizaje(int idRuta, DateTime fechaTiempo, int idAvion)
        {
            DataTable resultado;
            Entidad entidad;
            Parametro parametro;
            Avion avion;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro(RecursoVuelo.ParametroIdRuta, SqlDbType.VarChar, idRuta.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroFechaDespegue, SqlDbType.Date, fechaTiempo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoVuelo.ParametroIdAvion, SqlDbType.VarChar, idAvion.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.BuscarAvionRuta, parametros);
                Conectar();
                if (resultado != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        DateTime fechaAterrizaje = DateTime.Parse(row[RecursoVuelo.ParametroFechaAterrizaje].ToString());
                        int aCapMax = int.Parse(row[RecursoVuelo.ParametroCapacidadMaxima].ToString());
                        String modelo = row[RecursoVuelo.ParametroAModelo].ToString();
                        float velMaxima = float.Parse(row[RecursoVuelo.ParametroVelMaxima].ToString());
                        float aMaxDist = float.Parse(row[RecursoVuelo.ParametroVelMaxima].ToString());
                        //CAMBIAR POR FABRICA AVION
                        avion = new Avion(0,"",modelo,0,0,0,0,aMaxDist,velMaxima,0,0);
                        //
                        entidad = FabricaEntidad.InstanciarVuelo(fechaAterrizaje, avion);
                        return entidad;
                    }
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
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        
    }
}