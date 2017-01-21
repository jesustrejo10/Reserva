using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    public class M10_COConsultarRestaurant : Command<List<Entidad>>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        /// <summary>
        /// Constructor metodo consultar
        /// </summary>
        /// <param name="_objeto"></param>
        public M10_COConsultarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        /// <summary>
        /// Metodo para consultar en la base de datos los restaurante segun la ciudad elegida 
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                return restaurantDao.Consultar(this._objeto);
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