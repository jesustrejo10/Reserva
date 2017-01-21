using System;
using System.Collections.Generic;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_COConsultarComidas: Command<List<Entidad>>
    {

        public M06_COConsultarComidas()
        {

        }

        public override List<Entidad> ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.consultarComidas();
        }
    }
}