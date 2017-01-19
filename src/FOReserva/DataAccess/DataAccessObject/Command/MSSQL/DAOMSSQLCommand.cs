using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject.Common;

namespace FOReserva.DataAccess.DataAccessObject.Command.MSSQL
{
    public abstract class DAOMSSQLCommand : IDAOCommand
    {
        protected DAOMSSQL instance;

        public DAOMSSQLCommand(DAOMSSQL instance)
        {
            this.instance = instance;
        }

        public abstract DAOResult doThis(params object[] args);
    }
}