using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_hoteles
{
    public class CGestionHoteles_CrearHotel
    {
        public String _nombre { get; set; }
        public String _direccion { get; set; }
        public String _pais { get; set; }
        public String _ciudad { get; set; }
        public float _puntuacion { get; set; }
        public int _estrellas { get; set; }
        public String _paginaWeb { get; set; }
        public string _email { get; set; }
    }
}