using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CVueloComida
    {
        public int _codigoVuelo { get; set; }
        public DateTime _horaSalida { get; set; }
        public DateTime _horaLlegada { get; set; }
        public int _claseTurista { get; set; }
        public int _claseEjecutiva { get; set; }
        public int _claseVip{ get; set; }
        public int _cantidad { get; set; }

    }
}