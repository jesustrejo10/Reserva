using FOReserva.DataAccess.DataAccessObject.Command;
using FOReserva.DataAccess.DataAccessObject.Command.MSSQL;
using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FOReserva.DataAccess.DataAccessObject.Common
{    
    public class DAOMSSQL : IDAO
    {        
        private SqlConnection connection;
        // El String de conexion se encuentra en el archivo Web.config
        private SqlCommand command;

        public SqlConnection Connection { get; internal set; }

        public SqlCommand Command { get; internal set; }
        
        public DAOResult OpenConnection() {
            DAOMSSQLCommand withCommand = new DAOMSSQLCommandOpenConnection(this);
            return withCommand.doThis();
        }


        public DAOResult ExecuteQuery(string query, DAO.ForEachRow doThis = null)
        {
            //IDAOCommand withCommand = new DAOMSSQLCommandExecuteQuery(this);
            //return withCommand.doThis(query, doThis);
            return null;
        }

        public DAOResult ExecuteNoQuery(string query)
        {
            DAOMSSQLCommand withCommand = new DAOMSSQLCommandExecuteNoQuery(this);
            return withCommand.doThis(query);
        }

        public DAOResult ExecuteStoreProcedure(string name, object parameters) {
            DAOMSSQLCommand withCommand = new DAOMSSQLCommandExecuteStoreProcedure(this);
            return withCommand.doThis(name, parameters);
        }

        public DAOResult ExecuteStoreProcedureWithResult(string name, object parameters, DAO.ForEachRow doThis = null) {
            DAOMSSQLCommand withCommand = new DAOMSSQLCommandExecuteStoreProcedureWithResult(this);
            return withCommand.doThis(name, parameters, doThis);
        }

        public DAOResult CloseConnection()
        {
            IDAOCommand withCommand = new DAOMSSQLCommandCloseConnection(this);
            return withCommand.doThis();
        }
    }
}