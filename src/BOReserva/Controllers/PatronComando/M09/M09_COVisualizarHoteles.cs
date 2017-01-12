using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M09_COVisualizarHoteles : Command<Dictionary<int, Entidad>>
    {
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
            Dictionary<int, Entidad> test = daoHotel.ConsultarTodos();
            return test;
        }

    }
}