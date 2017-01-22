using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Restaurante : Entidad
    {
        private string _address {get; set;}
        private string _description { get; set; }
        private string _open { get; set; }
        private string _close { get; set; }
        private Lugar _city { get; set; }

        public Restaurante(string address, string description, string open, string close, Lugar city)
        {
            _address = address;
            _description = description;
            _open = open;
            _close = close;
            _city = city;
 

        }
    }
}