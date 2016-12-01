using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    public class CAgregarAutomovil
    {
        public String _matricula { get; set; } 
        public String _modelo { get; set; } 
        public String _fabricante { get; set; } 
        public int _anio { get; set; } 
        public String _tipovehiculo { get; set; } 
        public float _kilometraje { get; set; } 
        public int _cantpasajeros { get; set; } 
        public float _preciocompra { get; set; } 
        public float _precioalquiler { get; set; } 
        public float _penalidaddiaria { get; set; }
        public DateTime _fecharegistro { get; set; } 
        public String _color { get; set; } 
        public bool _disponibilidad { get; set; }
        public String _transmision { get; set; } 
        public String _pais { get; set; } 
        public String _estado { get; set; } 
        public String _ciudad { get; set; } 
    }
}