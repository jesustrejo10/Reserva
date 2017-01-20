using FOReserva.DataAccess.DataAccessObject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Command
{
    public interface IDAOCommand
    {
        DAOResult doThis(params object [] args);
    }
}