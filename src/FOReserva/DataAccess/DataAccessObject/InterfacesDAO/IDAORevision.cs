using FOReserva.DataAccess.Domain;
using FOReserva.Models.Hoteles;
using FOReserva.Models.ReservaHabitacion;
using FOReserva.Models.Restaurantes;
using FOReserva.Models.Revision;
using FOReserva.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace FOReserva.DataAccess.DataAccessObject.M20
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDAORevision
    {
        bool GuardarRevision(Entidad revision);
        bool GuardarValoracion(Entidad valoracion);
        bool BorrarRevision(Entidad revision);
        List<Revision> ObtenerRevisionesPorReferencia(Entidad referencia);
        ReferenciaValorada ObtenerValoracionPorReferencia(Entidad referencia);
    }
}