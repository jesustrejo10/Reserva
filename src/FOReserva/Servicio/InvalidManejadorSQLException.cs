using System;

namespace FOReserva.Servicio
{
    public class InvalidManejadorSQLException : Exception
    {
        public InvalidManejadorSQLException(string mensaje, Exception e) : base(mensaje, e)
        { }

        public InvalidManejadorSQLException(string mensaje) : base( mensaje )
        { }
    }
}