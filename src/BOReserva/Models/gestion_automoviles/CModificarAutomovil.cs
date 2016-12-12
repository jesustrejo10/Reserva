using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    /// <summary>
    /// Clase del modelo de la vista parcial M08_ModificarAutomovil
    /// </summary>
    public class CModificarAutomovil
    {
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
        public String _fecharegistro { get; set; }
        public String _color { get; set; }
        public int _disponibilidad { get; set; }
        public String _transmision { get; set; }
        public String _pais { get; set; }
        public String _ciudad { get; set; }  
    }
}