using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CAgregarVuelo
    {
        public int _idVuelo { get; set; }
        public int _idComida { get; set; }
        public int _cantidadComida { get; set; }
        public string _codigoVuelo { get; set; }
        public int _tipoClase { get; set; }
        public IEnumerable<SelectListItem> _nombrePlato { get; set; }
        public int _capacidadTurista { get; set; }
        public int _capacidadEjecutiva { get; set; }
        public int _capacidadVip { get; set; }
    }
}