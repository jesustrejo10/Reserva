using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_hoteles
{
    public class CGestionHoteles_CrearHotel
    {
        internal string cantHabitaciones;
        internal string _disponibilidad;

        public CGestionHoteles_CrearHotel() {
            this._listaCiudad = new List<SelectListItem>();
            this._listaPais = new List<SelectListItem>();
        }

        public String _nombre { get; set; }
        public String _direccion { get; set; }
        public String _pais { get; set; }
        public String _ciudad { get; set; }
        public float _puntuacion { get; set; }
        public float _cantHabitaciones { get; set; }
        public int _estrellas { get; set; }
        public String _paginaWeb { get; set; }
        public string _email { get; set; }
        public List<SelectListItem> _listaPais { get; set; }
        public List<SelectListItem> _listaCiudad { get; set; }
    }
}