using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada para crear el objeto Habitacion 
    /// </summary>
    public class Habitacion : Entidad
    {
        public new int _id { get; set; }

        public int _precio { get; set; }

        public int _hotel { get; set; }

        public String _nombre_hotel { get; set; }
        /// <summary>
        /// Constructor de Habitacion
        /// </summary>
        /// <param name="id">El id de Habitacion</param>
        /// <param name="precio">Precio de Habitacion</param>
        /// <param name="hotel">id del Hotel</param>
        public Habitacion(int id, int precio, int hotel)
        {
            this._id = id;
            this._hotel = hotel;
            this._precio = precio;
        }
        /// <summary>
        /// Constructor de Habitacion
        /// </summary>
        /// <param name="id">El id de Lugar</param>
        /// <param name="Hotel">Id de Hotel</param>
        public Habitacion(int id, int hotel)
        {
            this._id = id;
            this._hotel = hotel;
        }
        /// <summary>
        /// Constructor de Habitacion
        /// </summary>
        /// <param name="id">El id de Lugar</param>
        /// <param name="hotel">id del Hotel</param>
        /// <param name="name_hotel">nombre del hotel</param>
        public Habitacion(int id, int hotel, String name_hotel)
        {
            this._id = id;
            this._hotel = hotel;
            this._nombre_hotel = name_hotel;
        }

    }
}