using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M11
{
    /// <summary>
    /// Clase que maneja las excepciones para el módulo 11 de gestión de ofertas y paquetes
    /// </summary>
    public class ReservaExceptionM11 : Exception
    {
        private string _Codigo;
        private string _Mensaje;
        private Exception _Excepcion;
        /// <summary>
        /// Get y set del código
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Get y set del mensaje
        /// </summary>
        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }


        /// <summary>
        /// Get y set de la excepción
        /// </summary>
        public Exception Excepcion
        {
            get { return _Excepcion; }
            set { _Excepcion = value; }
        }

          /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="inner">Excepción SqlException</param>
        public ReservaExceptionM11(string mensaje, SqlException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un problema con la base de datos. Para mayor detalle revise el log de errores.";
            _Excepcion = inner;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="inner">Excepcion NullReferenceException</param>
        public ReservaExceptionM11(string mensaje, NullReferenceException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un problema con una referencia nula. Para mayor detalle revise el log de errores.";
            _Excepcion = inner;
        }

        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="inner">Excepción ArgumentNulException</param>
        public ReservaExceptionM11(string mensaje, ArgumentNullException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un problema con un argumento nulo. Para mayor detalle revise el log de errores.";
            _Excepcion = inner;
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="inner">Excepción Exception</param>
        public ReservaExceptionM11(string mensaje, Exception inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un error desconocido. Para mayor detalle revise el log de errores.";
            _Excepcion = inner;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="inner">Excepción Exception</param>
        public ReservaExceptionM11(string mensaje, LogException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un error al escribir el log.";
            _Excepcion = inner;
        }

    }
}