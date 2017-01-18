using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Lugar : Entidad
    {
        public string Name { get; set; }

        public Lugar(int id, string nombre)
        {
            this._id = id;
            Name = nombre;
        }
    }
}