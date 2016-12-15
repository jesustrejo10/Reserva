using FOReserva.Models.Restaurantes;
using FOReserva.Models.Diarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System;



//IMPORTANTE AGREGAR EL USING DE SUS RESPECTIVAS CLASES PARA PODER AGREGAR EL METODO DE AGREGAR/CONSULTAR

namespace FOReserva.Servicio
{
    public class manejadorSQL
    {
        //Inicializo el string de conexion en el constructor
        public manejadorSQL()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }
        //Atributo que ejecutara la conexion a la bd
        private SqlConnection conexion = null;
        //string que contendra la conexion a la bd
        private string stringDeConexion = null;

        /*Metodo para Abrir la conexion a la DB*/
        private void OpenConnection()
        {
            conexion = new SqlConnection(stringDeConexion);
            try
            {
                conexion.Open();
            }catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + e.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + e.StackTrace);

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
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + e.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + e.StackTrace);

                throw new ManejadorSQLException("Error de conexion con la DB", e);
            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + e.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + e.StackTrace);

                throw new ManejadorSQLException("Operacion invalida en la DB", e);
            }
            return tmp;
        }
    }

    /*public int insertarDiario(CDiarioModel diarionuevo)
        {
            try
            {
                
                
                conexion = new SqlConnection(stringDeConexion);
               
                conexion.Open();
               
                SqlCommand query = conexion.CreateCommand();
              
                query.CommandText = "";
                       
                SqlDataReader lector = query.ExecuteReader();
                
                lector.Close();
               
                conexion.Close();
                return 0;
            }
            catch (SqlException e)
            {
                return 1;
            }
            catch (Exception e)
            {
                return 1;
            }

        }*/
}