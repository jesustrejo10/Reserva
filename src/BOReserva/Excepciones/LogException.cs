using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones
{
    public class LogException: ExceptionReserva
    {
        public LogException(): base()
        { }

        public LogException(string message): base(message)
        {  }

        public LogException(string message, Exception inner): base(message, inner)
        {
        }

        public LogException(string codigo, string message, Exception inner) : base(codigo, message, inner)
        {
        }

    }
}