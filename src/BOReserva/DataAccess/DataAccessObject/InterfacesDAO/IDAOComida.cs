using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOComida
    {
        bool crear(Entidad comida);
        List<Entidad> consultarComidas();
        List<Entidad> consultarComidasVuelos();
    }
}