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
    public class M10_COConsultarRestaurant : Command<List<Entidad>>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public M10_COConsultarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                return restaurantDao.Consultar(this._objeto);
            }
            catch (NotImplementedException)
            {
                // throw new ExceptionM4Tangerine("DS-404", "Metodo no implementado", e);
                throw;
            }

        }
    }
}