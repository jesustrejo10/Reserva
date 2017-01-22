using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COEliminarVuelo : Command<bool>
    {
        private Entidad _vuelo;

        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto que se quiere agregar</param>
        public M04_COEliminarVuelo (Entidad vuelo)
        {
            _vuelo = vuelo; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoVuelo y usar el método Eliminar
        /// </summary>
        public override bool ejecutar()
        {
            try
            {
                IDAOVuelo vueloDel= (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                vueloDel.Eliminar(_vuelo);
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