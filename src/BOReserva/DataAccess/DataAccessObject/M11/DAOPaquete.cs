using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Models.gestion_ofertas;
using BOReserva.Models.gestion_restaurantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_automoviles;

namespace BOReserva.DataAccess.DataAccessObject.M11
{
    /// <summary>
    /// Clase DAOPquete que implementa la interface IDAOPaquete
    /// </summary>
    public class DAOPaquete : DAO, IDAOPaquete
    {
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public DAOPaquete() { }

        int IDAO.Agregar(Entidad e)
        {
            Paquete paquete = (Paquete)e;

            int estado; //estado nos indica si el paquete está activo o no
            if (paquete._estadoPaquete == true)
                estado = 1;
            else
                estado = 0;

            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                                //base de datos

            SqlDataReader lector = null;  //La clase SqlDataReader ofrece una manera de leer un
                                         //flujo de filas de solo avance desde una base de 
                                        //datos de SQL Server.
            try
            {
                conexion.Open();
                SqlCommand query = conexion.CreateCommand(); //El método SqlConnection.CreateCommand()
                                                             //crea y devuelve un objeto SqlCommand asociado 
                                                             //a la conexión SqlConnection.
                                                             //Se usa SqlCommand para las instrucciones que se 
                                                             //ejecutan en una base de datos de SQL Server.
                query.CommandText = "INSERT INTO Paquete (paq_nombre, paq_precio, paq_fk_automovil,"+
                " paq_fk_restaurante, paq_fk_hotel, paq_fk_crucero, paq_fk_vuelo, paq_fechaInicio_automovil,"+
                " paq_fechaInicio_restaurante, paq_fechaInicio_crucero, paq_fechaInicio_hotel,"+
                " paq_fechaInicio_boleto, paq_fechaFin_automovil, paq_fechaFin_restaurante, paq_fechaFin_hotel,"+
                " paq_fechaFin_crucero, paq_fechaFin_boleto, paq_estado) VALUES  (@pn, @pp, @pfa, @pfr, @pfh,"+
                " @pfc, @pfv, @fia, @fir, @fic, @fih, @fib, @ffa, @ffr, @ffh, @ffc, @ffb, @pe);";

                query.Parameters.AddWithValue("@pn", paquete._nombrePaquete);
                query.Parameters.AddWithValue("@pp", paquete._precioPaquete);
                query.Parameters.AddWithValue("@pfa", (object)paquete._idAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfr", (object)paquete._idRestaurante ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfh", (object)paquete._idHotel ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfc", (object)paquete._idCrucero ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfv", (object)paquete._idVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@fia", (object)paquete._fechaIniAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@fir", (object)paquete._fechaIniRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@fic", (object)paquete._fechaIniCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@fih", (object)paquete._fechaIniHotel ?? DBNull.Value);
                query.Parameters.AddWithValue("@fib", (object)paquete._fechaIniVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffa", (object)paquete._fechaFinAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffr", (object)paquete._fechaFinRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffh", (object)paquete._fechaFinHotel ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffc", (object)paquete._fechaFinCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffb", (object)paquete._fechaFinVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@pe", estado);

                lector = query.ExecuteReader();               //El método ExecuteReader() envía la propiedad 
                                                              //CommandText a Connection y crea un objeto 
                                                              //SqlDataReader.
                                                              
                lector.Close();   //Se cierra el lector
                conexion.Close(); //Se cierra la conexión
                return 1; //Este método retorna el valor 1 si se pudo agregar el paquete a la tabla Paquete de la 
                          //base de datos.
                                                              
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrió una SqlException ");
                Debug.WriteLine(ex.ToString());
                lector.Close();
                conexion.Close();
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrió una NullReferenceException ");
                Debug.WriteLine(ex.ToString());
                lector.Close();
                conexion.Close();
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrió una ArgumentNullException ");
                Debug.WriteLine(ex.ToString());
                lector.Close();
                conexion.Close();
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrió una Exception ");
                Debug.WriteLine(ex.ToString());
                lector.Close();
                conexion.Close();
                return 5;
            }
            
            
        }

        /// <summary>
        /// Metodo implementado de IDAO para consultar los paquetes de la BD
        /// </summary>
        /// <returns>Retorna el listado de paquetes</returns>
        List<Entidad> IDAOPaquete.ConsultarTodos()
        {
            Debug.WriteLine("LLEGÓ A DAO PAQUETE");
            List<Entidad> listaPaquetes = FabricaEntidad.asignarListaDeEntidades();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            Entidad paquete;
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[M11_ConsultarPaquetes]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                Debug.WriteLine("HIZO CONEXIÓN");
                Debug.WriteLine("CMD.READER");

                using (SqlDataReader reader = cmd.ExecuteReader())
                { 
                      while (reader.Read())
                    {
                        String estado = reader["estado"].ToString();
                        bool estadoPaquete;
                        if (estado == "True")
                            estadoPaquete = true;
                        else
                            estadoPaquete = false;
                        /*var estadovar = reader["estado"];
                        Boolean disponibilidad = Convert.ToBoolean(estadovar);*/
                      
                        paquete =  FabricaEntidad.InstanciarPaquete(Int32.Parse(reader["idPaquete"].ToString()), 
                                                                    reader["nombrePaquete"].ToString(), 
                                                                    float.Parse(reader["precio"].ToString()),
                                                                    estadoPaquete);
                          
                        listaPaquetes.Add(paquete);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                Debug.WriteLine("RETORNANDO LA LISTA DE PAQUETES");
                return listaPaquetes;
                
                }
            
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                Debug.WriteLine("UNA EXCEPCIÓN");
                return null;
            }
            
        }

