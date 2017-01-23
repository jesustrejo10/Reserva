using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M10
{
    /// <summary>
    /// Excepcion General M10
    /// </summary>
    public class ReservaExceptionM10 : ExceptionBD
    {
        /// <summary>
        /// Excepcion Reserva M10
        /// </summary>
        public ReservaExceptionM10(): base() {}

        /// <summary>
        /// Excepcion Reserva M10
        /// </summary>
        /// <param name="message"></param>
        public ReservaExceptionM10(string message): base(message) {}

        /// <summary>
        /// Excepcion Reserva M10
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM10(string message, Exception inner) : base(message, inner) {}

        /// <summary>
        /// Excepcion Reserva M10
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM10(string codigo, string message, Exception inner) : base(codigo, message, inner) {}
    }
}