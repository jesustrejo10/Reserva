using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaBoleto
{
    public class CLugar
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public CLugar(string id, string nombre)
        {
            Id = id;
            Name = nombre;
        }
        
    }
}