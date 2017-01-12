using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Usuario :Entidad
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String correo { get; set; }
        public String clave { get; set; }
        public String fechaCreacion { get; set; }

        public Usuario()
        {

        }

    }
}