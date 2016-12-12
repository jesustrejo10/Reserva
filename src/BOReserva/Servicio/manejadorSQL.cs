using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.Models;
using BOReserva.Models.gestion_aviones;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models.gestion_lugares;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Models.gestion_ofertas;
using BOReserva.Models.gestion_roles;
using System.Diagnostics;

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
                query.CommandText = "INSERT INTO Avion VALUES ('" + model._matriculaAvion + "','" + model._modeloAvion + "'," + model._capacidadPasajerosTurista + " , " + model._capacidadPasajerosEjecutiva + "," + model._capacidadPasajerosVIP + ", " + model._capacidadEquipaje + ", " + model._distanciaMaximaVuelo + ", " + model._velocidadMaximaDeVuelo + ", " + model._capacidadMaximaCombustible + ", 1);";
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

        //Procedimiento del Modulo 11 para agregar ofertas a la base de datos.
        public Boolean agregarOferta(CAgregarOferta model)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "INSERT INTO Oferta VALUES ('" + model._nombreOferta + "','" + model.formatDate(model._fechaIniOferta) + "', '" + model.formatDate(model._fechaFinOferta) + "'," + model._porcentajeOferta + ",'"+ model._estadoOferta +"');";
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
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

        //Procedimiento del Modulo 11 para agregar paquetes a la base de datos.
        public Boolean agregarPaquete(CPaquete paquete)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "INSERT INTO Paquete (paq_nombre, paq_precio, paq_fk_automovil, paq_fk_restaurante, paq_fk_hotel,"+
                    " paq_fk_crucero, paq_fk_vuelo, paq_fechaInicio_automovil, paq_fechaInicio_restaurante, paq_fechaInicio_crucero, paq_fechaInicio_hotel, paq_fechaInicio_boleto,"+
                    " paq_fechaFin_automovil, paq_fechaFin_restaurante, paq_fechaFin_hotel, paq_fechaFin_crucero, paq_fechaFin_boleto)"+
                    "VALUES  ('" + paquete._nombrePaquete + "', " + paquete._precioPaquete + ",'" + paquete._idAuto + "', " + paquete._idRestaurante + "," + paquete._idHabitacion + ", "+
                    paquete._idCrucero + ", " + paquete._idVuelo + ",'" + paquete.formatDate(paquete._fechaIniAuto) + "', '" + paquete.formatDate(paquete._fechaIniRest) + "','" + paquete.formatDate(paquete._fechaIniCruc) + "','" + paquete.formatDate(paquete._fechaIniHabi) + "','" +
                    paquete.formatDate(paquete._fechaIniVuelo) + "','" + paquete.formatDate(paquete._fechaFinAuto) + "','" + paquete.formatDate(paquete._fechaFinRest) + "', '" + paquete.formatDate(paquete._fechaFinHabi) + "','" + paquete.formatDate(paquete._fechaFinCruc) + "','"+ paquete.formatDate(paquete._fechaFinVuelo)+"');";
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
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

        public Boolean desactivarOferta(int ofertaId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Oferta SET ofe_estado = 0 WHERE ofe_id="+ofertaId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
                SqlCommand query1 = conexion.CreateCommand();
                query1.CommandText = "UPDATE Paquete SET paq_fk_oferta = null WHERE paq_fk_oferta=" + ofertaId;
                SqlDataReader lector1 = query1.ExecuteReader();
                lector1.Close();
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

        public Boolean activarOferta(int ofertaId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Oferta SET ofe_estado = 1 WHERE ofe_id=" + ofertaId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
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

        public CPaquete detallePaquete(int paqueteId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "Select * from Paquete WHERE paq_id="+paqueteId; 
                SqlDataReader lector = query.ExecuteReader();
                CPaquete paquete = new CPaquete();
                while (lector.Read())
                {
                    String estado = lector["paq_estado"].ToString();
                    bool estadoPaquete;
                    if (estado == "True")
                        estadoPaquete = true;
                    else
                        estadoPaquete = false;
                    DateTime date;
                    paquete._idPaquete = Int32.Parse(lector["paq_id"].ToString());
                    paquete._nombrePaquete = lector["paq_nombre"].ToString();
                    paquete._precioPaquete = float.Parse(lector["paq_precio"].ToString());
                    paquete._estadoPaquete = estadoPaquete;
                    paquete._idAuto = lector["paq_fk_automovil"].ToString();
                    if (lector["paq_fk_hotel"].ToString() != "")
                        paquete._idHabitacion = Int32.Parse(lector["paq_fk_hotel"].ToString());
                    if (lector["paq_fk_restaurante"].ToString()!= "")
                    paquete._idRestaurante = Int32.Parse(lector["paq_fk_restaurante"].ToString());
                    if (lector["paq_fk_crucero"].ToString()!= "")
                    paquete._idCrucero = Int32.Parse(lector["paq_fk_crucero"].ToString());
                    if (lector["paq_fk_vuelo"].ToString()!= "")
                    paquete._idVuelo = Int32.Parse(lector["paq_fk_vuelo"].ToString());



                    bool parseo = DateTime.TryParse(lector["paq_fechaInicio_automovil"].ToString(), out date);
                    if (parseo) paquete._fechaIniAuto = date;

                    parseo = DateTime.TryParse(lector["paq_fechaFin_automovil"].ToString(), out date);
                    if (parseo) paquete._fechaFinAuto = date;

                    parseo = DateTime.TryParse(lector["paq_fechaInicio_restaurante"].ToString(), out date);
                    if (parseo) paquete._fechaIniRest = date;

                    parseo = DateTime.TryParse(lector["paq_fechaFin_restaurante"].ToString(), out date);
                    if (parseo) paquete._fechaFinRest = date;

                    parseo = DateTime.TryParse(lector["paq_fechaInicio_hotel"].ToString(), out date);
                    if (parseo) paquete._fechaIniHabi = date;

                    parseo = DateTime.TryParse(lector["paq_fechaFin_hotel"].ToString(), out date);
                    if (parseo) paquete._fechaFinHabi = date;

                    parseo = DateTime.TryParse(lector["paq_fechaInicio_crucero"].ToString(), out date);
                    if (parseo) paquete._fechaIniCruc = date;

                    parseo = DateTime.TryParse(lector["paq_fechaFin_crucero"].ToString(), out date);
                    if (parseo) paquete._fechaFinCruc = date;

                    parseo = DateTime.TryParse(lector["paq_fechaInicio_boleto"].ToString(), out date);
                    if (parseo) paquete._fechaIniVuelo = date;

                    parseo = DateTime.TryParse(lector["paq_fechaFin_boleto"].ToString(), out date);
                    if (parseo) paquete._fechaFinVuelo = date;
                }
                lector.Close();
                conexion.Close();
                return paquete;
            }
            catch (SqlException e)
            {
                CPaquete paquete1 = new CPaquete();
                return paquete1;
            }
            catch (Exception e)
            {
                CPaquete paquete2 = new CPaquete();
                return paquete2;
            }
        }

        public Boolean desactivarPaquete(int paqueteId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Paquete SET paq_estado = 0 WHERE paq_id=" + paqueteId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
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

        public Boolean activarPaquete(int paqueteId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Paquete SET paq_estado = 1 WHERE paq_id=" + paqueteId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
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

        //Metodo para mostrar paquetes al momento de agregar una oferta
        public List<CPaquete> listarPaquetesEnBD()
        {
            List<CPaquete> paquetesList = new List<CPaquete>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Paquete WHERE paq_fk_oferta IS null";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CPaquete paquete = new CPaquete(Int32.Parse(lector["paq_id"].ToString()), lector["paq_nombre"].ToString(),
                    float.Parse(lector["paq_precio"].ToString()));
                    paquetesList.Add(paquete);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return paquetesList;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Metodo para mostrar paquetes 
        public List<CPaquete> listarPaquetes()
        {
            List<CPaquete> paquetesList = new List<CPaquete>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Paquete";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    String estado = lector["paq_estado"].ToString();
                    bool estadoPaquete;
                    if (estado == "True")
                        estadoPaquete = true;
                    else
                        estadoPaquete = false;
                    CPaquete paquete = new CPaquete(Int32.Parse(lector["paq_id"].ToString()), lector["paq_nombre"].ToString(),
                    float.Parse(lector["paq_precio"].ToString()), estadoPaquete);
                    paquetesList.Add(paquete);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return paquetesList;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CPaquete> listarPaquetesPorOferta(int ofertaId)
        {
            List<CPaquete> paquetesList = new List<CPaquete>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Paquete WHERE paq_fk_oferta = "+ ofertaId;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CPaquete paquete = new CPaquete(Int32.Parse(lector["paq_id"].ToString()), lector["paq_nombre"].ToString(),
                    float.Parse(lector["paq_precio"].ToString()));
                    paquetesList.Add(paquete);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return paquetesList;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<COferta> listarOfertasEnBD()
        {
            List<COferta> ofertasList = new List<COferta>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Oferta";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    String estado = lector["ofe_estado"].ToString();
                    bool estadoOferta;
                    if (estado == "True")
                        estadoOferta = true;
                    else
                        estadoOferta = false;

                    COferta oferta = new COferta(Int32.Parse(lector["ofe_id"].ToString()), lector["ofe_nombre"].ToString(),
                    float.Parse(lector["ofe_porcentaje"].ToString()),Convert.ToDateTime(lector["ofe_fechaInicio"].ToString()),
                    Convert.ToDateTime(lector["ofe_fechaFin"].ToString()), estadoOferta);
                    ofertasList.Add(oferta);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return ofertasList;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Procedimiento del Modulo 11 para asociar ofertas a paquetes.
        public Boolean asociarOfertaPaquete(int[] idsPaquetes)
        {
            try
            {
                //Obtengo el id de la oferta agregada
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT IDENT_CURRENT('Oferta');";
                int idOferta = Convert.ToInt32(query.ExecuteScalar());
                conexion.Close();
                foreach(int idPaquete in idsPaquetes){
                    conexion.Open();
                    SqlCommand query1 = conexion.CreateCommand();
                    query1.CommandText = "UPDATE Paquete SET paq_fk_oferta = "+idOferta+" WHERE paq_id = "+idPaquete+";";
                    SqlDataReader lector1 = query1.ExecuteReader();
                    lector1.Close();
                    conexion.Close();
                }
                
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

        //Método modulo 11 para consultar todos los hoteles
        public List<CConsultar> listarHotelesM11()
        {
            try
            {
                List<CConsultar> listHoteles = new List<CConsultar>();
                conexion = new SqlConnection(stringDeConexion);
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
            try
            {
                List<CConsultar> listVuelos = new List<CConsultar>();
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = 
                    "SELECT v.vue_id, v.vue_codigo, l1.lug_nombre, l2.lug_nombre " +
                    "FROM vuelo v, ruta r, lugar l1, lugar l2 "+
                    "WHERE v.vue_fk_ruta = r.rut_id and r.rut_fk_lugar_origen = l1.lug_id and r.rut_fk_lugar_destino = l2.lug_id and vue_status = 'activo'";
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

        public List<CConsultar> listarBoletosM11()
        {
            try
            {
                List<CConsultar> listHoteles = new List<CConsultar>();
                conexion = new SqlConnection(stringDeConexion);
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

        //Método modulo 11 para consultar todos los hoteles
        public List<CConsultar> listarCrucerosM11()
        {
            try
            {
                List<CConsultar> listHoteles = new List<CConsultar>();
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT * FROM Crucero";
                SqlDataReader lector = query.ExecuteReader();
                while (lector.Read())
                {
                    CConsultar consulta = new CConsultar();
                    consulta._id = Int32.Parse(lector["cru_id"].ToString());
                    consulta._nombre = lector["cru_nombre"].ToString();
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
        
        //Fin modulo 11

        //Procedimiento del Modulo 2 para retornar una lista con los aviones en la bd
        public List<CAvion> listarAvionesEnBD()
        {
            List<CAvion> aviones = new List<CAvion>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Avion";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CAvion avion = new CAvion(Int32.Parse(lector["avi_id"].ToString()), lector["avi_matricula"].ToString(),
                    lector["avi_modelo"].ToString(), Int32.Parse(lector["avi_pasajeros_turista"].ToString()), 
                    Int32.Parse(lector["avi_pasajeros_ejecutiva"].ToString()), Int32.Parse(lector["avi_pasajeros_vip"].ToString()), 
                    float.Parse(lector["avi_cap_equipaje"].ToString()), float.Parse(lector["avi_max_dist"].ToString()), 
                    float.Parse(lector["avi_max_vel"].ToString()), float.Parse(lector["avi_max_comb"].ToString()),
                    Int32.Parse(lector["avi_disponibilidad"].ToString()));
                    aviones.Add(avion);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return aviones;

            }
            catch ( SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Procedimiento del Modulo 2 para retornar un objeto del tipo CAvion buscado por su respectiva id
        public CAvion consultarAvion(int id)
        {
            CAvion avionRetorno = new CAvion();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Avion where avi_id = "+id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    
                    CAvion avion = new CAvion(Int32.Parse(lector["avi_id"].ToString()), lector["avi_matricula"].ToString(),
                    lector["avi_modelo"].ToString(), Int32.Parse(lector["avi_pasajeros_turista"].ToString()),
                    Int32.Parse(lector["avi_pasajeros_ejecutiva"].ToString()), Int32.Parse(lector["avi_pasajeros_vip"].ToString()),
                    float.Parse(lector["avi_cap_equipaje"].ToString()), float.Parse(lector["avi_max_dist"].ToString()),
                    float.Parse(lector["avi_max_vel"].ToString()), float.Parse(lector["avi_max_comb"].ToString()),
                    Int32.Parse(lector["avi_disponibilidad"].ToString()));
                    avionRetorno = avion;
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return avionRetorno;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Procedimiento del Modulo 2 para modificar un avion
        public Boolean modificarAvion(CModificarAvion model)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Avion SET avi_modelo='"+model._modeloAvion+"', avi_pasajeros_turista="+model._capacidadPasajerosTurista+", avi_pasajeros_ejecutiva="+model._capacidadPasajerosEjecutiva+", avi_pasajeros_vip='"+model._capacidadPasajerosVIP+"', avi_cap_equipaje="+model._capacidadEquipaje+", avi_max_dist="+model._distanciaMaximaVuelo+", avi_max_vel="+model._velocidadMaximaDeVuelo+", avi_max_comb="+model._capacidadMaximaCombustible+" WHERE (avi_matricula='"+model._matriculaAvion+"')";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Procedimiento del Modulo 2 para deshabilitar un avion
        public Boolean deshabilitarAvion(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Avion SET avi_disponibilidad=0 where avi_id="+id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Procedimiento del Modulo 2 para habilitar un avion
        public Boolean habilitarAvion(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Avion SET avi_disponibilidad=1 where avi_id=" + id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
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
            
            conexion = new SqlConnection(stringDeConexion);

            conexion.Open();

            SqlCommand query = conexion.CreateCommand();

            String[] strDes = model._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
            String[] strOri = model._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);
            
            
            
            String dist = model._distanciaRuta.ToString();
            String miquery = "EXEC M03_AgregarRuta '" + strOri[0] + "','" + strOri[1] + "','" + strDes[0] + "' , '" + strDes[1] + "', '" + model._tipoRuta + "', '" + model._estadoRuta + "', " + dist;
            System.Diagnostics.Debug.WriteLine(miquery);

            query.CommandText = miquery;

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
                        _zonaHoraria = (int)lector.GetSqlInt32(3),
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
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine("Exception caught: {0}", e);
                throw e;
                //return null;
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
                        _zonaHoraria = (int)lector.GetSqlInt32(3),
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




        //Procedimiento del Modulo 13 para retornar lista de los modulos generales
        public CListaGenerica<CModulo_general> consultarLosModulos()
        {
            CListaGenerica<CModulo_general> modulo_general = new CListaGenerica<CModulo_general>();           
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta 
                String query = "SELECT m.mod_gen_nombre as Modulo_Detallado FROM modulo_general m";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CModulo_general();
                    entrada.Nombre = lector.GetSqlString(0).ToString();                   
                    modulo_general.agregarElemento(entrada);
                }
                //cierro el lector
                lector.Close();
                //Cerrar la conexion
                conexion.Close();
                return modulo_general;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Procedimiento del Modulo 13 para insertar Roles
        public Boolean insertarRol(CRoles model)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "INSERT INTO Rol VALUES ('" + model.Nombre_rol + "')";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior
                SqlDataReader lector = query.ExecuteReader();
                //Cierro la conexion
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
        /* FIN DE FUNCIONES COMUNES */
    }
}