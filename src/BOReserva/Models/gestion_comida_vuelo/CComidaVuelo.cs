using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CComidaVuelo
    {
        public int _id { get; set; }
        public int _fkvuelo { get; set; }
        public int _fkcomida { get; set; }
        public int _cantidad { get; set; }

        public CComidaVuelo() { }
        public CComidaVuelo(int id, int fkvuelo, int fkcomida, int cantidad)
        {
            _id = id;
            _fkvuelo = fkvuelo;
            _fkcomida = fkcomida;
            _cantidad = cantidad;
        }
    }
}