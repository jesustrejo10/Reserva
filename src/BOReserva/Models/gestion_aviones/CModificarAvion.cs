using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{

    /// <summary>
    /// Clase usada para modificarAvion
    /// </summary>
    public class CModificarAvion
    {
        [Required]
        public int _id { get; set; }
        public String _matriculaAvion { get; set; }
        public String _modeloAvion { get; set; }
        public int _capacidadPasajerosTurista { get; set; }
        public int _capacidadPasajerosEjecutiva { get; set; }
        public int _capacidadPasajerosVIP { get; set; }
        public float _capacidadMaximaCombustible { get; set; }
        public float _capacidadEquipaje { get; set; }
        public float _distanciaMaximaVuelo { get; set; }
        public float _velocidadMaximaDeVuelo { get; set; }
        public int _disponibilidad { get; set; }

        }
    }
