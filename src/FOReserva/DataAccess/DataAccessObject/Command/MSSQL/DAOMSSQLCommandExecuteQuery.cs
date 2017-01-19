using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject.Common;
using System.Data.SqlClient;

namespace FOReserva.DataAccess.DataAccessObject.Command.MSSQL
{
    public class DAOMSSQLCommandExecuteQuery : DAOMSSQLCommand
    {
        public DAOMSSQLCommandExecuteQuery(DAOMSSQL instance) : base(instance)
        {
        }

        public override DAOResult doThis(params object[] args)
        {
            var query = (String)args[0];
            var doThis = (FOReserva.DataAccess.DataAccessObject.Common.DAO.ForEachRow)args[1];
            DAOResult result = FabricDAO.CreateDAOResult();
            try
            {
                if (this.instance.Connection.State == System.Data.ConnectionState.Open)
                {
                    this.instance.Command = new SqlCommand(query, this.instance.Connection);
                    using (SqlDataReader reader = this.instance.Command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (doThis == null)
                                break;
                            doThis(reader);
                        }
                    }
                    this.instance.Command.Dispose();
                    result.ProcessFinishCorrectly = true;
                    result.Message = "OK!";
                }
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke DAOMSSQLCommandExecuteQuery.doThis.", exception);
            }
            return result;
        }
    }
}