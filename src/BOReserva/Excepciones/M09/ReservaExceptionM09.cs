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
    public class ReservaExceptionM09 : Exception
    {
        private string _Codigo;
        private string _Mensaje;
        private Exception _Excepcion;

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

        public ReservaExceptionM09(string mensaje, SqlException inner)
        {
            _Mensaje = "Ha ocurrido un problema con la base de datos. Error: "+ mensaje;
            _Excepcion = inner;
        }

        public ReservaExceptionM09(string mensaje, ExceptionBD inner)
        {
            _Mensaje = "Ha ocurrido un problema con la base de datos. Error: " + mensaje;
            _Excepcion = inner;
        }
        public ReservaExceptionM09(string mensaje, NullReferenceException inner)
        {
            _Mensaje = "Ha ocurrido un problema con una referencia nula. Error: " +  mensaje;
            _Excepcion = inner;
        }

        public ReservaExceptionM09(string mensaje, ArgumentNullException inner)
        {
            _Mensaje = "Ha ocurrido un problema con un argumento nulo. Error: " +  mensaje;
            _Excepcion = inner;
        }
        public ReservaExceptionM09(string mensaje, Exception inner)
        {
            _Mensaje = "Ha ocurrido un error desconocido. Error: " + mensaje;
            _Excepcion = inner;
        }
    }
}