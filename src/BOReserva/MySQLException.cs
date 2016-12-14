using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva
{

    /// <summary>
    /// Clase de excepciones personalizada para obtener las exceptiones generales del sistema.
    /// </summary>
    public class MyGeneralException : Exception
    {
        private SqlException _SqlException;
        private String _Message;
        private String _From;
        private Exception _Exception;

        /// <summary>
        /// Constructor para la clase MyGeneralException en caso de que ocurra un SqlException
        /// </summary>
        /// <param name="sqlException">Parametro tipo SqlException</param>
        /// <param name="message">Parametro de tipo string, para guardar el mensaje personalizdo de la exception</param>
        /// <param name="from">Parametro de tripo string, es usado para almacenar el nombre de la clase en la que ocurrio 
        ///                     la exception</param>
        public MyGeneralException(SqlException sqlException, String message, String from)
        {
            this._SqlException = sqlException;
            this._Message = message;
            this._From = from;
        }
        /// <summary>
        /// Constructor para la clase MyGeneralException en caso de que ocurra una excepcion comun
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="from"></param>
        public MyGeneralException(Exception exception, String message, String from)
        {
            this._Exception = exception;
            this._Message = message;
            this._From = from;
        }
    }
}