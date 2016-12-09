using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.Models;
using BOReserva.Models.gestion_aviones;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models.gestion_lugares;
using BOReserva.Models.gestion_ruta_comercial;
using System.Diagnostics;
using System.Data;


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
                query.CommandText = "INSERT INTO Avion VALUES ('" + model._matriculaAvion + "','" + model._modeloAvion + "'," + model._capacidadPasajerosTurista + " , " + model._capacidadPasajerosEjecutiva + "," + model._capacidadPasajerosVIP + ", " + model._capacidadEquipaje + ", " + model._distanciaMaximaVuelo + ", " + model._velocidadMaximaDeVuelo + ", " + model._capacidadMaximaCombustible + ");";
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
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        //Procedimiento del Modulo 9 para agregar hoteles a la base de datos.
        public Boolean insertarHotel(CGestionHoteles_CrearHotel model)
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
                query.CommandText = "INSERT INTO Hotel VALUES ('" + model._nombre + "','" + model._estrellas + "'," 
                    + model._puntuacion + " , " + model._direccion + "," + model._paginaWeb +  ");";
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
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        //Modulo 3 insertar nueva ruta

        public Boolean InsertarRuta(CAgregarRuta model)
        {   
            String[] strDes = model._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
            String[] strOri = model._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);
            
            conexion = new SqlConnection(stringDeConexion);

            conexion.Open();

            SqlCommand query = new SqlCommand("M03_AgregarRuta",conexion);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
            query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
            query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
            query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
            query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = model._tipoRuta;
            query.Parameters.Add("@estadoRuta", SqlDbType.VarChar).Value = model._estadoRuta;
            query.Parameters.Add("@distanciaRuta", SqlDbType.Int).Value = model._distanciaRuta;

            query.ExecuteNonQuery();
            
            
            /*String dist = model._distanciaRuta.ToString();
            String miquery = "EXEC M03_AgregarRuta '" + strOri[0] + "','" + strOri[1] + "','" + strDes[0] + "' , '" + strDes[1] + "', '" + model._tipoRuta + "', '" + model._estadoRuta + "', " + dist;
            System.Diagnostics.Debug.WriteLine(miquery);*/

            

            //creo un lector sql para la respuesta de la ejecucion del comando anterior               
            SqlDataReader lector = query.ExecuteReader();

            lector.Close();

            return true;
        }
    
        
        /* INICIO DE FUNCIONES PARA MODULO 10 BO (RESTAURANTES) */
        //Método del Modulo 10 (Backoffice) para agregar restaurantes a la base de datos.

        public Boolean insertarRestaurante(CRestauranteModelo model)
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
                query.CommandText = "INSERT INTO Restaurante VALUES ('" + model._nombre + "', '" + model._direccion + "', '"
                    + model._descripcion + "' , '" + model._horarioApertura + "' ,'" + model._horarioCierre + "', " 
                    + model._idLugar.ToString() + ")";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior
                SqlDataReader lector = query.ExecuteReader();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return false;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return false;
            }
        }

        //Método para la consulta de un sólo restaurante, dado un ID como parámetro, retornando un modelo del restaurante.
        public CRestauranteModelo consultarRestaurante(int id)
        {
            try
            {
                CRestauranteModelo entrada = null;
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT * FROM Restaurante WHERE rst_id = " + id.ToString() ;
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while(lector.Read())
                {
                    entrada = new CRestauranteModelo
                    {
                        _id = (int)lector.GetSqlInt32(0),
                        _nombre = lector.GetSqlString(1).ToString(),
                        _descripcion = lector.GetSqlString(2).ToString(),
                        _direccion = lector.GetSqlString(3).ToString(),
                        _horarioApertura = lector.GetSqlString(4).ToString(),
                        _horarioCierre = lector.GetSqlString(5).ToString(),
                        _idLugar = (int)lector.GetSqlInt32(6)
                    };
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return entrada;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }

        }

        //Método para la consulta de todos los restaurantes, retornando una lista de modelos de restaurante.
        public List<CRestauranteModelo> consultarRestaurante()
        {
            try
            {
                var list = new List<CRestauranteModelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT * FROM Restaurante";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CRestauranteModelo
                    {
                        _id = (int)lector.GetSqlInt32(0),
                        _nombre = lector.GetSqlString(1).ToString(),
                        _descripcion = lector.GetSqlString(2).ToString(),
                        _direccion = lector.GetSqlString(3).ToString(),
                        _horarioApertura = lector.GetSqlString(4).ToString(),
                        _horarioCierre = lector.GetSqlString(5).ToString(),
                        _idLugar = (int)lector.GetSqlInt32(6)
                    };
                    list.Add(entrada);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
        }

        //Método para la modificación de un restaurante.
        public Boolean modificarRestaurante(CRestauranteModelo model)
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
                query.CommandText = "UPDATE Restaurante SET rst_nombre = '" + model._nombre + "', " +
                    "rst_direccion = '" + model._direccion + "', " + "rst_descripcion = '" + model._descripcion + "', " +
                    "rst_hora_apertura = '" + model._horarioApertura + "', " + "rst_hora_cierre = '" + model._horarioCierre +
                    "WHERE rst_id = " + model._id.ToString();
                //creo un lector sql para la respuesta de la ejecucion del comando anterior
                SqlDataReader lector = query.ExecuteReader();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return false;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return false;
            }
        }

        //Método para la eliminación de un restaurante.
        public Boolean eliminarRestaurante(int id)
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
                query.CommandText = "DELETE FROM Restaurante WHERE rst_id = " + id.ToString();
                //creo un lector sql para la respuesta de la ejecucion del comando anterior
                SqlDataReader lector = query.ExecuteReader();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return false;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return false;
            }
        }

        /* FIN DE FUNCIONES PARA MODULO 10 BO (RESTAURANTES) */

        /* INICIO DE FUNCIONES COMUNES */

        //Método para la consulta de todos los lugares, sin parámetro y retornando una lista de modelos de lugar.
        public List<CLugarModelo> consultarLugar()
        {
            try
            {
                var list = new List<CLugarModelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT * FROM Lugar";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CLugarModelo
                    {
                        _id = (int)lector.GetSqlInt32(0),
                        _nombre = lector.GetSqlString(1).ToString(),
                        _tipoLugar = lector.GetSqlString(2).ToString(),
                        _zonaHoraria = lector.GetSqlString(3).ToString(),
                        _idFKLugar = lector.IsDBNull(4) ? -1 : (int)lector.GetSqlInt32(4), //Pregunta si el campo es null, dando valor por defecto en caso que lo sea
                        _abreviatura = lector.GetSqlString(5).ToString()

                    };
                    list.Add(entrada);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
        }

        //Método para la consulta de ciudades, sin parámetro y retornando una lista de modelos de lugar.
        public List<CLugarModelo> consultarCiudad()
        {
            try
            {
                var list = new List<CLugarModelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT * FROM Lugar WHERE lug_tipo_lugar = 'ciudad'";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CLugarModelo
                    {
                        _id = (int)lector.GetSqlInt32(0),
                        _nombre = lector.GetSqlString(1).ToString(),
                        _tipoLugar = lector.GetSqlString(2).ToString(),
                        _zonaHoraria = lector.GetSqlString(3).ToString(),
                        _idFKLugar = lector.IsDBNull(4) ? -1 : (int)lector.GetSqlInt32(4), //Pregunta si el campo es null, dando valor por defecto en caso que lo sea
                        _abreviatura = lector.GetSqlString(5).ToString()

                    };
                    list.Add(entrada);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                //throw e;
                return null;
            }
        }

        /* FIN DE FUNCIONES COMUNES */
    }
}