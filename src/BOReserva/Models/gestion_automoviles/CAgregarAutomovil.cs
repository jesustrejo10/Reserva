using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    /// <summary>
    /// Clase del modelo de la vista parcial M08_AgregarAutomovil
    /// </summary>
    public class CAgregarAutomovil
    {
        [Required]
        public String _matricula { get; set; } 
        public String _modelo { get; set; } 
        public String _fabricante { get; set; } 
        public int _anio { get; set; } 
        public String _tipovehiculo { get; set; } 
        public double _kilometraje { get; set; } 
        public int _cantpasajeros { get; set; }
        public double _preciocompra { get; set; } 
        public double _precioalquiler { get; set; } 
        public double _penalidaddiaria { get; set; }
        public DateTime _fecharegistro { get; set; } 
        public String _color { get; set; } 
        public bool _disponibilidad { get; set; }
        public String _transmision { get; set; } 
        public String _pais { get; set; } 
    }
}