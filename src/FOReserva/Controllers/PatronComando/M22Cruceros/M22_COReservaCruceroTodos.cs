using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22Cruceros
{
    public class M22_COReservaCruceroTodos : Command<List<Entidad>>
    {


        public override List<Entidad> ejecutar()
        {
            IDAOReservaCrucero dao = (IDAOReservaCrucero)FabricaDAO.instanciarDaoReservaCrucero();
            //List<Entidad> cruceros = dao.consultarCruceros();
            return dao.consultarCruceros();
        }
    }
}