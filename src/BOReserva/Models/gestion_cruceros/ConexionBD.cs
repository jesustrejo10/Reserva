using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_cruceros
{
    public class ConexionBD
    {
        #region Atributos
        private SqlConnection conexion;
        private string strConexion;
        private SqlCommand comando;
        private string query;
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
                strConexion = ConfigurationManager.ConnectionStrings["DB_A1380A_reserva"].ConnectionString;
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

        public List<CGestion_crucero> listarCruceros()
        {
            List<CGestion_crucero> listaCruceros = new List<CGestion_crucero>();
            CGestion_crucero crucero;
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
            return listaCruceros;
        }

        public void insertarCruceros(CGestion_crucero crucero)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.AgregarCruceros, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombrecrucero", crucero._nombreCrucero);
                comando.Parameters.AddWithValue("@compania", crucero._companiaCrucero);
                comando.Parameters.AddWithValue("@capacidad", crucero._capacidadCrucero);
                comando.Parameters.AddWithValue("@imagen", "url");


                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void eliminarCrucero(int id_crucero)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.EliminarCruceros, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id_crucero);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void estatusCabina(int id_cabina)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.CambioEstatusCabinas, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idCabina", id_cabina);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


        public void insertarCabinas(CGestion_cabina cabina)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.AgregarCabinas, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombrecabina", cabina._nombreCabina);
                comando.Parameters.AddWithValue("@precio", cabina._precioCabina);
                comando.Parameters.AddWithValue("@fk_id_crucero", cabina._fkCrucero);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public List<CGestion_cabina> listarCabinas(int idCrucero)
        {
            List<CGestion_cabina> listaCabinas = new List<CGestion_cabina>();
            CGestion_cabina cabina;
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
            }
            return listaCabinas;
        }

        public void insertarCamarote(CGestion_camarote camarote)
        {
            Conectar();
                using (comando = new SqlCommand(RecursosCruceros.AgregarCamarote, conexion)) ;
            
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@cantidad_camas", camarote._cantidadCama);
                    comando.Parameters.AddWithValue("@tipo_cama", camarote._tipoCama);
                    comando.Parameters.AddWithValue("@fk_id_cabina", camarote._fkCabina);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                    
                }
               
        

        public List<CGestion_camarote> listarCamarotes(int idCabina)
        {
            List<CGestion_camarote> listaCamarote = new List<CGestion_camarote>();
            CGestion_camarote camarote;
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
                    camarote._tipoCama= reader["tipoCama"].ToString();
                    camarote._estatus= reader["estatus"].ToString();
                    listaCamarote.Add(camarote);
                }
                reader.Close();
            }
            return listaCamarote;
        }

        public void cambiarEstado(int id_crucero)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.CambioEstatusCrucero, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idCrucero", id_crucero);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void estatusCamarote(int id_camarote)
        {
            Conectar();
            using (comando = new SqlCommand(RecursosCruceros.CambioEstatusCamarote, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idCamarote", id_camarote);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

    }


}