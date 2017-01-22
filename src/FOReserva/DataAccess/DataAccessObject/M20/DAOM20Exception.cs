using FOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.M20
{
    public class DAOM20Exception : Exception
    {
        public DAOM20Exception(string mensaje) : base(mensaje) { }
        public DAOM20Exception(string mensaje, Exception interna) : base(mensaje, interna) { }
    }
}