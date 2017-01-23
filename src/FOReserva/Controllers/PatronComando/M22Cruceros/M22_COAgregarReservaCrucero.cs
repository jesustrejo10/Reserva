using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22Cruceros
{
    public class M22_COAgregarReservaCrucero : Command<String>
    {

        ReservaCrucero _reserva;

        public M22_COAgregarReservaCrucero(ReservaCrucero reserva)
        {
            this._reserva = reserva;

        }

        public override string ejecutar()
        {
            IDAO DAOReservaCrucero = FabricaDAO.instanciarDaoReservaCrucero();
            int resultadoReserva = DAOReservaCrucero.Agregar(_reserva);
            return resultadoReserva.ToString();
            
        }
    }
}