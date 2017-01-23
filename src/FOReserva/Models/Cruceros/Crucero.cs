using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Cruceros
{
    public class Crucero
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Crucero(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}