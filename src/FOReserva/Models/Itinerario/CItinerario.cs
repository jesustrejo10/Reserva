using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Servicio;
using System.ComponentModel.DataAnnotations;

namespace FOReserva.Models.Itinerario
{
    public class CItinerario
    {
        public CItinerario() { }

        public String _ciudad { get; set; }
        public String _fecha { get; set; }
        public IEnumerable<SelectListItem> _lciudad { get; set; }
        public IEnumerable<SelectListItem> _lfecha { get; set; }
        public String _actividad { get; set; }


        public CItinerario(string ciudad, string fecha, List<SelectListItem> lciudad, List<SelectListItem> lfecha, string actividad)
        {
            this._ciudad = ciudad;
            this._fecha = fecha;
            this._lciudad = lciudad;
            this._lfecha = lfecha;
            this._actividad = actividad;
        }
    }
}