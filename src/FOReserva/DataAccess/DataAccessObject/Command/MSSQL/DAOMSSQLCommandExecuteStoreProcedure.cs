using FOReserva.DataAccess.DataAccessObject.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Command.MSSQL
{
    public class DAOMSSQLCommandExecuteStoreProcedure : DAOMSSQLCommand
    {
        public DAOMSSQLCommandExecuteStoreProcedure(DAOMSSQL instance) : base(instance)
        {
        }

        public override DAOResult doThis(params object[] args)
        {
            var name = (string)args[0];
            var parameters = (object)args[1];
            DAOResult result = FabricDAO.CreateDAOResult();
            try
            {
                if (this.instance.Connection.State == System.Data.ConnectionState.Open)
                {
                    this.instance.Command = new SqlCommand(name, this.instance.Connection);
                    this.instance.Command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.instance.Command.SetParametersByObject(parameters);
                    this.instance.Command.ExecuteNonQuery();
                    this.instance.Command.Dispose();
                    result.ProcessFinishCorrectly = true;
                    result.Message = "OK!";
                }
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke DAOMSSQLCommandExecuteStoreProcedure.doThis.", exception);
            }
            return result;
        }
    }
}