using FOReserva.Models.Hoteles;
using FOReserva.Models.Restaurantes;
using FOReserva.Models.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using FOReserva.DataAccess.DataAccessObject.DAORevision;

namespace FOReserva.DataAccess.DataAccessObject.Common.Interface
{
    public interface IDAORevision
    {
        DAOResult AgregarRevision(CRevision revision, CHotel hotel);
        DAOResult AgregarRevision(CRevision revision, CRestaurantModel restaurante);
        //DAOResult AplicarValoracion(CRevision revision, TipoValoracion hotel);
    }
}