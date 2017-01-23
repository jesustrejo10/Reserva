using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M13
{
    /// <summary>
    /// Clase que maneja las excepciones del módulo 13
    /// </summary>
    public class ReservaExceptionM13 : ExceptionBD
    {
        /// <summary>
        /// Excepcion Reserva M13
        /// </summary>
        public ReservaExceptionM13() : base() { }

        /// <summary>
        /// Excepcion Reserva M13
        /// </summary>
        /// <param name="message"></param>
        public ReservaExceptionM13(string message) : base(message) { }

        /// <summary>
        /// Excepcion Reserva MM13
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM13(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Excepcion Reserva MM13
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ReservaExceptionM13(string codigo, string message, Exception inner) : base(codigo, message, inner) { }
    }
}