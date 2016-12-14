using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ofertas
{
    public class CVisualizarOferta
    {
        public String _idOferta { get; set; }

        public String _nombreOferta { get; set; }

        public String _nombrePaquete { get; set; }

        public float _porcentajeOferta { get; set; }

        public String _fechaIniOferta { get; set; }

        public String _fechaFinOferta { get; set; }

        public String _estadoOferta { get; set; }
    }
}