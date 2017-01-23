using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{

    /// <summary>
    /// Clase para la gestion de aviones
    /// </summary>
    public class CGestion_avion
    {     
        public String _matriculaConsultarEstadisticaAvion { get; set; }
        public float _kmsRecorridosConsultarEstadistica { get; set; }
        public float _combustibleConsumidoConsultarEstadistica { get; set; }
        public int _pasajerosTransportadosConsultarEstadistica { get; set; }
    }
}