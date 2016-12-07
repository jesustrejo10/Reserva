using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_cruceros
{
    public class CGestion_crucero
    {
        public String _nombreCrucero { get; set; }
        public String _companiaCrucero { get; set; }
        public int _capacidadCrucero { get; set; }
        public String _estatus { get; set; }
        public String _imagen { get; set; }
        public CGestion_cabina[] _cabina { get; set; }

        public CGestion_crucero(String nombreCrucero, String companiaCrucero, 
            int capacidadCrucero, String estatus, String imagen, CGestion_cabina[] cabina)
        {
            _nombreCrucero = nombreCrucero;
            _companiaCrucero = companiaCrucero;
            _capacidadCrucero = capacidadCrucero;
            _estatus = estatus;
            _imagen = imagen;
            _cabina = cabina;
        }
        public CGestion_crucero()
        {
            _nombreCrucero = null;
            _companiaCrucero = null;
            _capacidadCrucero = 0;
            _estatus = null;
            _imagen = null;
            CGestion_cabina[] _cabina = {};
        }
    }
}