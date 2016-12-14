using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CAgregarVuelo
    {
        public string _codigoVuelo { get; set; }
        public string _ciudadOrigen { get; set; }
        public string _ciudadDestino { get; set; }
        public int _capacidadTurista { get; set; }
        public int _capacidadEjecutiva { get; set; }
        public int _capacidadVip { get; set; }
    }
}