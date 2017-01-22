using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Model
{
    public class ExceptionBD : Exception
    {
        private string _Codigo;
        private string _Mensaje;
        private Exception _Excepcion;


        public ExceptionBD () 
            : base()
        {

        }

        public ExceptionBD(string mensaje)
            : base(mensaje)
        {

        }

        public ExceptionBD(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }

        public ExceptionBD(string codigo, string mensaje, Exception inner)
            : base(mensaje, inner)
        {
            _Codigo = codigo;
            _Mensaje = mensaje;
            _Excepcion = inner;
        }



        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }

        public Exception Excepcion
        {
            get { return _Excepcion; }
            set { _Excepcion = value; }
        }
    }
}