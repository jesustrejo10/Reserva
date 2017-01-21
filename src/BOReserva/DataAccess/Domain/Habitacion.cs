using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Habitacion : Entidad
    {
        public int _precio { get; set; }

        public int _hotel { get; set; }

        public Habitacion (int precio, int hotel)
        {
            this._hotel = hotel;
            this._precio = precio;
        }
    }
}