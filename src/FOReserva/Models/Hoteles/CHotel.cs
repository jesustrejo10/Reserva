using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Hoteles
{
    public class CHotel
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string EmailContacto { get; set; }
        public int CantidadHabitacionesDisponible { get; set; }
    }
}