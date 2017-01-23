using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.Domain;

namespace FOReserva.Models.ReservaHabitacion
{
    public class Cvista_BuscarHotel
    {
        public int LugId { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int CantidadDias { get; set; }
        public List<CiudadHab> Ciudades { get; set; }

    }
}