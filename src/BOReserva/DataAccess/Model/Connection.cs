using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Model
{
    public class Connection
    {
        private static SqlConnection _connection;
        private Connection(String connetionString)
        {
            _connection = new SqlConnection(connetionString);
        }

        public static SqlConnection getInstance(String connectionString){
            try
            {
                if (_connection == null)
                {
                   // _connection = new Connection(connectionString)._;
                }
                return null;
            }
            catch(SqlException e)
            {
                return null;
               //imprimir mensjae y manejar error de conexion
            }
        }
    }
}