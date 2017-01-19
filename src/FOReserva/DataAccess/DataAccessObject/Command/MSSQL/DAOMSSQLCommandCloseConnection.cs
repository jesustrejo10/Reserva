using FOReserva.DataAccess.DataAccessObject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Command.MSSQL
{
    public class DAOMSSQLCommandCloseConnection : DAOMSSQLCommand
    {
        public DAOMSSQLCommandCloseConnection(DAOMSSQL instance) : base(instance)
        {
        }

        public override DAOResult doThis(params object[] args)
        {
            DAOResult result = FabricDAO.CreateDAOResult();
            try
            {
                if (this.instance.Connection != null)
                {
                    this.instance.Connection.Close();
                    result.ProcessFinishCorrectly = true;
                    result.Message = "OK!";
                }
                else
                {
                    throw new DAOException("The connection is not open.");
                }
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke CloseConnection.", exception);
            }
            return result;
        }
    }
}