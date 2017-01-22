using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase para el manejo de las habitaciones de los hoteles
    /// </summary>
    public class Habitacion : Entidad
    {
        public int _precio { get; set; }

        public int _hotel { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="precio">Precio de la habitacion</param>
        /// <param name="hotelConNuevosCampos">Hotel al cual pertenece</param>
        public Habitacion (int precio, int hotel)
        {
            this._hotel = hotel;
            this._precio = precio;
        }
    }
}