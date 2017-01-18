using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

//IMPORTANTE AGREGAR EL USING DE SUS RESPECTIVAS CLASES PARA PODER AGREGAR EL METODO DE AGREGAR/CONSULTAR

namespace FOReserva.Servicio
{
    public class manejadorSQL
    {
        /// <summary>
        /// ATENCIÓN: Esta clase no debería usarse más, se deja por motivos de compatibilidad para los grupos que aún no han migrado a DAO.
        /// </summary>
        //Inicializo el string de conexion en el constructor
        public manejadorSQL()
        {
            stringDeConexion = ConfigurationManager.ConnectionStrings["StringRemoto"].ConnectionString;
        }
        //Atributo que ejecutara la conexion a la bd
        private SqlConnection conexion = null;
        //string que contendra la conexion a la bd
        private string stringDeConexion = null;

        public string getStringConexion()
        {
            return this.stringDeConexion;
        }

        public void setStringConexion(string conector)
        {
            this.stringDeConexion = conector;
        }

        /*Metodo para Abrir la conexion a la DB*/
        private void OpenConnection()
        {
            conexion = new SqlConnection(stringDeConexion);
            try
            {
                conexion.Open();
            }
            catch (SqlException e)
            {
                throw new ManejadorSQLException("Error de conexion con la DB", e);
            }
        }

        /*Metodo para Cerrar la Conexion a la DB*/
        public void CloseConnection()
        {
            if (conexion != null)
            {
                conexion.Close();
                conexion = null;
            }
        }

        /*Metodo Get de la conexion a la DB*/
        public SqlConnection Conexion
        {
            get { return conexion; }
        }

        /*Metodo para la accion de un query*/
        public SqlDataReader Executer(string query)
        {
            OpenConnection();
            SqlCommand execute = this.Conexion.CreateCommand();
            execute.CommandText = query;
            SqlDataReader tmp = null;
            try
            {
                tmp = execute.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw new ManejadorSQLException("Error de conexion con la DB", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ManejadorSQLException("Operacion invalida en la DB", e);
            }
            return tmp;
        }

        /*Metodo para la accion de un query parametrizado con lista de SqlParameter*/
        public SqlDataReader Executer(string query, List<SqlParameter> parametros)
        {
            conexion = new SqlConnection(stringDeConexion);
            SqlCommand execute = new SqlCommand(query, conexion);
            foreach(SqlParameter p in parametros){
                execute.Parameters.Add(p);
            }
            SqlDataReader tmp = null;
            conexion.Open();

            //Para probar el query final
            string aaa = execute.CommandText;
            foreach (SqlParameter p in execute.Parameters)
            {
                aaa = aaa.Replace(p.ParameterName, p.Value.ToString());
            }
            
            try
            {
                tmp = execute.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw new ManejadorSQLException("Error de conexion con la DB", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ManejadorSQLException("Operacion invalida en la DB", e);
            }
            return tmp;
        }
    }
}