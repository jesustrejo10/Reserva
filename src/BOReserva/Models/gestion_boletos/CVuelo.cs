using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_boletos
{
    public class CVuelo
    {
        public int _id { get; set; }

        public String _origen { get; set; }

        public String _destino { get; set; }

        public DateTime _fechaPartida { get; set; }

        public DateTime _fechaLlegada { get; set; }

        public double _monto { get; set; }

        public CVuelo(int id, string origen, string destino, DateTime fechasal, 
                     DateTime fechalleg) {
              _id = id;
              _origen = origen;
              _destino = destino;
              _fechaPartida = fechasal;
              _fechaLlegada = fechalleg;
        }
    }
}