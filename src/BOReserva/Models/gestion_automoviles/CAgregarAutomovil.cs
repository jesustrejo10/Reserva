using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    public class CAgregarAutomovil
    {
        public String _matricula { get; set; } //listo
        public String _modelo { get; set; } //listo
        public String _fabricante { get; set; } //listo
        public int _anio { get; set; } //listo
        public String _tipovehiculo { get; set; } //listo
        public float _kilometraje { get; set; } //listo
        public int _cantpasajeros { get; set; } //listo
        public float _preciocompra { get; set; } //listo
        public float _precioalquiler { get; set; } //listo
        public float _penalidaddiaria { get; set; }
        public DateTime _fecharegistro { get; set; } //listo
        public String _color { get; set; } //listo
        public bool _disponibilidad { get; set; }
        public String _transmision { get; set; } //list
        public String _pais { get; set; } //listo
        public String _estado { get; set; } //listo
        public String _ciudad { get; set; } //listo
    }
}