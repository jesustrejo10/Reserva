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
    public class M22_COEliminarReserva : Command<String>
    {
         int reserva;

        public M22_COEliminarReserva(int reserva2)
        {
            this.reserva = reserva2;
        }
        public override String ejecutar()
        {
            IDAOReservaHabitacion daoReservaHabitacion = FabricaDAO.instanciarDaoReservaHabitacion();
            String completo = daoReservaHabitacion.eliminarReservaHabitacion(reserva);
            return completo;

        }
    }
}