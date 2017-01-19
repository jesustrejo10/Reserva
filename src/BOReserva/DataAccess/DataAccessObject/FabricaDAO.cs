using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.DataAccess.Model;
using BOReserva.M10;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject

{
    public class FabricaDAO
    {
        public static DAO instanciarDaoLogin()
        {
            return new DAOLogin();
        }

         #region M09_Gestion_Hoteles_Por_Ciudad
        
        public static DAO instanciarDaoHotel() {
            return new DAOHotel();
        }


        public static DAO instanciarDaoPais() {
            return new DAOPais();
        }

        public static DAO instanciarDaoCiudad()
        {
            return new DAOCiudad();
        }
        #endregion

        public static DAO instanciarDaoReclamo() 
        {
            return new DAOReclamo();
        }

        #region M04_Vuelos
        /// <summary>
        /// Método que crea la instancia de DAOVuelo
        /// </summary>
        /// <returns>Retorna la instancia a la clase DAOVuelo</returns>
        public static DAO instanciarDAOVuelo()
        {
            return new DAOVuelo();
        }
        #endregion

        # region M05_Boleto

        public static DAO instanciarDaoPasajero()
        {
            return new DAOPasajero();
        }

        public static DAO instanciarDaoBoleto()
        {
            return new DAOBoleto();
		}

        public static DAO instanciarDaoLugar()
        {
            return new DAOLugar();
        }
		#endregion
			
        #region Modulo 10
        public static IDAORestaurant RestaurantBD()
        {
            return new DAORestaurant();

        }

        public static List<String> listarHorario()
        {
            return new List<String>
            { "","07:00", "08:00", "09:00", "10:00", "11:00",
              "12:00", "13:00", "14:00", "15:00", "16:00",
              "17:00", "18:00", "19:00", "20:00", "21:00",
              "22:00", "23:00", "00:00"
            };
        }
       

        public static SqlConnection asignarConexionSql(String stringDeConexion)
        {
            return new SqlConnection(stringDeConexion);
        }

        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, string valorAtributo, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, valorAtributo, output);
        }

        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, output);
        }

        public static List<Parametro> asignarListaDeParametro()
        {
            return new List<Parametro>();
        }

        public static List<ResultadoBD> asignarListarColumnas()
        {
            return new List<ResultadoBD>();
        }

        public static SqlCommand asignarComandoSql(String query, SqlConnection conexion)
        {
            return new SqlCommand(query, conexion);
        }

        public static ResultadoBD asignarValorColumna(String atributo, String valorAtributo)
        {
            return new ResultadoBD(atributo, valorAtributo);
        }

        public static DataTable asignarTablaDeDatos()
        {
            return new DataTable();
        }

        public static SqlDataAdapter asignarAdaptadorDeDatos(SqlCommand comandoSql)
        {
            return new SqlDataAdapter(comandoSql);
        }
        #endregion

        #region M13_Roles
        public static DAO instanciarDAORol()
        {
            return new DAORol();
        }
        public static DAORol instanciarDAORolPermiso()
        {
            return new DAORol();
        }
        #endregion
    }
}