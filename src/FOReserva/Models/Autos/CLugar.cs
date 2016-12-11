using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Autos
{
    public class CLugar
    {
        public CLugar(string id, string nombre)
        {
            Id = id;
            Name = nombre;    
        }

        public string Id { get; set; }
        public string Name { get; set; }

    }
}