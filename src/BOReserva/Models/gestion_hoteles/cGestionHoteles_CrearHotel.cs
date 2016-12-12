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
        public int _id { get; set; }
        public String _nombre { get; set; }
        public String _paginaweb { get; set; }
        public string _email { get; set; }
        public int _canthabitaciones { get; set; }
        public String _direccion { get; set; }
        public String _ciudad { get; set; }
        public String _pais { get; set; }
        public float _puntuacion { get; set; }
        public float _cantHabitaciones { get; set; }
        public int _estrellas { get; set; }
        public List<SelectListItem> _listapaises { get; set; }
        public List<SelectListItem> _listaciudades{ get; set; }

    }
}