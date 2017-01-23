using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DAO.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M04;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COBuscarCodigoVuelo : Command<Boolean>
    {

        private String _codigo;

        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto que se quiere agregar</param>
        public M04_COBuscarCodigoVuelo(String codigo)
        {
            _codigo = codigo; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método Agregar
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override Boolean ejecutar()
        {
            try
            {
                IDAOVuelo buscarVuelo = (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                return(buscarVuelo.BuscarCodigo(_codigo));
            }
            catch (ReservaExceptionM04 ex)
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
                throw ex;
            }
            
        }
        #endregion
    }
}