using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    public class M14_COListarRutasRutas : Command<Dictionary<int, Entidad>>
    {
        string _ruta;
        
        public M14_COListarRutasRutas(string ruta)
        {
            this._ruta = ruta;

        }

        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAOItinerario daoItinerario = (IDAOItinerario) FabricaDAO.instanciarDaoItinerario();
            Dictionary<int, Entidad> mapCruceros = daoItinerario.ConsultarRutasRutas(_ruta);
            return mapCruceros;
        }
    }
}