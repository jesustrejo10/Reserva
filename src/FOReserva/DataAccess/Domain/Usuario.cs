using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Usuario : Entidad
    {
        public int Codigo { get; set; }
                
        public string Nombre { get; set; }

        public Usuario(int id, String name)
        {
            this.Codigo = id;
            this.Nombre = name;
        }
    }
}