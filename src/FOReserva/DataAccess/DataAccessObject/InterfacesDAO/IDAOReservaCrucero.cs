using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOReservaCrucero : IDAO
    {
        List<Entidad> consultarCruceros();

        Entidad CambiarReserva(String id, String pasajeros, String status);

        List<Entidad> buscarCrucerosItinerario(string id, string fecha_ida, string fecha_vuelta);
        //List<Entidad> consultarCrucerosPerfil();

        int Eliminar(int id);
    }
}
