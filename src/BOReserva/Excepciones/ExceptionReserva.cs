using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones
{
    /// <summary>
    /// Excepcion General del Proyecto Reserva
    /// </summary>
    public class ExceptionReserva: Exception
    {
        #region Atributos
        private string _Codigo;
        private string _Mensaje;
        private Exception _Excepcion;
        #endregion

        #region Constructores

        public ExceptionReserva(): base() { }
        public ExceptionReserva(string message): base(message) { }

        public ExceptionReserva(string message, Exception inner):base(message,inner) { }

        public ExceptionReserva(string codigo, string message, Exception inner): base(message, inner)
	        {
            Codigo = codigo;
            Mensaje = message;
            Excepcion = inner;
            }
        #endregion

        #region Propiedades
        public string Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return _Mensaje;
            }

            set
            {
                _Mensaje = value;
            }
        }

        public Exception Excepcion
        {
            get
            {
                return _Excepcion;
            }

            set
            {
                _Excepcion = value;
            }
        }
        #endregion
    }
}