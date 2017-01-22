using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M04
{
    public class ReservaExceptionM04 : Exception
    {
        /// <summary>
        /// Constructor de la clase de excepciones de Reserva Modulo 12
        /// </summary>
        /// <param name="codigo">Codigo de la excepcion</param>
        /// <param name="mensaje">Mensaje de error</param>
        /// <param name="inner">Inner del mensaje</param>
        public ReservaExceptionM04( String codigo , String mensaje , Exception inner ) 
               :base( mensaje , inner ) 
        {

        }

        public ReservaExceptionM04(String codigo, String mensaje)
            :base(mensaje)
        {

        }
        /// <summary>
        /// Constructor de la clase de excepciones de Reserva Modulo 12
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        /// <param name="inner">Inner del mensaje</param>
        public ReservaExceptionM04(String mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }


    }
}