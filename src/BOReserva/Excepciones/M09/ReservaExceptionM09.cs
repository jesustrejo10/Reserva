using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace BOReserva.Excepciones.M09
{
    /// <summary>
    /// Clase que maneja las excepciones para el modulo 9
    /// </summary>
    public class ReservaExceptionM09 : Exception
    {
        private string _Codigo;
        private string _Mensaje;
        private Exception _Excepcion;
        /// <summary>
        /// Get y set de codigo
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }


        /// <summary>
        /// Get y set de mensaje
        /// </summary>
        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }


        /// <summary>
        /// Get y set de excepcion
        /// </summary>
        public Exception Excepcion
        {
            get { return _Excepcion; }
            set { _Excepcion = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion SqlException</param>
        public ReservaExceptionM09(string mensaje, SqlException inner)
        {
            if ((inner.Message.Contains("paq_fk_hotel")))
            {
                _Mensaje = "Reserva-404: No se puede eliminar el hotel porque tiene paquetes vacacionales asociados. Para mayor detalle revisar el Log de errores";
                _Excepcion = inner;
            }
            else if (inner.Message.Contains("rha_fk_hot_id"))
                {
                    _Mensaje = "Reserva-404: No se puede eliminar el hotel porque tiene reservaciones de habitaciones asocidas. Para mayor detalle revisar el Log de errores";
                    _Excepcion = inner;
                }
            else
            {
                _Mensaje = "Reserva-404: Ha ocurrido un problema con la base de datos. Para mayor detalle revisar el Log de errores";
                _Excepcion = inner;
            }
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion ExceptionBD</param>
        public ReservaExceptionM09(string mensaje, ExceptionBD inner)
        {
            if (inner.InnerException.Message.Contains("Reserva_Habitacion"))
            {
                _Mensaje = "Reserva-404: Ese hotel tiene reservaciones, por ende no se puede eliminar del sistema";
                _Excepcion = inner;
            }
            else
            {
                _Mensaje = "Reserva-404: Ha ocurrido un problema con la base de datos. Para mayor detalle revisar el Log de errores";
                _Excepcion = inner;
            }
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion NullReferenceException</param>
        public ReservaExceptionM09(string mensaje, NullReferenceException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un problema con una referencia nula. Para mayor detalle revisar el Log de errores";
            _Excepcion = inner;
        }

        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion ArgumentNulException</param>
        public ReservaExceptionM09(string mensaje, ArgumentNullException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un problema con un argumento nulo. Para mayor detalle revisar el Log de errores";
            _Excepcion = inner;
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion Exception</param>
        public ReservaExceptionM09(string mensaje, Exception inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un error desconocido. Para mayor detalle revisar el Log de errores";
            _Excepcion = inner;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion Exception</param>
        public ReservaExceptionM09(string mensaje, LogException inner)
        {
            _Mensaje = "Reserva-404: Ha ocurrido un error al escribir el log";
            _Excepcion = inner;
        }
    }
}