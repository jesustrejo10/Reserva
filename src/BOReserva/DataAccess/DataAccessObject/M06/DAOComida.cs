using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;

using System;
using System.Collections.Generic;
using System.Data;
using BOReserva.DataAccess.DataAccessObject.M06;
using System.Data.SqlClient;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOComida : DAO, IDAOComida 
    {

        //CREA UNA COMIDA
        public bool crear(Entidad entidad) {
            Comida comida = (Comida)entidad;
            List<Parametro> lista = FabricaDAO.asignarListaDeParametro();

            try
            {
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_nombre, SqlDbType.VarChar, comida._nombre, false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_tipo, SqlDbType.VarChar, comida._tipo, false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_estatus, SqlDbType.Int, comida._estatus.ToString(), false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_descripcion, SqlDbType.VarChar, comida._descripcion, false));

                EjecutarStoredProcedure(RecursoM06.procedimientoAgregarComida, lista);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        //AGREGA UNA COMIDA A UN VUELO
        public bool agregarComidaVuelo(Entidad entidad)
        {
            ComidaVuelo comida = (ComidaVuelo)entidad;
            List<Parametro> lista = FabricaDAO.asignarListaDeParametro();

            try
            {
                lista.Add(FabricaDAO.asignarParametro("@com_vue_id", SqlDbType.Int, comida._id.ToString(), false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_vue_fk_comida, SqlDbType.Int, comida._comida, false));
                lista.Add(FabricaDAO.asignarParametro("@com_vue_cantidad", SqlDbType.Int, comida._cantidad.ToString(), false));

                EjecutarStoredProcedure(RecursoM06.procedimientoAgregarComidaVuelo, lista);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        //CONSULTA TODAS LAS COMIDAS DISPONIBLES Y NO DISPONIBLES
        public List<Entidad> consultarComidas()
        {
            List<Entidad> listaComidas;
            DataTable resultado;
            Entidad comida;

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoM06.procedimientoConsultarComidas);

                if (resultado != null)
                {
                    listaComidas = new List<Entidad>();

                    foreach (DataRow row in resultado.Rows)
                    {
                        int id = Int32.Parse(row[RecursoM06.com_id_consultar].ToString());
                        string nombre = row[RecursoM06.com_nombre_consultar].ToString();
                        string tipo = row[RecursoM06.com_tipo_consultar].ToString();
                        int estatus = Int32.Parse(row[RecursoM06.com_estatus_consultar].ToString());
                        string descripcion = row[RecursoM06.com_descripcion_consultar].ToString();

                        comida = FabricaEntidad.instanciarComida(id, nombre, tipo, estatus, descripcion);

                        listaComidas.Add(comida);
                    }
                    return listaComidas;
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

        //CONSULTA TODAS LAS COMIDAS Y SUS RESPECTIVOS VUELOS
        public List<Entidad> consultarComidasVuelos()
        {
            List<Entidad> listaComidasVuelos;
            DataTable resultado;
            Entidad comidasVuelos;

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoM06.procedimientoConsultarComidasVuelos);

                if (resultado != null)
                {
                    listaComidasVuelos = new List<Entidad>();

                    foreach (DataRow row in resultado.Rows)
                    {
                        int id = Int32.Parse(row[RecursoM06.com_vue_id].ToString());
                        string codigoVuelo = row[RecursoM06.vue_codigo].ToString();
                        string nombre = row[RecursoM06.com_nombre_consultar].ToString();
                        int cantidad = Int32.Parse(row[RecursoM06.com_vue_cantidad].ToString());
                        

                        comidasVuelos = FabricaEntidad.instanciarComidaVuelo(id, nombre,codigoVuelo, cantidad);

                        listaComidasVuelos.Add(comidasVuelos);
                    }
                    return listaComidasVuelos;
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

        //CAMBIAR ESTADO ESTATUS COMIDA
        public bool cambiarEstadoComida(Entidad entidad) {
            Comida comida = (Comida)entidad;
            bool resultado = false;
            List<Parametro> lista = FabricaDAO.asignarListaDeParametro();
            
            try
            {
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_id, SqlDbType.Int, comida._id.ToString(), false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_estatus, SqlDbType.Int, comida._estatus.ToString(), false));

                EjecutarStoredProcedure(RecursoM06.procedimientoCambiarEstatusComida, lista);
                return true;
            }
            catch (Exception ex) {
                throw ex;
            }

            return false;
        }

        //RELLENAR COMIDA
        public Entidad rellenarComida(Entidad entidad)
        {
            Comida comida = (Comida)entidad;
            List<Parametro> lista = FabricaDAO.asignarListaDeParametro();
            DataTable resultado;
            try
            {
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_id, SqlDbType.Int, comida._id.ToString(), false));

                resultado = EjecutarStoredProcedureTuplas(RecursoM06.procedimientoConsultarDatosComida, lista);

                if (resultado != null)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        comida._nombre = row[RecursoM06.com_nombre_consultar].ToString();
                        comida._tipo = row[RecursoM06.com_tipo_consultar].ToString();
                        comida._estatus = Int32.Parse(row[RecursoM06.com_estatus_consultar].ToString());
                        comida._descripcion = row[RecursoM06.com_descripcion_consultar].ToString();
                    }
                    return comida;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        //EDITAR COMIDA
        public bool editarComida(Entidad entidad)
        {
            Comida comida = (Comida)entidad;
            List<Parametro> lista = FabricaDAO.asignarListaDeParametro();
            
            try
            {
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_id, SqlDbType.Int, comida._id.ToString(), false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_nombre, SqlDbType.VarChar, comida._nombre, false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_tipo, SqlDbType.VarChar, comida._tipo, false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_estatus, SqlDbType.Int, comida._estatus.ToString(), false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_descripcion, SqlDbType.VarChar, comida._descripcion, false));

                EjecutarStoredProcedure(RecursoM06.procedimientoEditarComida, lista);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

    }
}