using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    public class FabricDAO
    {

        #region M20
        public static FOReserva.DataAccess.DataAccessObject.Common.DAO CreateDAORevision()
        {
            return new DAORevision();
        }
        #endregion

        #region Global
        public static String GetConnectionString(string name)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[name].ConnectionString;
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(connectionString);
            return builder.ProviderConnectionString;
        }

        public static IDAO CreateDAOMSSQL()
        {
            return new DAOMSSQL();
        }


        public static SqlConnection CreateConnectionDBReserva()
        {
            string connection = FabricDAO.GetConnectionString("DBReserva");
            return new SqlConnection(connection);
        }

        public static DAOResult CreateDAOResult() {
            return new DAOResult();
        }
        #endregion
    }
}