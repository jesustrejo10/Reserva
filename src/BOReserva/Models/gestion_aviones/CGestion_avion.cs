using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{
    public class CGestion_avion
    {
        public String _matriculaAvionAgregar { get ; set; }
        public String _modeloAvionAgregar { get; set; }
        public String _nombreFabricanteAgregar { get; set; }
        public int _capacidadPasajerosTuristaAgregar { get; set; }
        public int _capacidadPasajerosEjecutivaAgregar { get; set; }
        public int _capacidadPasajerosVIPAgregar { get; set; }
        public int _capacidadMaximaCombustible { get; set; }
        public float _capacidadEquipajeAgregar { get; set; }
        public float _distanciaMaximaVueloAgregar { get; set; }
        public float _velocidadMaximaDeVueloAgregar { get; set; }
        public float _potenciaMotor1Agregar { get; set; }
        public float _potenciaMotor2Agregar { get; set; }
        public String _matriculaConsultarEstadisticaAvion { get; set; }
        public float _kmsRecorridosConsultarEstadistica { get; set; }
        public float _combustibleConsumidoConsultarEstadistica { get; set; }
        public int _pasajerosTransportadosConsultarEstadistica { get; set; }
    }
}