using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Servicio
{
    public class ManejadorSQLException : Exception
    {
        public ManejadorSQLException(string mensaje, Exception e) : base(mensaje, e)
        { }

        public ManejadorSQLException(string mensaje ) : base( mensaje )
        { }
    }
}