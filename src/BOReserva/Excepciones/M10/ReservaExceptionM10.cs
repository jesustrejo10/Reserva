using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M10
{
    public class ReservaExceptionM10 : ExceptionBD
    {
        public ReservaExceptionM10(): base()
        { }

        public ReservaExceptionM10(string message): base(message)
        {
        }

        public ReservaExceptionM10(string message, Exception inner) : base(message, inner)
        {
        }

        public ReservaExceptionM10(string codigo, string message, Exception inner) : base(codigo, message, inner)
        {
        }
    }
}