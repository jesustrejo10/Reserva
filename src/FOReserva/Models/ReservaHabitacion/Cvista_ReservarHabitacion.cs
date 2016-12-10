using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaHabitacion
{
    public class Cvista_ReservarHabitacion
    {
        public int LugId { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int CantidadDias { get; set; }
        public int HotId { get; set; }
        public int UsuId { get; set; }
        
    }
}