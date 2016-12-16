using System;
using BOReserva.Models.gestion_ruta_comercial;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Servicio;

namespace BOReserva.Models.gestion_cruceros
{
    public class ConexionBD
    {
        #region Atributos
        private SqlConnection conexion;
        private string strConexion;
        private SqlCommand comando;
        private string query;
        //Inicializo el string de conexion en el constructor
        private manejadorSQL bd = new manejadorSQL();
        public ConexionBD()
        {
            //stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
            this.strConexion = bd.stringDeConexions;
        }
        // cargar metodos despues de creacion del ER y mdf
        #endregion

        #region Conectar con la Base de Datos
        /// <summary>
        /// Metodo para realizar la conexion a la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public SqlConnection Conectar()
        {

            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(strConexion);
                //strConexion = ConfigurationManager.ConnectionStrings["DB_A1380A_reserva"].ConnectionString;
                if (conexion == null)
                {
                    conexion = new SqlConnection(strConexion);
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return conexion;

        }
        #endregion

        #region Desconectar de la Base de Datos
        /// <summary>
        /// Metodo para cerrar la sesion con la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public void Desconectar()
        {

            try
            {
                this.conexion.Close();
            }

            catch (Exception ex)
            {
                throw ex;

            }

        }

        public void Desconectar(SqlConnection conec)
        {

            try
            {
                conec.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        ///<summary>
        /// Método para consultar todos los cruceros de la base de datos
        ///</summary>
        public List<CGestion_crucero> listarCruceros()
        {
            List<CGestion_crucero> listaCruceros = new List<CGestion_crucero>();
            CGestion_crucero crucero;
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.ListarCruceros, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        crucero = new CGestion_crucero();
                        crucero._idCrucero = int.Parse(reader["id"].ToString());
                        crucero._nombreCrucero = reader["nombre"].ToString();
                        crucero._companiaCrucero = reader["compania"].ToString();
                        crucero._capacidadCrucero = int.Parse(reader["capacidad"].ToString());
                        crucero._estatus = reader["estatus"].ToString();
                        listaCruceros.Add(crucero);
                    }
                    reader.Close();
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                return null;
            }
            return listaCruceros;
        }
        ///<summary>
        ///MÃ©todo para insertar un crucero a la base de datos
        ///</summary>
        public Boolean insertarCruceros(CGestion_crucero crucero)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.AgregarCruceros, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@nombrecrucero", crucero._nombreCrucero);
                    comando.Parameters.AddWithValue("@compania", crucero._companiaCrucero);
                    comando.Parameters.AddWithValue("@capacidad", crucero._capacidadCrucero);
                    comando.Parameters.AddWithValue("@imagen", "");


                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CGestion_itinerario> listarItinerario()
        {
            List<CGestion_itinerario> listaItinerarios = new List<CGestion_itinerario>();
            CGestion_itinerario itinerario;
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.ListarItinerario, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                comando.ExecuteNonQuery();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    itinerario = new CGestion_itinerario();
                    itinerario._crucero = reader["nombreCrucero"].ToString();
                    itinerario._fechaInicio = Convert.ToDateTime(reader["fechaInicio"].ToString());
                    itinerario._fechaFin = Convert.ToDateTime(reader["fechaFin"].ToString());
                    itinerario._ItinerarioCrucero = reader["ruta"].ToString();
                    itinerario._estatus = reader["estatus"].ToString();
                    listaItinerarios.Add(itinerario);
                }
                reader.Close();
            }
            return listaItinerarios;
        }
        public List<CGestion_ruta> listarRutas()
        {
            List<CGestion_ruta> listaRuta = new List<CGestion_ruta>();
            CGestion_ruta ruta;
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.ListarRuta, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                comando.ExecuteNonQuery();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ruta = new CGestion_ruta();
                    ruta._idRuta = int.Parse(reader["id"].ToString());
                    ruta._rutaCrucero = reader["ruta"].ToString();

                    listaRuta.Add(ruta);
                }
                reader.Close();
                conexion.Close();
            }
            return listaRuta;
        }

        public void eliminarCrucero(int id_crucero)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.EliminarCruceros, conexion))
            {
                try
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@id", id_crucero);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Boolean estatusCabina(int id_cabina)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.CambioEstatusCabinas, conexion))
            {
                try
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idCabina", id_cabina);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public Boolean insertarCabinas(CGestion_cabina cabina)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.AgregarCabinas, conexion))
                {
                    if (cabina._fkCrucero == null)
                    {
                        return false;
                    }
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@nombrecabina", cabina._nombreCabina);
                    comando.Parameters.AddWithValue("@precio", cabina._precioCabina);
                    comando.Parameters.AddWithValue("@fk_id_crucero", cabina._fkCrucero);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e) {


                return false;
            }
        }

        public Boolean insertarItinerario(CGestion_itinerario itinerario)
        {
            try
            {
                using (comando = new SqlCommand(RecursosCruceros.AgregarItinerario, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha_inicio", itinerario._fechaInicio);
                    comando.Parameters.AddWithValue("@fecha_fin", itinerario._fechaFin);
                    comando.Parameters.AddWithValue("@fk_crucero", itinerario._fkCrucero);
                    comando.Parameters.AddWithValue("@fk_ruta", itinerario._fkRuta);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        } 

        public List<CGestion_cabina> listarCabinas(int idCrucero)
        {
            List<CGestion_cabina> listaCabinas = new List<CGestion_cabina>();
            CGestion_cabina cabina;
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.ListarCabinas, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idCrucero", idCrucero);
                    conexion.Open();
                    //comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        cabina = new CGestion_cabina();
                        cabina._idCabina = int.Parse(reader["id"].ToString());
                        cabina._nombreCabina = reader["nombre"].ToString();
                        cabina._precioCabina = float.Parse(reader["precio"].ToString());
                        cabina._estatus = reader["estatus"].ToString();
                        listaCabinas.Add(cabina);
                    }
                    reader.Close();
                    conexion.Close();
                }
               
            }
            catch (Exception e)
            {
                return null;
                // throw e;
            }
            return listaCabinas;
        }

        public Boolean insertarCamarote(CGestion_camarote camarote)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.AgregarCamarote, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@cantidad_camas", camarote._cantidadCama);
                    comando.Parameters.AddWithValue("@tipo_cama", camarote._tipoCama);
                    comando.Parameters.AddWithValue("@fk_id_cabina", camarote._fkCabina);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<CGestion_camarote> listarCamarotes(int idCabina)
        {
            List<CGestion_camarote> listaCamarote = new List<CGestion_camarote>();
            CGestion_camarote camarote;
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.ListarCamarote, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idCabina", idCabina);
                    conexion.Open();
                    //comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        camarote = new CGestion_camarote();
                        camarote._idCamarote = int.Parse(reader["id"].ToString());
                        camarote._cantidadCama = int.Parse(reader["cantidadCama"].ToString());
                        camarote._tipoCama = reader["tipoCama"].ToString();
                        camarote._estatus = reader["estatus"].ToString();
                        listaCamarote.Add(camarote);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaCamarote;
        }

        public Boolean cambiarEstadoItinerario(DateTime fechaInicio, int fkCrucero, int fkRuta)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.CambioEstatusItinerario, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("fecha_inicio", fechaInicio);
                    comando.Parameters.AddWithValue("fk_crucero", fkCrucero);
                    comando.Parameters.AddWithValue("fk_ruta", fkRuta);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean cambiarEstado(int id_crucero)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.CambioEstatusCrucero, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idCrucero", id_crucero);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public Boolean estatusCamarote(int id_camarote)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.CambioEstatusCamarote, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idCamarote", id_camarote);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CGestion_crucero consultarCruceroID(int id)
        {
            CGestion_crucero crucero = new CGestion_crucero();
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.ConsultarCruceroID, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        crucero._idCrucero = id;
                        crucero._nombreCrucero = reader["nombre"].ToString();
                        crucero._companiaCrucero = reader["compania"].ToString();
                        crucero._capacidadCrucero = int.Parse(reader["capacidad"].ToString());
                    }
                    reader.Close();
                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return crucero;
        }

        public Boolean modificarCruceros(CGestion_crucero crucero)
        {
            try
            {
                Conectar();
                using (comando = new SqlCommand(RecursosCruceros.ModificarCruceros, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idCrucero", crucero._idCrucero);
                    comando.Parameters.AddWithValue("@nombreCrucero", crucero._nombreCrucero);
                    comando.Parameters.AddWithValue("@compania", crucero._companiaCrucero);
                    comando.Parameters.AddWithValue("@capacidad", crucero._capacidadCrucero);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}