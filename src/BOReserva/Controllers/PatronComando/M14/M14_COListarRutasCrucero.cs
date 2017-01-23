using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    public class M14_COListarRutasCrucero : Command<Dictionary<int, Entidad>>
    {

        public M14_COListarRutasCrucero()
        { }

        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAOItinerario daoItinerario = (IDAOItinerario) FabricaDAO.instanciarDaoItinerario();
            Dictionary<int, Entidad> mapCruceros = daoItinerario.ConsultarRutasCrucero();
            return mapCruceros;
        }


    }
}