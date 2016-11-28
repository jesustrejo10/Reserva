using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_restaurantes
{
    public class CRestauranteModelo
    {
        public string _nombre { get; set; }
        public string _tipoComida { get; set; }
        public string _direccion { get; set; }
        public List<DateTime> _horario { get; set; }
    }
}