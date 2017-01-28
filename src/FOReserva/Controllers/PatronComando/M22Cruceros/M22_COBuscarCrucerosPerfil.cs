using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22Cruceros
{
    public class M22_COBuscarCrucerosPerfil : Command<Dictionary<int,Entidad>>
    {


        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO dao =  FabricaDAO.instanciarDaoReservaCrucero();
            return dao.ConsultarTodos();
        }
    }
}