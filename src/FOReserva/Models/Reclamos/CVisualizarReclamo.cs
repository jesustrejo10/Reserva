using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Reclamos
{
    /// <summary>
    /// Clase encargada de vizualizar los reclamos
    /// </summary>
    public class CVisualizarReclamo
    {
        /// <summary>
        /// Atributo id Reclamo
        /// </summary>
        public int _idReclamo { get; set; }
        /// <summary>
        /// Atributo titulo Reclamo
        /// </summary>
        public String _tituloReclamo { get; set; }
        /// <summary>
        /// Atributo detalle Reclamo
        /// </summary>
        public String _detalleReclamo { get; set; }
        /// <summary>
        /// Atributo fecha Reclamo
        /// </summary>
        public String _fechaReclamo { get; set; }
        /// <summary>
        /// Atributo estado Reclamo
        /// </summary>
        public String estadoReclamo { get; set; }
    }
}