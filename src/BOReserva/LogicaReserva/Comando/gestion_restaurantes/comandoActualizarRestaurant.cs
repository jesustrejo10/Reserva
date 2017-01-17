using BOReserva.Datos.Fabrica;
using BOReserva.Datos.InterfazDao.gestion_restaurantes;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.LogicaReserva.Comando.gestion_restaurantes
{
    public class comandoActualizarRestaurant : Comando<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public comandoActualizarRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override bool Ejecutar()
        {
            try
            {
                IRestaurantDAO restaurantDao = FabricaDatosSql.RestaurantBD();
                restaurantDao.Modificar(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {

                throw;
            }
            System.Diagnostics.Debug.WriteLine("Metodo actualizar en fabrica en construccion");
            return true;
        }
    }
}