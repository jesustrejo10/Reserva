using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaHabitacion
{
    public class CResultadoProceso
    {
        public bool CulminoCorrectamente { get; set; }
        public int Estatus { get; set; }
        public string Mensaje { get; set; }
        public int Referencia { get; set; }
    }
}