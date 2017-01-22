using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COModificarVuelo : Command<Entidad>
    {
        private Entidad _vuelo;

        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto que se quiere agregar</param>
        public M04_COModificarVuelo(Entidad vuelo)
        {
            _vuelo = vuelo; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método Agregar
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override Entidad ejecutar()
        {
            try
            {
                IDAO vueloModificar = FabricaDAO.instanciarDAOVuelo();
                return(vueloModificar.Modificar(_vuelo));
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }
        #endregion
    }
}