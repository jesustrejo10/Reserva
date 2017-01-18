using FOReserva.DataAccess.DataAccessObject.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Command.MSSQL
{
    public class DAOMSSQLCommandExecuteNoQuery : IDAOCommand
    {
        private DAOMSSQL instance;

        public DAOMSSQLCommandExecuteNoQuery(DAOMSSQL instance)
        {
            this.instance = instance;
        }

        public DAOResult doThis(params object[] args)
        {
            var query = (String)args[0];
            var doThis = (DAO.ForEachRow)args[1];
            DAOResult result = FabricDAO.CreateDAOResult();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.instance.Connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                result.ProcessFinishCorrectly = true;
                result.Message = "OK!";
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke DAOMSSQLCommandExecuteNoQuery.doThis.", exception);
            }
            return result;
        }
    }
}