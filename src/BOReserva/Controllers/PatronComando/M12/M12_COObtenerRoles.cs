using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DAO;

namespace BOReserva.Controllers.PatronComando.M12
{
    public class M12_COObtenerRoles : Command<List<Entidad>>
    {
        public override List<Entidad> ejecutar()
        {
            IDAORol daoRol = (IDAORol)FabricaDAO.instanciarDAORol();
            List<Entidad> roles;
            roles = daoRol.ConsultarRoles();

            return roles;
        }
    }
}