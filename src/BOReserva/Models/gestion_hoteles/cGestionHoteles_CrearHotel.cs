using BOReserva.Servicio.Servicio_Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_hoteles
{
    public class CGGestionHoteles_CrearHotel
    {
<<<<<<< HEAD
        public int _id { get; set; }
=======
        internal string cantHabitaciones;
        internal string _disponibilidad;

        public CGestionHoteles_CrearHotel() {
            this._listaCiudad = new List<SelectListItem>();
            this._listaPais = new List<SelectListItem>();
        }

>>>>>>> 4b1d7a703393a001257cadd1fbd3e98ac23ab734
        public String _nombre { get; set; }
        public String _paginaweb { get; set; }
        public string _email { get; set; }
        public int _canthabitaciones { get; set; }
        public String _direccion { get; set; }
        public String _ciudad { get; set; }
<<<<<<< HEAD
        public String _pais { get; set; }
=======
        public float _puntuacion { get; set; }
        public float _cantHabitaciones { get; set; }
>>>>>>> 4b1d7a703393a001257cadd1fbd3e98ac23ab734
        public int _estrellas { get; set; }
        public float _puntuacion { get; set; }
        public int _disponibilidad { get; set; }
        public List<SelectListItem> _listapaises { get; set; }
    }
}