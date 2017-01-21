using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.M10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M10
{
    /// <summary>
    /// Metodo solicitado por M11 Paquetes y Ofertas 
    /// </summary>
    public class M10_COListarRestaurantId : Command<List<Entidad>>
    {
        /// <summary>
        /// Constructor lista de resturantes
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                return restaurantDao.ListarRestaurantes();
            }
            catch (NotImplementedException e)
            {
                throw new ExceptionReserva("Reserva-404", "Metodo no implementado", e);
            }
            catch (Exception e)
            {
                throw new ExceptionReserva("Reserva-404", "Error al Realizar Operacion", e);
            }
        }
    }
}