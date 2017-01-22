using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    public class DAOResult
    {
        public bool ProcessFinishCorrectly { get; set; }
        public string Message { get; set; }
        public object Exception { get; set; }

        public DAOResult()
        {
            ProcessFinishCorrectly = false;
            Message = "El proceso no culmino correctamente: ";
            Exception = null;
        }
    }
}
