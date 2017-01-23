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
        bool agregarComidaVuelo(Entidad comida);
        List<Entidad> consultarComidas();
        List<Entidad> consultarComidasVuelos();
        bool cambiarEstadoComida(Entidad comida);
        Entidad rellenarComida(Entidad comida);
        bool editarComida(Entidad comida);
    }
}