using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    /// <summary>
    /// Clase comando para Listar las ciudades de la base de datos
    /// </summary>
    public class M10_COConsultarLugar : Command<List<Entidad>>
    {
        /// <summary>
        /// Metodo para consultar para cargar el combobox de lugar de los restaurant
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAORestaurant restaurantDao = FabricaDAO.RestaurantBD();
                return restaurantDao.ListarLugar();
            }
            catch (NotImplementedException e)
            {
                throw new ExceptionReserva("Reserva-404", "Metodo no implementado", e);
            }
            catch (Exception e)
            {
                throw new ExceptionReserva("Reserva-404", "Error al Realizar Operacion", e);
            }


        }
    }
}