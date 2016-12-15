using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Servicio;
using System.ComponentModel.DataAnnotations;

namespace FOReserva.Models.Itinerario
{
    public class Cvista_Itinerario
    {
        public Cvista_Itinerario() { }

        public int _id { get; set; }
        public String _ciudad { get; set; }
        public String _fecha { get; set; }
        public IEnumerable<SelectListItem> _lciudad { get; set; }
        public IEnumerable<SelectListItem> _lfecha { get; set; }
        public String _actividad { get; set; }
        public int _boleto { get; set; }
        public int _crucero { get; set; }


     
    }


}