using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{

    /// <summary>
    /// Clase usada para Visualizar el avion
    /// </summary>
    public class CVerAvion
    {
        public string _matricula { get; set; }
        public string _modelo { get; set; }
        public int _capacidadTurista { get; set; }
        public int _capacidadEjecutiva { get; set; }
        public int _capacidadVIP { get; set; }
        public float _capacidadEquipaje { get; set; }
        public float _distanciaMaximaVuelo { get; set; }
        public float _velocidadMaxima { get; set; }
        public float _capacidadCombustible { get; set; }
        public int _disponibilidad { get; set; }
    }
}
