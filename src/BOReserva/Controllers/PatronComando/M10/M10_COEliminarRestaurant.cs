using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    public class M10_COEliminarRestaurant : Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public M10_COEliminarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override bool ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                restaurantDao.Eliminar(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}