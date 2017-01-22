using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Sesion
{
    public class ExisteUsuarioCorreoException : Exception
    {
        public ExisteUsuarioCorreoException() : base("El usuario ya existe.") { }
        public ExisteUsuarioCorreoException(Exception interna) : base("El usuario ya existe.", interna) { }
    }
}