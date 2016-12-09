using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
    }
}