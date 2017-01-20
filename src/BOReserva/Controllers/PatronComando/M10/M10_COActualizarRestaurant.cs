using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
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

        public M10_COActualizarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override bool ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                restaurantDao.Modificar(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {

                throw;
            }
         
            return true;
        }
    }
}