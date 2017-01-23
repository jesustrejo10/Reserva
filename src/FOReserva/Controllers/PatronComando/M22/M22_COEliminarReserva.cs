using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace FOReserva.Controllers.PatronComando.M22
{
    /// <summary>
    /// Comando que se encarga de eliminar las reservas de automovil a la BD
    /// </summary>
    public class M22_COEliminarReserva : Command<String>
    {
         int reserva;
         /// <summary>
         /// Metodo para setear la reserva para elminar
         /// </summary>
         /// <param name="reserva2">La rerserva que viene del controlador</param>
        public M22_COEliminarReserva(int reserva2)
        {
            this.reserva = reserva2;
        }
        ///// <summary>
        ///// Sobreescritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al IDAOReservaHabitacion y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un String
        ///// </returns>
        public override String ejecutar()
        {
            IDAOReservaHabitacion daoReservaHabitacion = FabricaDAO.instanciarDaoReservaHabitacion();
            String completo = daoReservaHabitacion.eliminarReservaHabitacion(reserva);
            return completo;

        }
    }
}