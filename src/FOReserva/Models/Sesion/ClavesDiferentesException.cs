using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Sesion
{
    public class ClavesDiferentesException:Exception
    {
        public ClavesDiferentesException() : base("Las clasves son diferentes.") { }
        public ClavesDiferentesException(Exception interna) : base("Las clasves son diferentes.", interna) { }
    }
}