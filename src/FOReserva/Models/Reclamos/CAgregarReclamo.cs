using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Reclamos
{
    public class CAgregarReclamo
    {
        public String _tituloReclamo { get; set; }
        public String _detalleReclamo { get; set; }

        public String _fechaReclamo { get; set; }

        public int _usuarioReclamo { get; set; }
    }
}