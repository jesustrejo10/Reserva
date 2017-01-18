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
    public class DAO : IDAO
    {        
        private SqlConnection connection;
        // El String de conexion se encuentra en el archivo Web.config
        private SqlCommand command;

        public delegate void ForEachRow(SqlDataReader reader);

        protected DAOResult BuildDAOResult()
        {
            return new DAOResult();
        }

        public DAOResult OpenConnection() {
            DAOResult result = BuildDAOResult();
            try
            {
                if (this.connection == null)
                {
                    this.connection = FabricDAO.CreateConnection();
                }
                this.connection.Open();
                result.ProcessFinishCorrectly = true;
                result.Message = "OK!";
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke OpenConnection.", exception);
            }
            return result;
        }        

        public DAOResult ExecuteQuery(string query, ForEachRow doThis = null)
        {
            DAOResult result = BuildDAOResult();
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
                    result.ProcessFinishCorrectly = true;
                    result.Message = "OK!";
                }
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke ExecuteQuery.", exception);
            }
            return result;
        }

        public DAOResult ExecuteNoQuery(string query)
        {
            DAOResult result = BuildDAOResult();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                result.ProcessFinishCorrectly = true;
                result.Message = "OK!";
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke ExecuteNoQuery.", exception);
            }
            return result;
        }

        public DAOResult ExecuteStoreProcedure(string name, object parameters) {
            DAOResult result = BuildDAOResult();
            try
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(name, this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    this.SetParameters(ref cmd, parameters);                                        
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    result.ProcessFinishCorrectly = true;
                    result.Message = "OK!";
                }
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke ExecuteQuery.", exception);
            }
            return result;
        }

        private void SetParameters(ref SqlCommand cmd, object parameters)
        {
            SqlDbType dbType = SqlDbType.BigInt;
            foreach (var field in parameters.GetType().GetProperties())
            {
                //Debug.WriteLine(String.Format("Field: {0}, {1}, {2}", field.Name, field.PropertyType.Name, field.GetValue(revision)));

                if (field.PropertyType == typeof(int))
                {
                    dbType = SqlDbType.Int;
                }
                else if (field.PropertyType == typeof(long))
                {
                    dbType = SqlDbType.BigInt;
                }
                else if (field.PropertyType == typeof(string))
                {
                    dbType = SqlDbType.VarChar;
                }
                else if (field.PropertyType == typeof(DateTime))
                {
                    dbType = SqlDbType.DateTime2;
                }
                else if (field.PropertyType == typeof(Enum))
                {
                    dbType = SqlDbType.Int;
                }
                else
                {
                    throw new DAOException(String.Format("It was not possible to determine an equivalent data type ({0}).", field.PropertyType.Name));
                }

                cmd.Parameters.Add(new SqlParameter(field.Name, dbType)).Value = field.GetValue(parameters);
            }
        }

        public DAOResult ExecuteStoreProcedureWithResult(string name, object parameters, ForEachRow doThis = null) {
            DAOResult result = BuildDAOResult();
            try
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(name, this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    this.SetParameters(ref cmd, parameters);
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
                    result.ProcessFinishCorrectly = true;
                    result.Message = "OK!";
                }
            }
            catch (Exception exception)
            {
                result.Message += exception.Message;
                result.Exception = new DAOException("Error on trying invoke ExecuteQuery.", exception);
            }
            return result;
        }

        public DAOResult CloseConnection()
        {
            DAOResult result = BuildDAOResult();
            try
            {
                if (this.connection != null)
                {
                    this.connection.Close();
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