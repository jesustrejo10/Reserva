using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22Cruceros
{
    public class M22_COEliminarReservaCrucero : Command<String>
    {
        int _id_reserva;

        public M22_COEliminarReservaCrucero(int id_reserva)
        {
            this._id_reserva = id_reserva;
        }

        public override string ejecutar()
        {
            IDAOReservaCrucero dao = (IDAOReservaCrucero)FabricaDAO.instanciarDaoReservaCrucero();
            return dao.Eliminar(_id_reserva).ToString();
            
        }
    }
}