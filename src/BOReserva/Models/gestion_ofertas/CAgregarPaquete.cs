using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ofertas
{
    public class CAgregarPaquete
    {

        public String _idPaquete { get; set; }

        public String _nombrePaquete { get; set; }

        public String _nombreHabitacion { get; set; }

        public String _nombreCrucero { get; set; }

        public String _nombreVuelo { get; set; }

        public String _nombreAuto { get; set; }

        public String _nombreRestaurante { get; set; }

        public float _precioPaquete { get; set; }

        public int _seleccionAuto { get; set; }

        public int _seleccionRestaurante { get; set; }

        public int _seleccionHabitacion { get; set; }

        public int _seleccionCrucero { get; set; }

        public int _seleccionVuelo { get; set; }

        public DateTime _fechaIniAuto { get; set; }

        public DateTime _fechaIniRest { get; set; }

        public DateTime _fechaIniHabi { get; set; }

        public DateTime _fechaIniCruc { get; set; }

        public DateTime _fechaIniVuelo { get; set; }
                              
        public DateTime _fechaFinAuto { get; set; }
                              
        public DateTime _fechaFinRest { get; set; }
                              
        public DateTime _fechaFinHabi { get; set; }
                              
        public DateTime _fechaFinCruc { get; set; }
                              
        public DateTime _fechaFinVuelo { get; set; }
    }
}