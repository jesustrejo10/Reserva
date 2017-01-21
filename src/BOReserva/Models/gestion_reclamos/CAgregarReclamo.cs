using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_reclamos
{
    /// <summary>
    /// Clase del Modelo de la vista parcial agregar reclamo
    /// </summary>
    public class CAgregarReclamo
    {
        public String _tituloReclamo { get; set; }
        public String _detalleReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public int _estadoReclamo { get; set; }
        public int _usuario { get; set; }
        public int _editable { get; set; }
    }
}