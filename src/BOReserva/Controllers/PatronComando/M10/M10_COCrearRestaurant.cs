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
    public class M10_COCrearRestaurant : Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
      
        /// <summary>
        /// Constructor del comando crear nuevo resstaurante
        /// </summary>
        /// <param name="_objeto"></param>
        public M10_COCrearRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }
        #endregion

        /// <summary>
        /// Metodo para crear un restaurant en la Base de Datos
        /// </summary>
        /// <returns></returns>
        public override bool ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                restaurantDao.Crear(this._objeto);
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