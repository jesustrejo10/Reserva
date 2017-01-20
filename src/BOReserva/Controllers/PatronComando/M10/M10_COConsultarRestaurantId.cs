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
  
        public class M10_COConsultarRestaurantId : Command<Entidad>
        {
            #region Atributos
            Entidad _objeto;
            #endregion

            public M10_COConsultarRestaurantId(Entidad _objeto)
            {
                this._objeto = _objeto;
            }

            public override Entidad ejecutar()
            {
                try
                {
                    IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                    return restaurantDao.consultarRestaurantId(this._objeto);
                }
                catch (NotImplementedException)
                {
                    // exception implementada debido a que puede darse el caso 
                    // en que algunos de los metodos  en la 
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