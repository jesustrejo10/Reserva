using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    public class DAOException : Exception
    {
        public DAOException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public DAOException(string message) : base(message)
        {

        }
    }
}