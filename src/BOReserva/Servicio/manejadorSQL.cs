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


       /* public List<COferta> MListarOfertasBD()
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
        }*/


        /*public COferta MMostrarOfertaBD(int id)
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
        }*/


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
