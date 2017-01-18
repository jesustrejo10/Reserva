using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COConsultarTodosVuelos : Command<List<Entidad>>
    {
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAOVuelo daoVuelo = (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                List<Entidad> listaVuelos = daoVuelo.ConsultarTodos();
                return listaVuelos;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            
        }
    }
}