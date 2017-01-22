using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Habitacion : Entidad
    {
        public int _id { get; set; }

        public int _precio { get; set; }

        public int _hotel { get; set; }

        public String _nombre_hotel { get; set; }

        public Habitacion(int id, int precio, int hotel)
        {
            this._id = id;
            this._hotel = hotel;
            this._precio = precio;
        }

        public Habitacion(int id, int hotel)
        {
            this._id = id;
            this._hotel = hotel;
        }

        public Habitacion(int id, int hotel, String name_hotel)
        {
            this._id = id;
            this._hotel = hotel;
            this._nombre_hotel = name_hotel;
        }

    }
}