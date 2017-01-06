using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Models.Sesion;

namespace FOReserva.Models.Sesion
{
    public class RegistroClienteException : Exception
    {

        public RegistroClienteException(string mensaje) : base(mensaje) {

        } 

    }
}