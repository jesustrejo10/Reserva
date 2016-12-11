using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.Models;
using BOReserva.Models.gestion_aviones;

namespace BOReserva.Servicio
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

        //Procedimiento del Modulo 2 para agregar aviones a la base de datos.
        public Boolean insertarAvion(CAgregarAvion model)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "INSERT INTO Avion VALUES ('" +model._matriculaAvion+ "','" +model._modeloAvion+ "'," +model._capacidadPasajerosTurista+ " , " +model._capacidadPasajerosEjecutiva+ "," +model._capacidadPasajerosVIP+ ", " +model._capacidadEquipaje+ ", " +model._distanciaMaximaVuelo+ ", " +model._velocidadMaximaDeVuelo+ ", " +model._capacidadMaximaCombustible+ ");";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                /*while(lector.Read())
                {
                      //COMENTADO PORQUE ESTE METODO NO LO APLICA, SERÁ BORRADO DESPUES
                }*/
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch(SqlException e)
            {
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

    }
}