using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CComidaVuelo
    {
        public int _idVuelo { get; set; }
        public string _codigoVuelo { get; set; }
        public int _idComida { get; set; }
        public string _nombrePlato { get; set; }
        public int _cantidadComida { get; set; }
        public IEnumerable<SelectListItem> _nombrePlatos { get; set; }
    }
}