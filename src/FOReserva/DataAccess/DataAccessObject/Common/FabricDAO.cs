using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    public class FabricDAO
    {
        public static String GetConnectionString(string name)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[name].ConnectionString;
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(connectionString);
            return builder.ProviderConnectionString;
        }

        internal static DAORevision CreateDAORevicion()
        {
            return new DAORevision();
        }

        public static SqlConnection CreateConnection()
        {
            string connection = FabricDAO.GetConnectionString("DBReserva");
            return new SqlConnection(connection);
        }
    }
}