using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_reclamos
{
    public class CModificarReclamo
    {
        public int _idReclamo { get; set; }
        public String _tituloReclamo { get; set; }
        public String _detalleReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public int _estadoReclamo { get; set; }


    }
}