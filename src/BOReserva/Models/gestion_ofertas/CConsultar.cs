using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ofertas
{
    public class CConsultar
    {
        public int _id { get; set; }

        public String _nombre { get; set; }

        public String _codigoVuelo { get; set; }

        public String _nombreSalida { get; set; }

        public String _nombreLlegada { get; set; }
    }
}