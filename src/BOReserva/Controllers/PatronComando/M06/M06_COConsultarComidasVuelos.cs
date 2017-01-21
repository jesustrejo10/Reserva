using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_COConsultarComidasVuelos:Command<List<Entidad>>
    {
        public M06_COConsultarComidasVuelos()
        {

        }

        public override List<Entidad> ejecutar()
        {
            IDAOComida DAOcomida = FabricaDAO.instanciarComida();
            return DAOcomida.consultarComidasVuelos();
        } 
    }
}