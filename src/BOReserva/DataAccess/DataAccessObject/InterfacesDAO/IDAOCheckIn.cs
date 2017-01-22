using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOCheckIn : IDAO
    {
        List<Entidad> ListarPasesPasajero(int pasaporte);
    }
}
