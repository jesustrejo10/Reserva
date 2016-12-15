using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaHabitacion
{
    public class Cvista_BuscarHotel
    {
        public int LugId { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int CantidadDias { get; set; }
        public List<CCiudad> Ciudades { get; set; }
    }
}