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
using BOReserva.Models.gestion_automoviles;


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


        /// <summary>
        /// Procedimiento del Modulo 2 para agregar aviones a la base de datos.
        /// </summary>
        /// <param name="model">CAgregarAvion</param>
        /// <returns>Boolean. Retorna true si agregó correctamente a la bbdd o false en caso contrario</returns>
        public Boolean insertarAvion(CAgregarAvion model)
        {
            try
            {
                if (model._matriculaAvion == null)
                {
                    return false;
                }
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

        /// <summary>
        /// Procedimiento del Modulo 2 para retornar una lista con los aviones en la base de datos
        /// </summary>
        /// <returns> List<CAvion> la lista de aviones en la base de datos</returns>
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
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Procedimiento del Modulo 2 para retornar un objeto del tipo CAvion buscado por su respectiva id
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> CAvion el avion buscado</returns>
        public CAvion consultarAvion(int id)
        {
            CAvion avionRetorno = null;
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Avion where avi_id = " + id;
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


        /// <summary>
        /// Procedimiento del Modulo 2 para modificar un avion
        /// </summary>
        /// <param name="model"> CModificarAvion </param>
        /// <returns> Boolean true si se modifico bien, false si no </returns>
        public Boolean modificarAvion(CModificarAvion model)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Avion SET avi_modelo='" + model._modeloAvion + "', avi_pasajeros_turista=" + model._capacidadPasajerosTurista + ", avi_pasajeros_ejecutiva=" + model._capacidadPasajerosEjecutiva + ", avi_pasajeros_vip='" + model._capacidadPasajerosVIP + "', avi_cap_equipaje=" + model._capacidadEquipaje + ", avi_max_dist=" + model._distanciaMaximaVuelo + ", avi_max_vel=" + model._velocidadMaximaDeVuelo + ", avi_max_comb=" + model._capacidadMaximaCombustible + " WHERE (avi_matricula='" + model._matriculaAvion + "')";
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

        /// <summary>
        /// Procedimiento del Modulo 2 para deshabilitar un avion
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns>Boolean true si se deshabilito bien, false si dio un error </returns>
        public Boolean deshabilitarAvion(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Avion SET avi_disponibilidad=0 where avi_id=" + id;
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

        /// <summary>
        /// Procedimiento del Modulo 2 para habilitar un avion
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Boolean true si se habilito bien, false si dio un error </returns>
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


        /// <summary>
        /// Metodo para eliminar un avion de la base de datos
        /// </summary>
        /// <param name="id"> id del avion a eliminar</param>
        /// <returns>Booleano que resultara true si la eliminacion se ejecuta, false en caso de error</returns>
        public Boolean eliminarAvion(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "DELETE FROM AVION WHERE avi_id=" + id;
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

        //Procedimiento del Modulo 11 para agregar ofertas a la base de datos.
        public Boolean agregarOferta(CAgregarOferta model)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "INSERT INTO Oferta VALUES ('" + model._nombreOferta + "','" + model.formatDate(model._fechaIniOferta) + "', '" + model.formatDate(model._fechaFinOferta) + "'," + model._porcentajeOferta + ",'" + model._estadoOferta + "');";
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
                query.CommandText = "UPDATE Oferta SET of_estado = 0 WHERE of_id=" + ofertaId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
                SqlCommand query1 = conexion.CreateCommand();
                query1.CommandText = "UPDATE Paquete SET pa_fk_oferta = null WHERE pa_fk_oferta=" + ofertaId;
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
                query.CommandText = "UPDATE Oferta SET of_estado = 1 WHERE of_id=" + ofertaId;
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
                String query = "SELECT * FROM Paquete WHERE pa_fk_oferta = null";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CPaquete paquete = new CPaquete(Int32.Parse(lector["pa_codigo"].ToString()), lector["pa_nombre"].ToString(),
                    float.Parse(lector["pa_precio"].ToString()));
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
                String query = "SELECT * FROM Paquete WHERE pa_fk_oferta = " + ofertaId;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CPaquete paquete = new CPaquete(Int32.Parse(lector["pa_id"].ToString()), lector["pa_nombre"].ToString(),
                    float.Parse(lector["pa_precio"].ToString()));
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
                    String estado = lector["of_estado"].ToString();
                    bool estadoOferta;
                    if (estado == "True")
                        estadoOferta = true;
                    else
                        estadoOferta = false;

                    COferta oferta = new COferta(Int32.Parse(lector["of_id"].ToString()), lector["of_nombre"].ToString(),
                    float.Parse(lector["of_porcentaje"].ToString()), Convert.ToDateTime(lector["of_fechaInicio"].ToString()),
                    Convert.ToDateTime(lector["of_fechaFin"].ToString()), estadoOferta);
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
                foreach (int idPaquete in idsPaquetes)
                {
                    conexion.Open();
                    SqlCommand query1 = conexion.CreateCommand();
                    query1.CommandText = "UPDATE Paquete SET pa_fk_oferta = " + idOferta + " WHERE pa_id = " + idPaquete + ";";
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

        //Fin modulo 11



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
                    + model._puntuacion + " , " + model._direccion + "," + model._paginaweb + ");";
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
                query.CommandText = "SELECT * FROM Restaurante WHERE rst_id = " + id.ToString();
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
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
                    "', fk_lugar = " + model._idLugar + " WHERE rst_id = " + model._id.ToString();
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

        //Procedimiento del Modulo 13 para retornar lista de roles
        public List<CRoles> consultarListaroles()
        {
            List<CRoles> _roles = new List<CRoles>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                SqlConnection conexion2 = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta 
                String query = "select rol_nombre,rol_id from rol";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    CRoles _rol = new CRoles();
                    _rol.Nombre_rol = lector.GetSqlString(0).ToString();
                    string a = lector.GetSqlInt32(1).ToString();
                    //Abrir la conexion
                    conexion2.Open();
                    //query es un string que me devolvera la consulta 
                    String query2 = "select mod_det_nombre from Rol_Modulo_Detallado,Modulo_Detallado where "+lector.GetSqlInt32(1)+"=fk_rol_id and mod_det_id=fk_mod_det_id";
                    SqlCommand cmd2 = new SqlCommand(query2, conexion2);
                    SqlDataReader lector2 = cmd2.ExecuteReader();
                    //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                    while (lector2.Read())
                    {                       
                        var entrada = new CModulo_detallado();
                        entrada.Nombre = lector2.GetSqlString(0).ToString();
                        //agrego un permiso a la lista de roles
                        _rol.Permisos.agregarElemento(entrada);
                        
                    }
                    //cierro el lector
                    lector2.Close();
                    //Cerrar la conexion
                    conexion2.Close();
                    //Agrego rol a la lista de roles
                    _roles.Add(_rol);
                }
                //cierro el lector
                lector.Close();
                //Cerrar la conexion
                conexion.Close();
                return _roles;
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

        //Meotodo del Modulo 13 para retornar lista de los 

        public List<String> M13consultarRolesDeUnUsuario(int id)
        {
            try
            {

                List<String> listarModuloDetallado = new List<String>();

                CRestauranteModelo entrada = null;
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                String prueba = "165";
                query.CommandText = "SELECT usu_id, usu_nombre , rol_nombre , mod_det_nombre  FROM usuario , rol  ,Rol_Modulo_Detallado , Modulo_Detallado WHERE usu_fk_rol = rol_id AND usu_id = '" + id + "' AND mod_det_id = fk_mod_det_id AND rol_id = fk_rol_id";

                SqlDataReader lector = query.ExecuteReader();

                int i = 0;
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {

                    //Debug.WriteLine("id del usuario " + lector["usu_id"].ToString());
                    Debug.WriteLine("id del usuario nombre " + lector["usu_nombre"].ToString());
                    Debug.WriteLine("id del id rol " + lector["rol_nombre"].ToString());
                    Debug.WriteLine("id del id rol " + lector["mod_det_nombre"].ToString());
                    i += 1;
                    Debug.WriteLine("id del usuario " + i);


                    listarModuloDetallado.Add(lector["mod_det_nombre"].ToString());


                }

                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listarModuloDetallado;
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

        //Procedimiento del Modulo 13 para retornar lista de los modulos detallados
        public CListaGenerica<CModulo_detallado> consultarPermisos(String modulo)
        {
            CListaGenerica<CModulo_detallado> modulo_detallado = new CListaGenerica<CModulo_detallado>();
            try
            {

                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta 
                System.Diagnostics.Debug.WriteLine(modulo);
                String query = "SELECT mod_det_nombre,mod_det_url FROM Modulo_Detallado,Modulo_general WHERE mod_gen_id=fk_mod_gen_id and mod_gen_nombre='" + modulo + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CModulo_detallado();
                    entrada.Nombre = lector.GetSqlString(0).ToString();
                    entrada.Url = lector.GetSqlString(1).ToString();
                    modulo_detallado.agregarElemento(entrada);

                }
                //cierro el lector
                lector.Close();
                //Cerrar la conexion
                conexion.Close();
                return modulo_detallado;

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
                //cierro el lector
                lector.Close();
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


        public string MBuscarid_IdRol(string rolBuscar) {

            string rolIdDevolver = "" ;
            conexion = new SqlConnection(stringDeConexion);
            //INTENTO abrir la conexion
            conexion.Open();
            String query = "SELECT rol_id  FROM Rol WHERE rol_nombre = '"+rolBuscar+"'" ;
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                rolIdDevolver = lector["rol_id"].ToString();
                
            }
            //cierro el lector
            lector.Close();
            //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
            conexion.Close();
            return rolIdDevolver;
        }


        public string MBuscarid_Permiso(string permisoBucar)
        {

            string PermisoIdDevolver = "";
            conexion = new SqlConnection(stringDeConexion);
            //INTENTO abrir la conexion
            conexion.Open();
            String query = "SELECT mod_det_id  FROM modulo_detallado WHERE mod_det_nombre ='" + permisoBucar + "'";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                PermisoIdDevolver = lector["mod_det_id"].ToString();

            }
            //cierro el lector
            lector.Close();
            //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
            conexion.Close();
            return PermisoIdDevolver;
        }


        //Metodo para insertar permisos de un rol 
        public Boolean insertarPermisosRol(string rol , string permiso)
        {
             List<CAvion> aviones = new List<CAvion>();
            try
            {
                System.Diagnostics.Debug.WriteLine("Entro en roles");
                string idRol = "";
                string idPermiso = "";

                //Metodo para que busque el id del rol
                System.Diagnostics.Debug.WriteLine("--------- " + idRol);

                idRol       = MBuscarid_IdRol(rol);
                System.Diagnostics.Debug.WriteLine("id rol " + idRol);

                //Metodo para que busque el id del permisos
                System.Diagnostics.Debug.WriteLine("--------- " + idRol);
                idPermiso   = MBuscarid_Permiso(permiso);
                System.Diagnostics.Debug.WriteLine("id permiso " + idPermiso);


                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);

                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                String queryString;
                SqlCommand cmd;
                SqlDataReader lector;

                query.CommandText = "INSERT INTO Rol_Modulo_Detallado VALUES ('" + idRol + "','" + idPermiso + "')";
                lector = query.ExecuteReader();
                lector.Close();
                conexion.Close();


                return true;

            }
            catch ( SqlException e)
            
            {
                Debug.WriteLine("Exception sql");
                return false;

                throw e;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception e");

                return false;

                throw e;

            }
        }


        public Boolean insertarPermisosRol(CRoles rol , CListaGenerica<CModulo_detallado> listaPermisos)
        {
             List<CAvion> aviones = new List<CAvion>();
            try
            {
                string idRol = "";

                List<string> listaPermiso = new List<string>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT rol_id FROM Rol where rol_nombre = '"+rol.Nombre_rol+"'";
               
                SqlCommand cmd = new SqlCommand(query, conexion);


                SqlDataReader lector = cmd.ExecuteReader();


                while (lector.Read())
                {

                      Debug.WriteLine("IDiiiiiii" + lector["rol_id"].ToString());
                      idRol = lector["rol_id"].ToString();
                      Debug.WriteLine("----------------");

                }

 
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlDataReader lectorDetalle = null ;
                String queryDetallado , queryInsertar; 

                foreach (var detalle in listaPermisos)
                {
                    Debug.WriteLine("Amount is {0} and type is {1}", detalle.Nombre, detalle.Url);
               
                    queryDetallado = "SELECT mod_det_id from Modulo_Detallado where mod_det_nombre = '" + detalle.Nombre + "'";
                    Debug.WriteLine("---------3-------");


                    SqlCommand cmd2 = new SqlCommand(queryDetallado, conexion);

                    Debug.WriteLine("--------4--------");


                    lectorDetalle = cmd2.ExecuteReader();

                    Debug.WriteLine("-------41---------");


                    while (lectorDetalle.Read())
                    {

                        Debug.WriteLine("ID metodo detallado " + lectorDetalle["mod_det_id"].ToString());

                        listaPermiso.Add(lectorDetalle["mod_det_id"].ToString());
                                                                    
                        Debug.WriteLine("----------------");

                    }
                    Debug.WriteLine("-----------5-----");
                    lectorDetalle.Close();

                }

                insertarRolPermisos(idRol, listaPermiso);
                conexion.Close();
                
                return true;

            }
            catch ( SqlException e)
            
            {
                Debug.WriteLine("Exception sql");
                return false;

                throw e;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception e");

                return false;

                throw e;

            }
        }

        public void insertarRolPermisos(string rol, List<string> listaString)
        {


            Debug.WriteLine("Rol "+rol);
            Debug.WriteLine("Rol " + listaString.Count);
            if (listaString.Count > 0)
            {
                int i = 0;
                foreach (var money in listaString)
                {
                    i += 0; 
                    Debug.WriteLine("Rol " + listaString[i]);

                }



                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                String queryString;
                SqlCommand cmd;
                SqlDataReader lector;

                //ingreso la orden del query

 

                foreach (var money in listaString)
                {
                    
                    Debug.WriteLine("este es el valor de i " + i);
                    Debug.WriteLine("+++++1+++++");

                    query.CommandText = "INSERT INTO Rol_Modulo_Detallado VALUES ('" + rol + "','" + listaString[i] + "')";
                    Debug.WriteLine("+++++2+++++");

                    lector = query.ExecuteReader();
                    Debug.WriteLine("+++++3+++++");

                    //cierro el lector
                    lector.Close();
                    Debug.WriteLine("+++++4+++++");


                    i += 1;
                    
                }

                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();



            }

        }
        
        
        /* FIN DE FUNCIONES COMUNES */

        /* MODULO 8 GESTION DE AUTOMOVILES*/
        /// <summary>
        /// Método que agrega un vehículo a la base de datos
        /// </summary>
        /// <param name="vehiculo">Vehículo a agregar a la base de datos</param>
        /// <param name="id">El id de la ciudad a donde será agregado</param>
        /// <returns>Retorna 1 si se agregó exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MAgregarVehiculoBD(Automovil vehiculo, int id)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "INSERT INTO Automovil VALUES ('" + vehiculo._matricula + "', '" + vehiculo._modelo + "', '" + vehiculo._fabricante + "', " + vehiculo._anio + ", " + vehiculo._kilometraje + ", " + vehiculo._cantpasajeros + ", '" + vehiculo._tipovehiculo +
                    "', " + vehiculo._preciocompra + ", " + vehiculo._precioalquiler + ", " + vehiculo._penalidaddiaria + ", '" + vehiculo._fecharegistro + "', '" + vehiculo._color + "', " + 1 + ", '" + vehiculo._transmision + "', " + id + ")";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método que modifica un vehículo existente de la base de datos
        /// </summary>
        /// <param name="vehiculo">Vehículo a modificar de la base de datos</param>
        /// <param name="id">El id de la ciudad a donde se ubica</param>
        /// <returns>Retorna 1 si se modificó exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MModificarVehiculoBD(Automovil vehiculo, int id)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "UPDATE Automovil SET aut_modelo ='" + vehiculo._modelo + "', aut_fabricante = '" + vehiculo._fabricante + "', aut_anio = " + vehiculo._anio + ", aut_kilometraje = " + vehiculo._kilometraje + ", aut_cantpasajeros = " + vehiculo._cantpasajeros + ", aut_tipovehiculo = '" + vehiculo._tipovehiculo +
                    "', aut_preciocompra = " + vehiculo._preciocompra + ", aut_precioalquiler = " + vehiculo._precioalquiler + ", aut_penalidaddiaria = " + vehiculo._penalidaddiaria + ", aut_fecharegistro = '" + vehiculo._fecharegistro + "', aut_color = '" + vehiculo._color + "', aut_transmision = '" + vehiculo._transmision + "', aut_fk_ciudad = " + id +
                    " WHERE aut_matricula = '" + vehiculo._matricula + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método que lista todos los vehículos de la base de datos
        /// </summary>
        /// <returns>Retorna una lista de tipo Automovil</returns>
        public List<Automovil> MListarvehiculosBD()
        {
            List<Automovil> listavehiculos = new List<Automovil>();
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Automovil";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        var fecha = reader["aut_fecharegistro"];
                        DateTime fecharegistro = Convert.ToDateTime(fecha).Date;
                        Automovil vehiculo = new Automovil(reader["aut_matricula"].ToString(), reader["aut_modelo"].ToString(), reader["aut_fabricante"].ToString(),
                                               Int32.Parse(reader["aut_anio"].ToString()), reader["aut_tipovehiculo"].ToString(),
                                               double.Parse(reader["aut_kilometraje"].ToString()), Int32.Parse(reader["aut_cantpasajeros"].ToString()),
                                               double.Parse(reader["aut_preciocompra"].ToString()), double.Parse(reader["aut_precioalquiler"].ToString()),
                                               double.Parse(reader["aut_penalidaddiaria"].ToString()), fecharegistro,
                                               reader["aut_color"].ToString(), Int32.Parse(reader["aut_disponibilidad"].ToString()), reader["aut_transmision"].ToString(),
                                               MBuscarnombreciudadBD(Int32.Parse(reader["aut_fk_ciudad"].ToString())), MBuscarnombrePaisBD(Int32.Parse(reader["aut_fk_ciudad"].ToString()))
                                               );
                        listavehiculos.Add(vehiculo);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listavehiculos;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }


        /// <summary>
        /// Método para buscar un vehículo en particular de la base de datos
        /// </summary>
        /// <param name="matricula">La matrícula del vehículo a buscar</param>
        /// <returns>Retorna un objeto de tipo Automovil</returns>
        public Automovil MMostrarvehiculoBD(String matricula)
        {
            Automovil vehiculo = null;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Automovil WHERE aut_matricula = '" + matricula + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["aut_fecharegistro"];
                        DateTime fecharegistro = Convert.ToDateTime(fecha).Date;
                        vehiculo = new Automovil(reader["aut_matricula"].ToString(), reader["aut_modelo"].ToString(), reader["aut_fabricante"].ToString(),
                                                 Int32.Parse(reader["aut_anio"].ToString()), reader["aut_tipovehiculo"].ToString(),
                                                 double.Parse(reader["aut_kilometraje"].ToString()), Int32.Parse(reader["aut_cantpasajeros"].ToString()),
                                                 double.Parse(reader["aut_preciocompra"].ToString()), double.Parse(reader["aut_precioalquiler"].ToString()),
                                                 double.Parse(reader["aut_penalidaddiaria"].ToString()), fecharegistro,
                                                 reader["aut_color"].ToString(), Int32.Parse(reader["aut_disponibilidad"].ToString()), reader["aut_transmision"].ToString(),
                                                 MBuscarnombreciudadBD(Int32.Parse(reader["aut_fk_ciudad"].ToString())), MBuscarnombrePaisBD(Int32.Parse(reader["aut_fk_ciudad"].ToString()))
                                                 );
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return vehiculo;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }


        /// <summary>
        /// Método que busca en la base de datos el identificador de una ciudad
        /// </summary>
        /// <param name="ciudad">Ciudad cuyo identificador se desea conocer</param>
        /// <param name="pais">País en donde se ubica la ciudad</param>
        /// <returns>Retorna el identificador de la ciudad</returns>
        public int MBuscaridciudadBD(String ciudad, String pais)
        {
            int id_ciudad = 12;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT d.lug_id FROM LUGAR C, LUGAR D WHERE C.lug_id = d.lug_FK_lugar_id AND C.lug_nombre = '" + pais + "' and D.lug_nombre = '" + ciudad + "'"; /*ESTE SQL ES EN CASO DE QUE NO SE MANEJE AL FINAL ESTADOS SINO SOLO PAISES Y CIUDADES*/
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id_ciudad = Int32.Parse(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return id_ciudad;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return id_ciudad;
            }
        }



        /// <summary>
        /// Método para borrar un vehículo de la base de datos
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a borrar</param>
        /// <returns>Retorna 1 si se eliminó exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MBorrarvehiculoBD(String matricula)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "DELETE FROM Automovil WHERE aut_matricula = '" + matricula + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método para buscar el nombre de una ciudad en la base de datos
        /// </summary>
        /// <param name="id">Identificador de la ciudad a buscar</param>
        /// <returns>Retorna el nombre de la ciudad</returns>
        public String MBuscarnombreciudadBD(int id)
        {
            String _ciudad = "Error al buscar";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'"; ;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudad = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _ciudad;
            }
        }



        /// <summary>
        /// Método para buscar el nombre de un país
        /// </summary>
        /// <param name="ciudad">Identificador de la ciudad que pertenece a dicho país</param>
        /// <returns>Retorna el nombre de la ciudad</returns>
        public String MBuscarnombrePaisBD(int ciudad)
        {
            String _lugar = "Error al buscar";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT E.lug_nombre FROM LUGAR E, LUGAR C WHERE E.lug_id = C.lug_fk_lugar_id " +
                             "AND C.lug_id = " + ciudad;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _lugar = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _lugar;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _lugar;
            }
        }



        /// <summary>
        /// Método para listar todos los países de la base de datos
        /// </summary>
        /// <returns>Retorna un String[] con todos los países</returns>
        public String[] MListarpaisesBD()
        {
            String[] listapaises = new String[5000];
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT lug_nombre FROM Lugar WHERE lug_tipo_lugar = 'pais'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                int i = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listapaises[i] = reader[0].ToString();
                        i++;
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listapaises;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
            catch (InvalidOperationException ex)
            {
                conexion.Close();
                return null;
            }
        }


        /// <summary>
        /// Método que retorna el identificador de un país
        /// </summary>
        /// <param name="pais">Nombre del país cuyo identificador se desea conocer</param>
        /// <returns>Retorna el identificador del país</returns>
        public int MIdpaisesBD(String pais)
        {
            int fk = -1;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT lug_id FROM Lugar WHERE lug_nombre = '" + pais + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fk = Int32.Parse(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return fk;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return fk;
            }
        }

        /// <summary>
        /// Método para cambiar la disponibilidad de un vehículo de la base de datos
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo cuya disponibilidad se desea cambiar</param>
        /// <param name="activardesactivar">Estatus por el cual se desea cambiar (1 para activar, 0 para desactivar)</param>
        /// <returns>Retorna 1 si se cambio el estatus exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MDisponibilidadVehiculoBD(string matricula, int activardesactivar)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "UPDATE Automovil SET aut_disponibilidad = " + activardesactivar + " WHERE aut_matricula = '" + matricula + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método para listar todas las ciudades de un país
        /// </summary>
        /// <param name="fk">Identificador de país del cual se desea conocer sus ciudades</param>
        /// <returns>Retorna una lista de String que posee las ciudades</returns>
        public List<string> MListarciudadesBD(int fk)
        {
            List<String> _ciudades = new List<string>();
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT lug_nombre FROM Lugar WHERE lug_fk_lugar_id = " + fk;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudades.Add(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return _ciudades;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return _ciudades;
            }
        }

    }
}
