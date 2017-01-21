using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    public class M10_COActualizarRestaurant : Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        /// <summary>
        /// Constructor de comando Actualizar
        /// </summary>
        /// <param name="_objeto"></param>
        public M10_COActualizarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        /// <summary>
        /// Metodo para ejecutar el comando modificar
        /// </summary>
        /// <returns></returns>
        public override bool ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                restaurantDao.Modificar(this._objeto);
                return true;
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