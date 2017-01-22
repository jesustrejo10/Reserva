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
    public class M22_COModificarReserva : Command<String>
    {
         int reserva;
         int cant;

        public M22_COModificarReserva(int reserva2, int cant_dias)
        {
            this.reserva = reserva2;
            this.cant = cant_dias;
        }
        public override string ejecutar()
        {
            IDAOReservaHabitacion daoReservaHabitacion = FabricaDAO.instanciarDaoReservaHabitacion();
            String completo = daoReservaHabitacion.modificarReservaHabitacion(reserva,cant);
            return completo;

        }
    }
}