        string IDAOPaquete.disponibilidadPaquete(Entidad e, int disponibilidad)
        {
            Paquete paquete = (Paquete)e;
            int paqueteId = paquete._idPaquete;
            SqlConnection conexion = new SqlConnection(_connexionString);
            try
            {
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Paquete SET paq_estado = disponibilidad WHERE paq_id=" + paqueteId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
                conexion.Close();
                return "1";
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Entre en excepcion sql de IDAOPaquete");
                conexion.Close();
                return ex.Message;

            }

        }

        //Método para consultar los cruceros para llevarlos al select list de la vista agregar paquete
        public List<CConsultar> listarCrucerosM11()
        {
            List<CConsultar> listcruceros = new List<CConsultar>();
            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                                //base de datos
            try
            {
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT * FROM Crucero";
                SqlDataReader lector = query.ExecuteReader();
                while (lector.Read())
                {
                    CConsultar consulta = new CConsultar();
                    consulta._id = Int32.Parse(lector["cru_id"].ToString());
                    consulta._nombre = lector["cru_nombre"].ToString();
                    listcruceros.Add(consulta);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listcruceros;
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

        //Método modulo 11 para consultar todos los hoteles
        public List<CConsultar> listarHotelesM11()
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                                //base de datos
            try
            {
                List<CConsultar> listHoteles = new List<CConsultar>();
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT * FROM Hotel";
                SqlDataReader lector = query.ExecuteReader();
                while (lector.Read())
                {
                    CConsultar consulta = new CConsultar();
                    consulta._id = Int32.Parse(lector["hot_id"].ToString());
                    consulta._nombre = lector["hot_nombre"].ToString();
                    listHoteles.Add(consulta);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listHoteles;
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

        //Método modulo 11 para consultar todos los vuelos
        public List<CConsultar> listarVuelosM11()
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                                //base de datos
            try
            {
                List<CConsultar> listVuelos = new List<CConsultar>();
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText =
                    "SELECT v.vue_id, v.vue_codigo, l1.lug_nombre, l2.lug_nombre " +
                    "FROM vuelo v, ruta r, lugar l1, lugar l2 " +
                    "WHERE v.vue_fk_ruta = r.rut_id and r.rut_fk_lugar_origen = l1.lug_id and r.rut_fk_lugar_destino = l2.lug_id";
                SqlDataReader lector = query.ExecuteReader();
                var columns = new List<string>();
                for (int i = 0; i < lector.FieldCount; i++)
                {
                    columns.Add(lector.GetName(i));
                }
                while (lector.Read())
                {
                    CConsultar consulta = new CConsultar();
                    consulta._id = Int32.Parse(lector["vue_id"].ToString());
                    consulta._codigoVuelo = lector["vue_codigo"].ToString();
                    consulta._nombreSalida = lector["lug_nombre"].ToString();
                    consulta._nombreLlegada = lector.GetValue(3).ToString();
                    listVuelos.Add(consulta);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listVuelos;
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
        public List<CConsultar> consultarRestaurante()
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                               //base de datos
            try
            {
                List<CConsultar> lista = new List<CConsultar>();
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT * FROM Restaurante";
                SqlDataReader lector = query.ExecuteReader(); //creo un lector sql para la respuesta de la 
                                                              //ejecucion del comando anterior 
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un 
                //procedimiento de la bd
                while (lector.Read())
                {
                    CConsultar consulta = new CConsultar();
                    consulta._id = Int32.Parse(lector["rst_id"].ToString());
                    consulta._nombre = lector["rst_nombre"].ToString();
                    lista.Add(consulta);   
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return lista;
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

        public List<CVisualizarAutomovil> consultarAutos()
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
            //base de datos
            try
            {
                List<CVisualizarAutomovil> listAutos = new List<CVisualizarAutomovil>();
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT * FROM Automovil";
                SqlDataReader lector = query.ExecuteReader();
                while (lector.Read())
                {
                    CVisualizarAutomovil consulta = new CVisualizarAutomovil();
                    consulta._matricula = lector["aut_matricula"].ToString();
                    consulta._fabricante = lector["aut_fabricante"].ToString();
                    consulta._modelo = lector["aut_modelo"].ToString();
                    listAutos.Add(consulta);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listAutos;
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
    }
}