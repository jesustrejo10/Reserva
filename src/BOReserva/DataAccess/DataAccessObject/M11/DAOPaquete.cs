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
        
        int IDAOPaquete.Modificar(Entidad e, int idPaquete)
        {
            Debug.WriteLine("LLEGÓ A MODIFICARPAQUETE");
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Paquete paquete = (Paquete)e;

            Debug.WriteLine("LLEGÓ A MODIFICARPAQUETE" + idPaquete);
            Debug.WriteLine("LLEGÓ A MODIFICAROFERTA" + paquete._nombrePaquete);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[M11_ModificarPaquete]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                Debug.WriteLine("HIZO CONEXIÓN EN VISUAL");

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@paq_id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = idPaquete;
                cmd.Parameters.Add(ParId);


                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@paq_nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Value = paquete._nombrePaquete;
                cmd.Parameters.Add(ParNombre);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@paq_precio";
                ParPrecio.SqlDbType = SqlDbType.Float;
                ParPrecio.Value = paquete._precioPaquete;
                cmd.Parameters.Add(ParPrecio);

                SqlParameter ParFkAuto = new SqlParameter();
                ParFkAuto.ParameterName = "@paq_fk_automovil";
                ParFkAuto.SqlDbType = SqlDbType.VarChar;
                if (paquete._idAuto == null)
                    cmd.Parameters.AddWithValue("@paq_fk_automovil", ParFkAuto.IsNullable);
                else
                    ParFkAuto.Value = paquete._idAuto;
                cmd.Parameters.Add(ParFkAuto);

                SqlParameter ParFkRest = new SqlParameter();
                ParFkRest.ParameterName = "@paq_fk_restaurante";
                ParFkRest.SqlDbType = SqlDbType.Int;
                if (paquete._idRestaurante == null)
                    cmd.Parameters.AddWithValue("@paq_fk_restaurante", ParFkRest.IsNullable);
                else
                    ParFkRest.Value = paquete._idAuto;
                cmd.Parameters.Add(ParFkRest);

                SqlParameter ParFkHot = new SqlParameter();
                ParFkHot.ParameterName = "@paq_fk_hotel";
                ParFkHot.SqlDbType = SqlDbType.Int;
                if (paquete._idHotel == null)
                    cmd.Parameters.AddWithValue("@paq_fk_hotel", ParFkHot.IsNullable);
                else
                    ParFkHot.Value = paquete._idHotel;
                cmd.Parameters.Add(ParFkHot);

                SqlParameter ParFkVuelo = new SqlParameter();
                ParFkVuelo.ParameterName = "@paq_fk_vuelo";
                ParFkVuelo.SqlDbType = SqlDbType.Int;
                if (paquete._idVuelo == null)
                    cmd.Parameters.AddWithValue("@paq_fk_vuelo", ParFkVuelo.IsNullable);
                else
                    ParFkVuelo.Value = paquete._idVuelo;
                cmd.Parameters.Add(ParFkVuelo);

                SqlParameter ParFechaIniAuto = new SqlParameter();
                ParFechaIniAuto.ParameterName = "@paq_fechaInicio_automovil";
                ParFechaIniAuto.SqlDbType = SqlDbType.Date;
                if (paquete._fechaIniAuto == null)
                    cmd.Parameters.AddWithValue("@paq_fechaInicio_automovil", ParFechaIniAuto.IsNullable);
                else
                    ParFechaIniAuto.Value = ((DateTime) paquete._fechaIniAuto).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaIniAuto);


                SqlParameter ParFechaFinAuto = new SqlParameter();
                ParFechaFinAuto.ParameterName = "@paq_fechaFin_automovil";
                ParFechaFinAuto.SqlDbType = SqlDbType.Date;
                if (paquete._fechaFinAuto == null)
                    cmd.Parameters.AddWithValue("@paq_fechaFin_automovil", ParFechaFinAuto.IsNullable);
                else
                    ParFechaFinAuto.Value = ((DateTime)paquete._fechaFinAuto).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaFinAuto);

                SqlParameter ParFechaIniRest = new SqlParameter();
                ParFechaIniRest.ParameterName = "@paq_fechaInicio_restaurante";
                ParFechaIniRest.SqlDbType = SqlDbType.Date;
                if (paquete._fechaIniRest == null)
                    cmd.Parameters.AddWithValue("@paq_fechaInicio_restaurante", ParFechaIniRest.IsNullable);
                else
                    ParFechaIniRest.Value = ((DateTime)paquete._fechaIniRest).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaIniRest);


                SqlParameter ParFechaFinRest = new SqlParameter();
                ParFechaFinRest.ParameterName = "@paq_fechaFin_restaurante";
                ParFechaFinRest.SqlDbType = SqlDbType.Date;
                if (paquete._fechaFinRest == null)
                    cmd.Parameters.AddWithValue("@paq_fechaFin_restaurante", ParFechaIniAuto.IsNullable);
                else
                    ParFechaFinRest.Value = ((DateTime)paquete._fechaFinRest).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaFinRest);

                SqlParameter ParFechaIniHot = new SqlParameter();
                ParFechaIniHot.ParameterName = "@paq_fechaInicio_hotel";
                ParFechaIniHot.SqlDbType = SqlDbType.Date;
                if (paquete._fechaIniHotel == null)
                    cmd.Parameters.AddWithValue("@paq_fechaInicio_hotel", ParFechaIniHot.IsNullable);
                else
                    ParFechaIniHot.Value = ((DateTime)paquete._fechaIniHotel).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaIniHot);


                SqlParameter ParFechaFinHot = new SqlParameter();
                ParFechaFinHot.ParameterName = "@paq_fechaFin_hotel";
                ParFechaFinHot.SqlDbType = SqlDbType.Date;
                if (paquete._fechaFinHotel == null)
                    cmd.Parameters.AddWithValue("@paq_fechafin_hotel", ParFechaFinHot.IsNullable);
                else
                    ParFechaFinHot.Value = ((DateTime)paquete._fechaFinHotel).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaFinHot);

                SqlParameter ParFechaIniCruc = new SqlParameter();
                ParFechaIniCruc.ParameterName = "@paq_fechaInicio_crucero";
                ParFechaIniCruc.SqlDbType = SqlDbType.Date;
                if (paquete._fechaIniCruc == null)
                    cmd.Parameters.AddWithValue("@paq_fechaInicio_crucero", ParFechaIniCruc.IsNullable);
                else
                    ParFechaIniCruc.Value = ((DateTime)paquete._fechaIniCruc).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaIniCruc);


                SqlParameter ParFechaFinCruc = new SqlParameter();
                ParFechaFinCruc.ParameterName = "@paq_fechaFin_crucero";
                ParFechaFinCruc.SqlDbType = SqlDbType.Date;
                if (paquete._fechaFinCruc == null)
                    cmd.Parameters.AddWithValue("@paq_fechaFin_crucero", ParFechaFinCruc.IsNullable);
                else
                    ParFechaFinCruc.Value = ((DateTime)paquete._fechaFinCruc).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaFinCruc);

                SqlParameter ParFechaIniBole = new SqlParameter();
                ParFechaIniBole.ParameterName = "@paq_fechaInicio_boleto";
                ParFechaIniBole.SqlDbType = SqlDbType.Date;
                if (paquete._fechaIniVuelo == null)
                    cmd.Parameters.AddWithValue("@paq_fechaInicio_boleto", ParFechaIniBole.IsNullable);
                else
                    ParFechaIniBole.Value = ((DateTime)paquete._fechaIniVuelo).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaIniBole);


                SqlParameter ParFechaFinBole = new SqlParameter();
                ParFechaFinBole.ParameterName = "@paq_fechaFin_boleto";
                ParFechaFinBole.SqlDbType = SqlDbType.Date;
                if (paquete._fechaIniVuelo == null)
                    cmd.Parameters.AddWithValue("@paq_fechaFin_boleto", ParFechaFinBole.IsNullable);
                else
                    ParFechaFinBole.Value = ((DateTime)paquete._fechaFinVuelo).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(ParFechaFinBole);
                
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@ofe_estado";
                ParEstado.SqlDbType = SqlDbType.Bit; 

                if (paquete._estadoPaquete == true)
                    ParEstado.Value = 1;
                else
                    ParEstado.Value = 0;

                cmd.Parameters.Add(ParEstado);

                Debug.WriteLine("HIZO LA PARTED DE PARÁMETRO");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    cmd.Dispose();
                    conexion.Close();
                    return 1;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            } 
        }

        /// <summary>
        /// Cambia Dsiponibilidad de un Paquete en la Base de Datos.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="disponibilidad"></param>
        /// <returns></returns>
        String IDAOPaquete.disponibilidadPaquete(Entidad e, int disponibilidad)
        {
            Paquete paquete = (Paquete)e;
            int paqueteId = paquete._id;
            Debug.WriteLine("Enró a DAO DISPON OFERTA");
            Debug.WriteLine("Enró a DAO DISPON OFERTA " + disponibilidad);
            Debug.WriteLine("Enró a DAO DISPON OFERTA " + paqueteId);

            SqlConnection conexion = new SqlConnection(_connexionString);
            try
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[M11_ActualizarEstadoPaquete]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                Debug.WriteLine("HIZO CONEXIÓN EN VISUAL");

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@paq_id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = paqueteId;
                cmd.Parameters.Add(ParId);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@paq_estado";
                ParEstado.SqlDbType = SqlDbType.Int;
                ParEstado.Value = disponibilidad;
                cmd.Parameters.Add(ParEstado);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    cmd.Dispose();
                    conexion.Close();
                    return "Realizado el Cambio. Actualice la página.";
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return "SQL EXCEPTION";
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return "Ocurrio una NullReferenceException";
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return "Ocurrio una ArgumentNullException";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return "Ocurrio una Exception desconocida";
            }
        }

        /// <summary>
        /// Procedimiento que consulta el detalle de una oferta en la base de datos
        /// </summary>
        /// <param name="id">Id de la oferta</param>
        /// <returns>Una entidad del tipo oferta</returns>
        Entidad IDAO.Consultar(int id)
        {
            Debug.WriteLine("LLEGÓ A DAO CONSULTARpaquete");
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Entidad paquete = null;
            Int32 _id;
            _id = id;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[M11_ConsultarPaquete]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                Debug.WriteLine("HIZO CONEXIÓN EN VISUAL");

                Debug.WriteLine(id);
                Debug.WriteLine(_id);

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@paq_id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = id;

                //SqlCmd.Parameters.Add(ParNombre);
                cmd.Parameters.Add(ParId);

                Debug.WriteLine("HIZO LA PARTED dE PARÁMETRO");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Debug.WriteLine("CMD.READER EN CONSULTAR");
                    while (reader.Read())
                    {
                        
                        var fechaIniauto = reader["fechaIn_auto"];
                        var fechaFinauto = reader["fechaFin_auto"];
                        var fechaInirest = reader["fechaIn_rest"];
                        var fechaFinrest = reader["fechaFin_rest"];
                        var fechaInicrucero = reader["fechaIn_crucero"];
                        var fechaFincrucero = reader["fechaFin_crucero"];
                        var fechaIniboleto = reader["fechaIn_boleto"];
                        var fechaFinboleto = reader["fechaFin_boleto"];
                        //var estadovar = reader["estado"];

                        /*DateTime fechaIauto = Convert.ToDateTime(fechaIniauto).Date;
                        DateTime fechaFauto = Convert.ToDateTime(fechaFinauto).Date;
                        DateTime fechaIrest = Convert.ToDateTime(fechaInirest).Date;
                        DateTime fechaFrest = Convert.ToDateTime(fechaFinrest).Date;
                        DateTime fechaIcrucero = Convert.ToDateTime(fechaInicrucero).Date;
                        DateTime fechaFcrucero = Convert.ToDateTime(fechaFincrucero).Date;
                        DateTime fechaIboleto = Convert.ToDateTime(fechaIniboleto).Date;
                        DateTime fechaFboleto = Convert.ToDateTime(fechaFinboleto).Date;*/

                        var estadovar = reader["estado"];
                        Boolean disponibilidad = Convert.ToBoolean(estadovar);

                        paquete = FabricaEntidad.InstanciarPaquete(Int32.Parse(reader["idPaquete"].ToString()),
                                                                   reader["nombrePaquete"].ToString(),
                                                                   float.Parse(reader["precio"].ToString()), disponibilidad);
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return paquete;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }
    }

}