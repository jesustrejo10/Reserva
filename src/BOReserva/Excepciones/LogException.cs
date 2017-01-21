using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones
{
    /// <summary>
    /// Exception de la Libreria log4net para llevar bitacura del sistema
    /// </summary>
    public class LogException: ExceptionReserva
    {
        /// <summary>
        /// Excepcion Log
        /// </summary>
        public LogException(): base() { }

        /// <summary>
        /// Excepcion Log
        /// </summary>
        /// <param name="message"></param>
        public LogException(string message): base(message){  }

        /// <summary>
        /// Excepcion Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public LogException(string message, Exception inner): base(message, inner) {}

        /// <summary>
        /// Excepcion Log
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public LogException(string codigo, string message, Exception inner) : base(codigo, message, inner){}

    }
}