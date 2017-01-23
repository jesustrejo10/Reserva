using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M08
{
    /// <summary>
    /// Excepcion General M10
    /// </summary>
    public class ReservaExceptionM08 : ExceptionBD
    {
        /// <summary>
        /// Excepcion Reserva M08
        /// </summary>
        public ReservaExceptionM08() : base() { }

        /// <summary>
        /// Excepcion Reserva M08
        /// </summary>
        /// <param name="message"></param>
        public ReservaExceptionM08(string message) : base(message) { }

        /// <summary>
        /// Excepcion Reserva M08
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM08(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Excepcion Reserva M08
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM08(string codigo, string message, Exception inner) : base(codigo, message, inner) { }
    }
}