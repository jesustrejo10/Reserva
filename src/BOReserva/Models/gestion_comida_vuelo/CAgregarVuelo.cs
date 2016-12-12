using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CAgregarVuelo
    {
        public int _id { get; set; }
        public int _fkvuelo { get; set; }
        public int _fkcomida { get; set; }
        public int _cantidad { get; set; }
    }
}