using FOReserva.Models.Hoteles;
using FOReserva.Models.ReservaHabitacion;
using FOReserva.Models.Restaurantes;
using FOReserva.Models.Revision;
using FOReserva.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FOReserva.DataAccess.DataAccessObject.DAORevision;
//using FOReserva.DataAccess.DataAccessObject.DAORevision;

namespace FOReserva.DataAccess.DataAccessObject.Common.Interface
{
    public interface IDAORevision
    {
        DAOResult GuardarRevision(CRevision revision, CUsuario usuario, CReservaHabitacion reservaHabitacion);
        DAOResult GuardarRevision(CRevision revision, CUsuario usuario, CRestaurantModel restaurante);
        DAOResult AplicarValoracion(CRevision revision, TipoValoracion tipo);
    }
}