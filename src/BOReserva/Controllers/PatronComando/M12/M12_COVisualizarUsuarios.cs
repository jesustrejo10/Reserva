using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M12_COVisualizarUsuarios : Command<Dictionary<int, Entidad>>
    {

        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            Dictionary<int, Entidad> mapUsuarios = daoUsuario.ConsultarTodos();               
            return mapUsuarios;
        }

    }
}