using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.Domain;

namespace FOReserva.Models.ReservaHabitacion
{
    public class Cvista_ReservarHabitacion : Entidad
    {
        public int LugId { get; set; }
        public String FechaLlegada { get; set; }
        public int CantidadDias { get; set; }
        public int HotId { get; set; }
        public int UsuId { get; set; }
        
    }
}