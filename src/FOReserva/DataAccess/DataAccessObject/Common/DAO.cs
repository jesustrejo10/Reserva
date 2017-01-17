using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    /* Imcompleto. */
    public class DAO : IDAO
    {        
        private SqlConnection connection;
        // El String de conexion se encuentra en el archivo Web.config
        private SqlCommand command;

        public delegate void ForEachRow(SqlDataReader reader);

        protected DAOResult buildDAOResult()
        {
            return new DAOResult();
        }

        public DAOResult OpenConexion(string conexion) {
            DAOResult dao = buildDAOResult();
            try
            {
                if (this.connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DBReserva"].ConnectionString;
                    this.connection = new SqlConnection(connectionString);
                }
                this.connection.Open();
            }
            catch (Exception exception)
            {
                dao.Message += exception.Message;
                dao.Result = exception;
            }
            return dao;
        }        

        public DAOResult ExcecuteQuery(string query, ForEachRow doThis = null)
        {
            DAOResult dao = buildDAOResult();
            try
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (doThis == null)
                                break;
                            doThis(reader);
                        }
                    }
                    cmd.Dispose();
                }
            }
            catch (Exception exception)
            {
                dao.Message += exception.Message;
                dao.Result = exception;
            }
            return dao;
        }

        public DAOResult ExcecuteNoQuery(string query)
        {
            DAOResult dao = buildDAOResult();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception exception)
            {
                dao.Message += exception.Message;
                dao.Result = exception;
            }
            return dao;
        }

        public DAOResult CloseConexion()
        {
            DAOResult dao = buildDAOResult();
            try
            {
                if (this.connection != null)
                {
                    this.connection.Close();
                }                
            }
            catch (Exception exception)
            {
                dao.Message += exception.Message;
                dao.Result = exception;
            }
            return dao;
        }
    }
}