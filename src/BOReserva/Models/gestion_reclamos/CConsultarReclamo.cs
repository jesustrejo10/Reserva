using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_reclamos
{
    /// <summary>
    /// Clase del modelo para la vista del consultar reclamo a detalle
    /// </summary>
    public class CConsultarReclamo
    {
        public String _tituloReclamo { get; set; }
        public String _detalleReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public int _estadoReclamo { get; set; }
    }
}