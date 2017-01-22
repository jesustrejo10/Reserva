using System;
using System.Collections.Generic;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_COConsultarVuelos:Command<List<Entidad>>
    {
        public M06_COConsultarVuelos()
        {

        }

        public override List<Entidad> ejecutar()
        {
            IDAOVuelo DAOVuelo = (IDAOVuelo) FabricaDAO.instanciarDAOVuelo();
            return DAOVuelo.ConsultarTodos();
        } 
    }
}