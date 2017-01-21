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
    public class M10_COCrearRestaurant : Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public M10_COCrearRestaurant() { }

        public M10_COCrearRestaurant(Entidad _objeto)
        {
            this._objeto = _objeto;
        }
        #endregion

        public override bool ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
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