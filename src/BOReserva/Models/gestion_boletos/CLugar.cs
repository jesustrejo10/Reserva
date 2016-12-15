using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_boletos
{
    public class CLugar
    {
        public CLugar(string id, string nombre){
            Id = id;
            Name = nombre;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

