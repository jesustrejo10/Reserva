using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Modulo : Entidad
    {
        public String _nombre { get; set; }

        public int _id { get; set; }

        public Modulo(int id, string nombre) : base(id)
        {
            this._nombre = nombre;
        }

        public Modulo()
        {
        }
    }
}