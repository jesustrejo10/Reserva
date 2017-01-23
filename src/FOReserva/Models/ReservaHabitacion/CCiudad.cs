using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaHabitacion
{
    public class CCiudad : Entidad
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public CCiudad(int cod, String name)
        {
            this.Codigo = cod;
            this.Nombre = name;
        }

        public CCiudad() { }


    }
}