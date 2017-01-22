using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M16
{
    public class ReservaExceptionM16 : Exception
    {
        /// <summary>
        /// Clase que maneja las excepciones del módulo para la gestión de reclamos
        /// </summary>
        private Exception _excepcion;
        private string _codigoException;
        private string _mensajeException;

        /// <summary>
        /// Get y set del codigo
        /// </summary>
        public string Codigo 
        {
            get { return _codigoException ; }
            set { _codigoException = value; }
        }

        /// <summary>
        /// Get y set del mensaje
        /// </summary>
        public string Mensaje
        {
            get { return _mensajeException; }
            set { _mensajeException = value; }
        }

        /// <summary>
        /// Get y set de excepcion
        /// </summary>
        public Exception Excepcion
        {
            get { return _excepcion; }
            set { _excepcion = value; }
        }
                
        public ReservaExceptionM16(string mensaje, SqlException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un problema con la base de datos. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        public ReservaExceptionM16(string mensaje, NullReferenceException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un problema con una referencia nula. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }
        public ReservaExceptionM16(string mensaje, ArgumentNullException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un problema con un argumento nulo. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        public ReservaExceptionM16(string mensaje, LogException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un error al escribir el log";
            _excepcion = inner;
        }

        public ReservaExceptionM16(string mensaje, Exception inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un error desconocido. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        
    }
}