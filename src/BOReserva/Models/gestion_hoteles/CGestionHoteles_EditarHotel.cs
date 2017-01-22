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
        /*
        public CGestionHoteles_EditarHotel() { }

        public CGestionHoteles_EditarHotel(CHotel hotelConNuevosCampos)
        {
            _id = hotelConNuevosCampos._id;
            _nombre = hotelConNuevosCampos._nombre;
            _paginaweb = hotelConNuevosCampos._paginaweb;
            _email = hotelConNuevosCampos._email;
            _canthabitaciones = hotelConNuevosCampos._canthabitaciones;
            _pais = hotelConNuevosCampos._pais;
            _ciudad = hotelConNuevosCampos._ciudad;
            _direccion = hotelConNuevosCampos._direccion;
            _estrellas = hotelConNuevosCampos._estrellas;
            _puntuacion = hotelConNuevosCampos._puntuacion;
            _disponibilidad = hotelConNuevosCampos._disponibilidad;
        }
        */
    }
}