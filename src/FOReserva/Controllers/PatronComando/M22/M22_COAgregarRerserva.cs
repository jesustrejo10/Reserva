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
    public class M22_COAgregarRerserva : Command<String>
    {
        ReservaHabitacion reserva;

        public M22_COAgregarRerserva(ReservaHabitacion reserva2)
        {
            this.reserva = reserva2;
        }
        public override string ejecutar()
        {
            IDAO daoReservaHabitacion = FabricaDAO.instanciarDaoReservaHabitacion();
            int completo = daoReservaHabitacion.Agregar(reserva);
            return completo.ToString();

        }
    }
}