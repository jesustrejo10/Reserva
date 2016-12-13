using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaBoleto
{
    public class CVuelo
    {
        public int _id { get; set; }

        public DateTime _fechaPartida { get; set; }

        public DateTime _fechaLlegada { get; set; }
    }
}