using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    public class M10_COConsultarLugar : Command<List<Entidad>>
    {
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                return restaurantDao.ListarLugar();
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