using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Rol: Entidad
    {
        public int id { get; set; }
        public String nombre { get; set; }

        public Rol()
        {
        }
    }

   
}