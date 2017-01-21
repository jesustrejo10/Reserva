using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject.Common;
using FOReserva.DataAccess.DataAccessObject.Common.Interface;

namespace FOReserva.DataAccess.DataAccessObject.Command.MSSQL
{
    public class DAOMSSQLCommandOpenConnection : DAOMSSQLCommand
    {
        public DAOMSSQLCommandOpenConnection(DAOMSSQL instance) : base(instance)
        {
        }

        public override DAOResult doThis(params object[] args)
        {
            DAOResult result = FabricDAO.CreateDAOResult();
            try
            {
                if (instance.Connection == null)
                {
                    instance.Connection = FabricDAO.CreateConnectionDBReserva();
                }
                instance.Connection.Open();
                result.ProcessFinishCorrectly = true;
                result.Message = "OK!";
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke DAOMSSQLCommandOpenConnection.doThis.", exception);
            }
            return result;
        }
    }
}