using BOReserva.Datos.Fabrica;
using BOReserva.Datos.InterfazDao.gestion_restaurantes;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.LogicaReserva.Comando.gestion_restaurantes
{
  
        public class comandoConsultarRestaurantId : Comando<Entidad>
        {
            #region Atributos
            Entidad _objeto;
            #endregion

            public comandoConsultarRestaurantId(Entidad _objeto)
            {
                this._objeto = _objeto;
            }

            public override Entidad Ejecutar()
            {
                try
                {
                    IRestaurantDAO restaurantDao = FabricaDatosSql.RestaurantBD();
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