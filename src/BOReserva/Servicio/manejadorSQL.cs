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
using BOReserva.Models.gestion_comida_vuelo;
using System.Configuration;


namespace BOReserva.Servicio
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




        //Procedimiento del Modulo 6 para agregar platos a la base de datos.
        public Boolean insertarPlato(CAgregarComida model)
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
                query.CommandText = "INSERT INTO Comida VALUES ('" + model._nombrePlato + "','" + model._tipoPlato + "',1,' " + model._descripcionPlato + "');";
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
        //Procedimiento del Modulo 6 para retornar una lista con los platos en la bd
        public List<CComida> listarPlatosEnBD()
        {
            List<CComida> platos = new List<CComida>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Comida";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CComida plato = new CComida(Int32.Parse(lector["com_id"].ToString()), lector["com_nombre"].ToString(),
                    lector["com_tipo"].ToString(), Convert.ToInt32(lector["com_estatus"]), lector["com_referencia"].ToString());
                    platos.Add(plato);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return platos;

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

        //Procedimiento del Modulo 6 para Retornar una lista con los datos del vuelo y el avion

        public List<CVuelo> listarVuelosEnBD()
{
	List<CVuelo> vuelos = new List<CVuelo>();
	try
	{
		conexion = new SqlConnection(stringDeConexion);
		conexion.Open();
		String query = "SELECT v.vue_id AS id, v.vue_codigo AS codigo,origen.lug_nombre AS origen,destino.lug_nombre AS destino, a.avi_pasajeros_turista AS turista, a.avi_pasajeros_ejecutiva AS ejecutiva, a.avi_pasajeros_vip AS vip "+
                        "FROM Vuelo AS v, avion a, ruta r, lugar origen, lugar destino "+
                        "WHERE a.avi_id = v.vue_fk_avion AND "+
                        "v.vue_fk_ruta = r.rut_id AND "+
                        "r.rut_FK_lugar_origen = origen.lug_id AND "+
                        "r.rut_Fk_lugar_destino = destino.lug_id AND v.vue_status = 'activo'";
        SqlCommand cmd = new SqlCommand(query, conexion);
        SqlDataReader lector = cmd.ExecuteReader();
        while (lector.Read())
        {
            CVuelo vuelo = new CVuelo(Convert.ToInt32(lector["id"].ToString()),
                                      lector["codigo"].ToString(),
        		                      lector["origen"].ToString(),
                                      lector["destino"].ToString(),
        		                      Int32.Parse(lector["turista"].ToString()),
        		                      Int32.Parse(lector["ejecutiva"].ToString()),
        		                      Int32.Parse(lector["vip"].ToString()));
        	vuelos.Add(vuelo);
        }
        lector.Close();
        conexion.Close();
        return vuelos;
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

        //Procedimiento del Modulo 6 para retornar un objeto del tipo CComida buscado por su respectiva id
        public CComida consultarComida(int id)
        {
            CComida platoRetorno = new CComida();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Comida where comi_id = " + id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {

                    CComida plato = new CComida(Int32.Parse(lector["comi_id"].ToString()), lector["comi_nombre"].ToString(),
                    lector["comi_tipo"].ToString(), Convert.ToInt32(lector["com_estatus"]), lector["comi_descripcion"].ToString()); ;
                    platoRetorno = plato;
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return platoRetorno;

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


        //Procedimiento del Modulo 6 para modificar un plato
        public Boolean modificarPlato(CEditarComida model)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Comida SET comi_estatus='" + model._nombrePlato + "','" + model._tipoPlato + "'," + model._estatusPlato + " , " + model._descripcionPlato + "')";
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
        /// Procedimiento del Modulo 6 para deshabilitar un plato
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns>Boolean true si se deshabilito bien, false si dio un error </returns>
        public Boolean deshabilitarPlato(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Comida SET com_estatus=0 where com_id=" + id;
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
        /// Procedimiento del Modulo 6 para habilitar un plato
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Boolean true si se habilito bien, false si dio un error </returns>
        public Boolean habilitarPlato(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Comida SET com_estatus=1 where com_id=" + id;
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

        //Procedimiento del Modulo 6 para retornar una lista con los platos en la bd
        public List<CVueloComida> listarVuelosComidaEnBD()
        {
            List<CVueloComida> platos = new List<CVueloComida>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT com_vue_id, com_nombre, vue_codigo, com_vue_cantidad FROM Comida_Vuelo, Comida, Vuelo WHERE com_id = com_vue_fk_comida AND vue_id = com_vue_fk_vuelo ";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    CVueloComida plato = new CVueloComida(Int32.Parse(lector["com_vue_id"].ToString()), lector["vue_codigo"].ToString(),
                    lector["com_nombre"].ToString(), Int32.Parse(lector["com_vue_cantidad"].ToString()));
                    platos.Add(plato);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return platos;
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

        public string[] pasajeroComida(string matriculaAvion)
        {
            try
            {
                string[] pasajeros = null;
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //indico que ejecutare un Stored Procedured en la BD
                SqlCommand cmd = new SqlCommand("M06_Pasajero_XClase", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //le paso los parametros que espera el SP
                cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                //creo un lector sql para la respuesta de la ejecucion del comando anterior
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //tomo un unico valor como esperado segun comportamiento del SP
                    pasajeros[0] = dr.GetSqlString(0).ToString();
                    pasajeros[1] = dr.GetSqlString(1).ToString();
                    pasajeros[2] = dr.GetSqlString(2).ToString();
                }
                //cierro el lector
                dr.Close();
                conexion.Close();
                return pasajeros;
            }
            catch (SqlException e)
            {
                throw (e);

            }
            catch (Exception e)
            {
                throw (e);

            }

        }


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

        /// <summary>
        /// Método para la consulta de ciudades, sin parámetro.
        /// </summary>
        /// <returns>Una lista de modelos de lugar.</returns>
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
                    String query2 = "select mod_det_nombre from Rol_Modulo_Detallado,Modulo_Detallado where " + lector.GetSqlInt32(1) + "=fk_rol_id and mod_det_id=fk_mod_det_id";
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
                    //Agrego los modulos sobre los que el rol tiene permiso
                    _rol.Menu = consultarLosModulosRol(_rol);
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
        //Procedimiento del Modulo 13 para Modificar Roles
        public Boolean ModificarrRol(string model, string nombre_rolnuevo)
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
                query.CommandText = "UPDATE rol set rol_nombre= '" + nombre_rolnuevo + "' where rol_id in (select rol_id from rol where rol_nombre= '" + model + "') ";
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
        //Procedimiento del Modulo 13 para retornar lalista de permisos que no tiene el rol
        public CListaGenerica<CModulo_detallado> consultarLosPermisosNoAsignados(CRoles _rol)
        {
            CListaGenerica<CModulo_detallado> modulo_detallado = new CListaGenerica<CModulo_detallado>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta
                String query = "select mod_det_nombre from modulo_detallado where mod_det_nombre not in(SELECT mod_det_nombre FROM modulo_detallado,rol_modulo_detallado,rol where mod_det_id=fk_mod_det_id AND fk_rol_id=rol_id and rol_nombre='" + _rol.Nombre_rol + "')";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CModulo_detallado();
                    entrada.Nombre = lector.GetSqlString(0).ToString();
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

        //Procedimiento del Modulo 13 para retornar lalista de permisos que tiene el rol
        public CListaGenerica<CModulo_detallado> consultarLosPermisosAsignados(CRoles _rol)
        {
            CListaGenerica<CModulo_detallado> modulo_detallado = new CListaGenerica<CModulo_detallado>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta
                String query = "SELECT mod_det_nombre FROM modulo_detallado,rol_modulo_detallado,rol where mod_det_id=fk_mod_det_id and fk_rol_id=rol_id and rol_nombre='" + _rol.Nombre_rol + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                //ciclo while en donde leere los datos en dado caso que sea un select o la respuesta de un procedimiento de la bd
                while (lector.Read())
                {
                    var entrada = new CModulo_detallado();
                    entrada.Nombre = lector.GetSqlString(0).ToString();
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
        //Procedimiento del Modulo 13 para retornar lista de los modulos generales de cada rol
        public CListaGenerica<CModulo_general> consultarLosModulosRol(CRoles _rol)
        {
            CListaGenerica<CModulo_general>
                modulo_general = new CListaGenerica<CModulo_general>
                    ();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //query es un string que me devolvera la consulta
                String query = "SELECT DISTINCT mod_gen_nombre as Modulo_Detallado FROM modulo_general ,rol,rol_modulo_detallado,modulo_detallado  where rol_id=fk_rol_id and fk_mod_det_id=mod_det_id and fk_mod_gen_id=mod_gen_id and rol_nombre='" + _rol.Nombre_rol + "'";
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
        //Metodo para quitarle todos los permisos aun rol
        public Boolean quitarPermisos(CRoles model)
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
                query.CommandText = "DELETE FROM Rol_Modulo_Detallado WHERE fk_rol_id in (SELECT rol_id from Rol where rol_nombre='" + model.Nombre_rol + "')";
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
        //Metodo para quitarle un permiso a un rol
        public Boolean quitarPermisoRol(CRoles model,CModulo_detallado permiso)
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
                query.CommandText = "DELETE FROM Rol_Modulo_Detallado WHERE fk_rol_id in (SELECT rol_id from Rol where rol_nombre='" + model.Nombre_rol + "') and fk_mod_det_id in (SELECT mod_det_id from modulo_detallado where mod_det_nombre='" + permiso.Nombre + "') ";
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
        //Procedimiento del Modulo 13 borrar Roles
        public Boolean eliminarRol(CRoles model)
        {
            try
            {   //Quito los permisos al rol para luego poder borrarlo
                bool respuesta = quitarPermisos(model);
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //Abrir la conexion
                conexion.Open();
                //SqlCommand para realizar los querys
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "DELETE FROM Rol WHERE rol_nombre='" + model.Nombre_rol + "'";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior
                SqlDataReader lector = query.ExecuteReader();
                //cierro el lector
                lector.Close();
                //Cierro la conexion
                conexion.Close();
                return respuesta;
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
        //Meotodo del Modulo 13 para retornar lista de los

        public List<String> M13consultarRolesDeUnUsuario(String id)
        {
            try
            {

                List<String> listarModuloDetallado = new List<String>();

                CRestauranteModelo entrada = null;
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT usu_id, usu_nombre , rol_nombre , mod_det_nombre  FROM usuario , rol  ,Rol_Modulo_Detallado , Modulo_Detallado WHERE usu_fk_rol = rol_id AND usu_correo = '" + id + "' AND mod_det_id = fk_mod_det_id AND rol_id = fk_rol_id";

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


        public string MBuscarid_IdRol(string rolBuscar)
        {

            string rolIdDevolver = "";
            conexion = new SqlConnection(stringDeConexion);
            //INTENTO abrir la conexion
            conexion.Open();
            String query = "SELECT rol_id  FROM Rol WHERE rol_nombre = '" + rolBuscar + "'";
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
        public Boolean insertarPermisosRol(string rol, string permiso)
        {
            List<CAvion> aviones = new List<CAvion>();
            try
            {
                string idRol = "";
                string idPermiso = "";

                //Metodo para que busque el id del rol
                idRol = MBuscarid_IdRol(rol);
                //Metodo para que busque el id del permisos
                idPermiso = MBuscarid_Permiso(permiso);

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
            catch (SqlException e)
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



        /* FIN DE FUNCIONES COMUNES */

     

        /// <summary>
        /// Método que busca en la base de datos el identificador de una ciudad
        /// </summary>
        /// <param name="ciudad">Ciudad cuyo identificador se desea conocer</param>
        /// <param name="pais">País en donde se ubica la ciudad</param>
        /// <returns>Retorna el identificador de la ciudad</returns>
        public int MBuscaridciudadBD(String ciudad, String pais)
        {
            int id_ciudad = 0;
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
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                        id_ciudad = Int32.Parse(reader[0].ToString()); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return id_ciudad;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                Debug.WriteLine(ex.ToString());
                return id_ciudad;
            }
            catch (NullReferenceException ex)
            {
                conexion.Close();
                Debug.WriteLine(ex.ToString());
                //Error recibiendo los parametros
                return id_ciudad;
            }
            catch (Exception e)
            {
                conexion.Close();
                Debug.WriteLine(e.ToString());
                return id_ciudad;
            }

        }

        /// <summary>
        /// Método para borrar un vehículo de la base de datos
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a borrar</param>
        /// <returns>Retorna 1 si se eliminó exitosamente y retorna la excepcion si no lo pudo hacer</returns>
        public String MBorrarvehiculoBD(String matricula)
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
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
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

            catch (NullReferenceException ex)
            {
                conexion.Close();
                return ex.Message;
            }
        }

        /// <summary>
        /// Método para buscar el nombre de un país
        /// </summary>
        /// <param name="ciudad">Identificador de la ciudad que pertenece a dicho país</param>
        /// <returns>Retorna el nombre del pais</returns>
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
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return _lugar;

            }

            catch (NullReferenceException ex)
            {
                conexion.Close();
                return ex.Message;
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
                listapaises[0] = ex.Message;
                return listapaises;
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

            catch (NullReferenceException ex)
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
        /// <returns>Retorna 1 si se cambio el estatus exitosamente y retorna la excepcion si no lo pudo hacer</returns>
        public String MDisponibilidadVehiculoBD(string matricula, int activardesactivar)
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
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
            }

            catch (NullReferenceException ex)
            {
                conexion.Close();
                return ex.Message;
            }
        }

        /// <summary>
        /// Método para listar todas las ciudades de un país
        /// </summary>
        /// <param name="fk">Identificador de país del cual se desea conocer sus ciudades</param>
        /// <returns>Retorna una lista de String que posee las ciudades o retorna la excepcion</returns>
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
                _ciudades.Add(ex.Message);
                return _ciudades;
            }

            catch (NullReferenceException ex)
            {
                conexion.Close();
                return _ciudades;
            }
        }

        /// <summary>
        /// Método para verificar si una matrícula esta registrada en la BD
        /// </summary>
        /// <param name="matricula">Matrícula a revisar</param>
        /// <returns>Retorna si existe o no la matrícula</returns>
        public int MPlacarepetidaBD(String matricula)
        {
            bool verdad = false;
            int i = 0;
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
                        String matricularetornada = reader[0].ToString();
                        verdad = matricularetornada.Equals(matricula.ToUpper());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                if (verdad == true)
                {
                    i = 1;
                }
                if (verdad == false)
                {
                    i = 0;
                }
                return i;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 1;
            }

            catch (NullReferenceException ex)
            {
                conexion.Close();
                return 1;
            }
        }

        /* FIN MODULO 8 GESTION DE AUTOMOVILES*/

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

        //Procedimiento del Modulo 11 para agregar paquetes a la base de datos.
        public Boolean agregarPaquete(CPaquete paquete)
        {
            try
            {
                int estado;
                if (paquete._estadoPaquete == true)
                    estado = 1;
                else
                    estado = 0;
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "INSERT INTO Paquete (paq_nombre, paq_precio, paq_fk_automovil, paq_fk_restaurante, paq_fk_hotel," +
                    " paq_fk_crucero, paq_fk_vuelo, paq_fechaInicio_automovil, paq_fechaInicio_restaurante, paq_fechaInicio_crucero, paq_fechaInicio_hotel, paq_fechaInicio_boleto," +
                    " paq_fechaFin_automovil, paq_fechaFin_restaurante, paq_fechaFin_hotel, paq_fechaFin_crucero, paq_fechaFin_boleto, paq_estado)" +
                    "VALUES  (@pn, @pp, @pfa, @pfr, @pfh, @pfc, @pfv, @fia, @fir, @fic, @fih, @fib, @ffa, @ffr, @ffh, @ffc, @ffb, @pe);";

                query.Parameters.AddWithValue("@pn", paquete._nombrePaquete);
                query.Parameters.AddWithValue("@pp", paquete._precioPaquete);
                query.Parameters.AddWithValue("@pfa", (object)paquete._idAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfr", (object)paquete._idRestaurante ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfh", (object)paquete._idHabitacion ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfc", (object)paquete._idCrucero ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfv", (object)paquete._idVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@fia", (object)paquete._fechaIniAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@fir", (object)paquete._fechaIniRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@fic", (object)paquete._fechaIniCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@fih", (object)paquete._fechaIniHabi ?? DBNull.Value);
                query.Parameters.AddWithValue("@fib", (object)paquete._fechaIniVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffa", (object)paquete._fechaFinAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffr", (object)paquete._fechaFinRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffh", (object)paquete._fechaFinHabi ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffc", (object)paquete._fechaFinCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffb", (object)paquete._fechaFinVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@pe", estado);

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
        public Boolean modificarPaquete(CPaquete paquete)
        {
            try
            {
                int estado;
                if (paquete._estadoPaquete == true)
                    estado = 1;
                else
                    estado = 0;
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Paquete " +
                    "SET paq_nombre=@pn, paq_precio=@pp, paq_fk_automovil=@pfa, paq_fk_restaurante=@pfr, paq_fk_hotel=@pfh, " +
                    "paq_fk_crucero=@pfc, paq_fk_vuelo=@pfv, paq_fechaInicio_automovil=@fia, paq_fechaInicio_restaurante=@fir, " +
                    "paq_fechaInicio_crucero=@fic, paq_fechaInicio_hotel=@fih, paq_fechaInicio_boleto=@fib, paq_fechaFin_automovil=@ffa, " +
                    "paq_fechaFin_restaurante=@ffr, paq_fechaFin_hotel=@ffh, paq_fechaFin_crucero=@ffc, paq_fechaFin_boleto=@ffb, paq_estado=@pe " +
                    "WHERE paq_id=" + paquete._idPaquete + ";";

                query.Parameters.AddWithValue("@pn", paquete._nombrePaquete);
                query.Parameters.AddWithValue("@pp", paquete._precioPaquete);
                query.Parameters.AddWithValue("@pfa", (object)paquete._idAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfr", (object)paquete._idRestaurante ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfh", (object)paquete._idHabitacion ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfc", (object)paquete._idCrucero ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfv", (object)paquete._idVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@fia", (object)paquete._fechaIniAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@fir", (object)paquete._fechaIniRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@fic", (object)paquete._fechaIniCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@fih", (object)paquete._fechaIniHabi ?? DBNull.Value);
                query.Parameters.AddWithValue("@fib", (object)paquete._fechaIniVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffa", (object)paquete._fechaFinAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffr", (object)paquete._fechaFinRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffh", (object)paquete._fechaFinHabi ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffc", (object)paquete._fechaFinCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffb", (object)paquete._fechaFinVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@pe", estado);

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


        public List<COferta> MListarOfertasBD()
        {
            List<COferta> listaofertas = new List<COferta>();
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Oferta";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fechaInivar = reader["ofe_fechaInicio"];
                        var fechaFinvar = reader["ofe_fechaFin"];
                        var estadovar = reader["ofe_estado"];

                        DateTime fechaInicio = Convert.ToDateTime(fechaInivar).Date;
                        DateTime fechaFin = Convert.ToDateTime(fechaFinvar).Date;
                        Boolean disponibilidad = Convert.ToBoolean(estadovar);


                        List<String> listaPaquetes = new List<String>();

                        listaPaquetes = MBuscarNombrePaquetesDeOferta(Int32.Parse(reader["ofe_id"].ToString()));

                        COferta oferta = new COferta(reader["ofe_id"].ToString(), reader["ofe_nombre"].ToString(), listaPaquetes, float.Parse(reader["ofe_porcentaje"].ToString()),
                                               fechaInicio, fechaFin, disponibilidad);

                        listaofertas.Add(oferta);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaofertas;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }


        public COferta MMostrarOfertaBD(int id)
        {
            COferta oferta = null;
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM Oferta WHERE ofe_ID = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fechaInivar = reader["ofe_fechaInicio"];
                        var fechaFinvar = reader["ofe_fechaFin"];
                        var estadovar = reader["ofe_estado"];

                        DateTime fechaInicio = Convert.ToDateTime(fechaInivar).Date;
                        DateTime fechaFin = Convert.ToDateTime(fechaFinvar).Date;
                        Boolean disponibilidad = Convert.ToBoolean(estadovar);

                        List<String> listaPaquetes = new List<String>();

                        listaPaquetes = MBuscarNombrePaquetesDeOferta(Int32.Parse(reader["ofe_ID"].ToString()));

                        oferta = new COferta(reader["ofe_ID"].ToString(), reader["ofe_nombre"].ToString(), listaPaquetes, float.Parse(reader["ofe_porcentaje"].ToString()),
                                               fechaInicio, fechaFin, disponibilidad);
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return oferta;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }


        public List<String> MBuscarNombrePaquetesDeOferta(int idOferta)
        {
            List<String> listaPaquetes = new List<String>();
            String oferta = "No tiene paquetes asociados";
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM PAQUETE P, OFERTA O WHERE O.ofe_ID = P.paq_fk_oferta " +
                             "AND O.ofe_ID = " + idOferta;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        oferta = reader["paq_nombre"].ToString() + " \n";
                        listaPaquetes.Add(oferta);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaPaquetes;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                listaPaquetes.Add(oferta);
                return listaPaquetes;
            }
        }

        public List<CPaquete> MBuscarPaquetesDeOferta(int idOferta)
        {
            List<CPaquete> listaPaquetes = new List<CPaquete>();
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                String sql = "SELECT * FROM PAQUETE P, OFERTA O WHERE O.ofe_ID = P.paq_fk_oferta " +
                             "AND O.ofe_ID = " + idOferta;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        CPaquete oferta = new CPaquete(Int32.Parse(reader["paq_id"].ToString()), reader["paq_nombre"].ToString(), float.Parse(reader["paq_precio"].ToString()),
                                                        Int32.Parse(reader["paq_fk_oferta"].ToString()));
                        listaPaquetes.Add(oferta);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaPaquetes;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        public int MModificarOfertaBD(COferta oferta, String idStr)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();

                int id = Int32.Parse(idStr);
                //var fechaInivar = oferta._fechaIniOferta;
                //var fechaFinvar = oferta._fechaFinOferta;
                Boolean estadovar = oferta._estadoOferta;
                string fi = oferta._fechaIniOferta.ToString("dd/MM/yyyy");
                string ff = oferta._fechaFinOferta.ToString("dd/MM/yyyy");

                query.CommandText = "UPDATE Oferta SET ofe_nombre = '" + oferta._nombreOferta + "', ofe_fechaInicio = '" + fi + "'" +
                            ", ofe_fechaFin = '" + ff + "', ofe_porcentaje = " + oferta._porcentajeOferta + " WHERE ofe_id = " + id;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return 0;
            }
        }

        public int MDesvincularPaqueteDeOfertaBD(int id)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();

                String sql = "UPDATE PAQUETE SET paq_fk_oferta = null" +
                            " WHERE paq_id = " + id;
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


        public Boolean desactivarOferta(int ofertaId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Oferta SET ofe_estado = 0 WHERE ofe_id=" + ofertaId;
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


        public COferta obtenerOferta(int ofertaId)
        {
            try
            {
                COferta oferta = new COferta();
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "SELECT * from Oferta WHERE ofe_id=" + ofertaId;
                SqlDataReader lector = query.ExecuteReader();
                oferta._idOferta = ofertaId;
                while (lector.Read())
                {
                    oferta._nombreOferta = lector["ofe_nombre"].ToString();
                    oferta._porcentajeOferta = float.Parse(lector["ofe_porcentaje"].ToString());
                }
                lector.Close();
                conexion.Close();
                return oferta;
            }
            catch (SqlException e)
            {
                COferta oferta1 = new COferta();
                return oferta1;
            }
            catch (Exception e)
            {
                COferta oferta2 = new COferta();
                return oferta2;
            }
        }



        public CPaquete detallePaquete(int paqueteId)
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "Select * from Paquete WHERE paq_id=" + paqueteId;
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
                    if (lector["paq_fk_restaurante"].ToString() != "")
                        paquete._idRestaurante = Int32.Parse(lector["paq_fk_restaurante"].ToString());
                    if (lector["paq_fk_crucero"].ToString() != "")
                        paquete._idCrucero = Int32.Parse(lector["paq_fk_crucero"].ToString());
                    if (lector["paq_fk_vuelo"].ToString() != "")
                        paquete._idVuelo = Int32.Parse(lector["paq_fk_vuelo"].ToString());
                    if (lector["paq_fk_oferta"].ToString() != "")
                        paquete._idOferta = Int32.Parse(lector["paq_fk_oferta"].ToString());



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


        public List<CPaquete> listarPaquetesAsociados(int idOferta)
        {
            List<CPaquete> paquetesList = new List<CPaquete>();
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT * FROM Paquete WHERE paq_fk_oferta=" + idOferta;
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
                String query = "SELECT * FROM Paquete WHERE paq_fk_oferta = " + ofertaId;
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
                    float.Parse(lector["ofe_porcentaje"].ToString()), Convert.ToDateTime(lector["ofe_fechaInicio"].ToString()),
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
                foreach (int idPaquete in idsPaquetes)
                {
                    conexion.Open();
                    SqlCommand query1 = conexion.CreateCommand();
                    query1.CommandText = "UPDATE Paquete SET paq_fk_oferta = " + idOferta + " WHERE paq_id = " + idPaquete + ";";
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

        //Procedimiento del Modulo 11 para asociar ofertas a paquetes modificar.
        public Boolean asociarPaquetesModificar(int[] idsPaquetes, int idOferta)
        {
            try
            {
                //Obtengo el id de la oferta agregada
                conexion = new SqlConnection(stringDeConexion);
                foreach (int idPaquete in idsPaquetes)
                {
                    conexion.Open();
                    SqlCommand query1 = conexion.CreateCommand();
                    query1.CommandText = "UPDATE Paquete SET paq_fk_oferta = " + idOferta + " WHERE paq_id = " + idPaquete + ";";
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

        //Procedimiento del Modulo 11 para asociar ofertas a paquetes modificar.
        public Boolean desasociarPaquetesModificar(int[] idsPaquetes, int idOferta)
        {
            try
            {
                //Obtengo el id de la oferta agregada
                conexion = new SqlConnection(stringDeConexion);
                foreach (int idPaquete in idsPaquetes)
                {
                    conexion.Open();
                    SqlCommand query1 = conexion.CreateCommand();
                    query1.CommandText = "UPDATE Paquete SET paq_fk_oferta = null WHERE paq_id = " + idPaquete + ";";
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




        public string stringDeConexions
        {
            get { return this.stringDeConexion; }
            set { this.stringDeConexion = value; }
        }




    }

}
