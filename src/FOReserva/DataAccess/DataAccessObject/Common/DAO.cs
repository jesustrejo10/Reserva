using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    public class DAO : IDAO
    {
        #region Patron Singleton.
        private static IDAO instance = null;

        private static IDAO Singleton()
        {
            if (DAO.instance == null)
                DAO.instance = FabricDAO.CreateDAOMSSQL();
            return DAO.instance;
        }
        #endregion

        #region Implementacion de Primitivas DAO.
        public DAOResult CloseConnection()
        {
            return DAO.Singleton().CloseConnection();
        }

        public delegate void ForEachRow(SqlDataReader reader);

        public DAOResult ExecuteNoQuery(string query)
        {
            return DAO.Singleton().ExecuteNoQuery(query);
        }

        public DAOResult ExecuteQuery(string query, ForEachRow doThis = null)
        {
            return DAO.Singleton().ExecuteQuery(query, doThis);
        }

        public DAOResult ExecuteStoreProcedure(string name, object parameters)
        {
            return DAO.Singleton().ExecuteStoreProcedure(name, parameters);
        }

        public DAOResult ExecuteStoreProcedureWithResult(string name, object parameters, ForEachRow doThis = null)
        {
            return DAO.Singleton().ExecuteStoreProcedureWithResult(name, parameters, doThis);
        }

        public DAOResult OpenConnection()
        {
            return DAO.Singleton().OpenConnection();
        }
        #endregion
    }
}