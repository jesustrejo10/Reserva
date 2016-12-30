using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M09_COVisualizarHoteles : Command
    {
        public override Dictionary<int, Entidad> ejecutarComando()
        {
            IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
            Dictionary<int, Entidad> test = daoHotel.ConsultarTodos();
            return test;
        }

        public override String ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}