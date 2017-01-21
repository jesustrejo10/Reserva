using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain.M03;
using BOReserva.DataAccess.DataAccessObject.M03;

namespace BOReserva.Controllers.PatronComando.M04
{/// <summary>
 /// Comando Listar Lugares
 /// </summary>
    public class M03_COListarLugares : Command<Dictionary<int, Entidad>>
    {

        public override Dictionary<int, Entidad> ejecutar()
        {
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Dictionary<int, Entidad> test = daoRuta.listarLugares();
            return test;
        }

    }
}