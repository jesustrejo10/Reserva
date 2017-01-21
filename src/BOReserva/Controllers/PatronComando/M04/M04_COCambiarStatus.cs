using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
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
                DAOVuelo exec = (DAOVuelo)FabricaDAO.instanciarDAOVuelo();
                exec.CambiarStatus(_vuelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
    }

}
