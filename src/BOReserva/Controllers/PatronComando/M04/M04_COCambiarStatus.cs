using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M04;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COCambiarStatus : Command<Boolean>
    {
        private int _vuelo;

        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto al que se le quiere cambiar el status</param>
        public M04_COCambiarStatus(int vuelo)
        {
            _vuelo = vuelo; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoVuelo y usa el método CambiarStatus
        /// </summary>
        /// <returns>Retorna true si la accion se realizo</returns>
        public override Boolean ejecutar()
        {
            try
            {
                IDAOVuelo exec = (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                exec.CambiarStatus(_vuelo);
                return true;
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
