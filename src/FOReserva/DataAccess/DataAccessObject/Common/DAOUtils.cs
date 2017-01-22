using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.Common
{
    public static class DAOUtils
    {
        public static void SetParametersByObject(this SqlCommand cmd, object parameters)
        {
            SqlDbType dbType = SqlDbType.BigInt;
            foreach (var field in parameters.GetType().GetProperties())
            {
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

    }
}