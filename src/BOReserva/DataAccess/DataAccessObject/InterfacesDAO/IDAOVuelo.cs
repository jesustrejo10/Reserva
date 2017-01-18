using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace BOReserva.DataAccess.DAO
{
    interface IDAOVuelo : IDAO
    {
        List<Entidad> ConsultarTodos();
    }
}