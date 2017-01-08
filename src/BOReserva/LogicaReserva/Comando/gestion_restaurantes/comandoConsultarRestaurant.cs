using BOReserva.Datos.Fabrica;
using BOReserva.Datos.InterfazDao.gestion_restaurantes;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.LogicaReserva.Comando.gestion_restaurantes
{
    public class comandoConsultarRestaurant : Comando<List<Entidad>>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public comandoConsultarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IRestaurantDAO restaurantDao = FabricaDatosSql.RestaurantBD();
                return restaurantDao.Consultar(this._objeto);
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}