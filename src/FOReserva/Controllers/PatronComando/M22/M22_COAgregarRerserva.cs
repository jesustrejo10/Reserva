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
    /// Comando que se encarga de agregar las reservas de automovil a la BD
    /// </summary>
    public class M22_COAgregarRerserva : Command<String>
    {
        ReservaHabitacion reserva;
        /// <summary>
        /// Metodo para setear la reserva para agregar
        /// </summary>
        /// <param name="reserva2">La reserva que viene del controlador</param>
        public M22_COAgregarRerserva(ReservaHabitacion reserva2)
        {
            this.reserva = reserva2;
        }
        ///// <summary>
        ///// Sobreescritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al IDAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un string
        ///// </returns>
        public override string ejecutar()
        {
            IDAO daoReservaHabitacion = FabricaDAO.instanciarDaoReservaHabitacion();
            int completo = daoReservaHabitacion.Agregar(reserva);
            return completo.ToString();

        }
    }
}