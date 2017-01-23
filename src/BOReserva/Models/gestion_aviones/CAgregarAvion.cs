using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{

    /// <summary>
    /// Clase modelo de Avion, usado para el agregarAvion 
    /// </summary>
    public class CAgregarAvion
    {
        public String _matriculaAvion { get; set; }
        public String _modeloAvion { get; set; }
        public int _capacidadPasajerosTurista{ get; set; }
        public int _capacidadPasajerosEjecutiva { get; set; }
        public int _capacidadPasajerosVIP { get; set; }
        public int _capacidadMaximaCombustible { get; set; }
        public float _capacidadEquipaje { get; set; }
        public float _distanciaMaximaVuelo { get; set; }
        public float _velocidadMaximaDeVuelo { get; set; }
        public int _disponibilidad { get; set; }
        
    }

}