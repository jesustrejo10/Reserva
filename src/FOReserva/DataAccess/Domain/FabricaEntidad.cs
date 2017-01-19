using FOReserva.Models;
using FOReserva.Models.Reclamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada con la finalidad de instanciar a cualquier objeto dentro del Dominio

    /// </summary>
    public class FabricaEntidad
    {

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }
        #region M16 Reclamos
        public static Entidad InstanciarReclamo (CAgregarReclamo reclamo)
        {
            String _tituloReclamo = reclamo._tituloReclamo;
            String _detalleReclamo = reclamo._detalleReclamo;
            String _fechaReclamo = reclamo._fechaReclamo;
            int _estadoReclamo = 1;
            int _usuarioReclamo = reclamo._usuarioReclamo;
            return new Reclamo(_tituloReclamo, _detalleReclamo, _fechaReclamo, _estadoReclamo, _usuarioReclamo);
        }
        #endregion

    }
}
