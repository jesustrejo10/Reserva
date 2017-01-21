using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Usuarios
{
    public class CUsuario : Entidad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}