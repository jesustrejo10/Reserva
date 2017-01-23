using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Hoteles
{
    public class CHotel : Entidad
    {
        public int Codigo { get; set; }
        public String Nombre { get; set; }
        public String EmailContacto { get; set; }
        public int CantidadHabitacionesDisponible { get; set; }

        public CHotel() { }
            
            
        public CHotel(String name, int cant)
        {

            this.Nombre = name;
            this.CantidadHabitacionesDisponible = cant;

        }
    }
}