using FOReserva.DataAccess.Domain;
using FOReserva.Models.Hoteles;
using FOReserva.Models.ReservaHabitacion;
using FOReserva.Models.Restaurantes;
using FOReserva.Models.Revision;
using FOReserva.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FOReserva.DataAccess.DataAccessObject.Common.Interface
{
    public interface IDAORevision
    {
        bool GuardarRevision(Entidad revision);
        bool AplicarValoracion(Entidad valoracion);
    }
}