using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_hoteles
{
    public class CGestionHoteles_EditarHotel
    {
        public int _id { get; set; }
        public String _nombre { get; set; }
        public String _paginaweb { get; set; }
        public string _email { get; set; }
        public int _canthabitaciones { get; set; }
        public String _direccion { get; set; }
        public String _ciudad { get; set; }
        public String _pais { get; set; }
        public int _estrellas { get; set; }
        public float _puntuacion { get; set; }
        public int _disponibilidad { get; set; }
        public List<SelectListItem> _listapaises { get; set; }

        public CGestionHoteles_EditarHotel(CHotel hotel)
        {
            _id = hotel._id;
            _nombre = hotel._nombre;
            _paginaweb = hotel._paginaweb;
            _email = hotel._email;
            _canthabitaciones = hotel._canthabitaciones;
            _pais = hotel._pais;
            _ciudad = hotel._ciudad;
            _direccion = hotel._direccion;
            _estrellas = hotel._estrellas;
            _puntuacion = hotel._puntuacion;
            _disponibilidad = hotel._disponibilidad;
        }
    }
}