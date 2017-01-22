using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOLugar : IDAO
    {
        String ciudad(int id);
        List<Entidad> buscarCiudades();
    }

}
