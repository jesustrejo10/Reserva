using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_check_in
{
    public class CBoardingPass
    {
        public int _id { get; set; }
        public DateTime _fechaPartida { get; set; }

        public DateTime _fechaLlegada { get; set; }

        public int _boleto { get; set; }
        
        public int _origen { get; set; }

        public int _destino { get; set; }

        public String _asiento { get; set; }

        public int _vuelo { get; set; }

        public String _nombre { get; set; }
        public String _apellido{ get; set; }

        public String _nombreOri { get; set; }
        public String _nombreDest { get; set; }

        public String _horaPartida { get; set; }

        public CBoardingPass() { }

        public CBoardingPass(int id, String nombre1, String nombre2, int vuelo) {
            _id = id;
            _nombreOri = nombre1;
            _nombreDest = nombre2;
            _vuelo = vuelo;
        }
  
    }
}