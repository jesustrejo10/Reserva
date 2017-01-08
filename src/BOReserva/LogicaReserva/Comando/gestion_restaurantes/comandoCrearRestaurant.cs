using BOReserva.Datos.Fabrica;
using BOReserva.Datos.InterfazDao.gestion_restaurantes;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.LogicaReserva.Comando.gestion_restaurantes
{
    public class comandoCrearRestaurant : Comando<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public comandoCrearRestaurant() { }

        public comandoCrearRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }
        #endregion

        public override bool Ejecutar()
        {
            try
            {
                IRestaurantDAO restaurantDao = FabricaDatosSql.RestaurantBD();
                restaurantDao.Crear(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {
                // exception implementada debido a que puede darse el caso 
                // en que algunos de los metodos de implementados en la 
                //interfaz IDAO no se implemente y se lance esta excepcion
                throw;
            }
            catch (Exception)
            {
                throw;

            }


        }
    }
}