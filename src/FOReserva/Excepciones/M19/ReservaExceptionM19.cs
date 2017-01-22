using FOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Excepciones.M19
{
    public class ReservaExceptionM19 : ExceptionBD
    {
         /// <summary>
        /// Excepcion Reserva M19
        /// </summary>
        public ReservaExceptionM19(): base() {}

        /// <summary>
        /// Excepcion Reserva M19
        /// </summary>
        /// <param name="message"></param>
        public ReservaExceptionM19(string message): base(message) {}

        /// <summary>
        /// Excepcion Reserva M19
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM19(string message, Exception inner) : base(message, inner) {}

        /// <summary>
        /// Excepcion Reserva M19
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM19(string codigo, string message, Exception inner) : base(codigo, message, inner) {}
    }
}