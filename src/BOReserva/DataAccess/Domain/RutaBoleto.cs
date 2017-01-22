using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class RutaBoleto
    {
        public int _id { get; set; }

        public int _origen { get; set; }

        public int _destino { get; set; }

        public String _nomOrigen { get; set; }

        public String _nomDestino { get; set; }

        public RutaBoleto(int id, int ori, int dest, String nombre1, String nombre2)
        {
            _id = id;
            _origen = ori;
            _destino = dest;
            _nomOrigen = nombre1;
            _nomDestino = nombre2;
        }
    }
}