using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Model
{
    /// <summary>
    /// Clase Connection, es un singleton utilizado para solo realizar una sola instancia contra la coneccion de la BD
    /// </summary>
    public class Connection
    {
        private SqlConnection _connection;
        private static Connection _instance;
        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        /// <param name="connetionString"></param>
        private Connection(String connetionString)
        {
            this._connection = new SqlConnection(connetionString);
        }

        /// <summary>
        /// Si ya se encuentra instanciada la clase la retorna, si no, crea una nueva instancia y la retorna
        /// </summary>
        /// <param name="connectionString"> String destinado a establecer la conexion contra la bd</param>
        /// <returns> Se retornara la conexion contra la BD</returns>
        public static SqlConnection getInstance(String connectionString){
            try
            {
                if (_instance == null)
                {
                    _instance = new Connection(connectionString);
                }
                return _instance._connection;
            }
            catch (SqlException e)
            {
                Debug.WriteLine("Ocurrio un SQL Exception"+e.ToString());

                return null;
                //imprimir mensjae y manejar error de conexion
            }
            catch (Exception e) 
            {
                return null;
            }
        }
    }
}










