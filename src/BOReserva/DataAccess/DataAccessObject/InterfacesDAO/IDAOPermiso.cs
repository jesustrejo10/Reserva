using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    interface IDAOPermiso: IDAO
    {
        List<Entidad> ConsultarListaPermisos();
    }
}