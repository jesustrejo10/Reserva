using BOReserva.DataAccess.DAO;
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
        public static DAO instanciarDaoHotel() {
            return new DAOHotel();
        }

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
        #endregion

        #region M08_Automoviles

        public static DAO CrearDaoAutomovil()
        {
            return new DAOAutomovil();
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
        #endregion

        public static SqlConnection asignarConexionSql(String stringDeConexion)
        {
            return new SqlConnection(stringDeConexion);
        }

        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, string valorAtributo, bool input, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, valorAtributo, input, output);
        }

        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, bool input, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, input, output);
        }

        public static List<Parametro> asignarListaDeParametro()
        {
            return new List<Parametro>();
        }

        public static List<Columna> asignarListarColumnas()
        {
            return new List<Columna>();
        }

        public static SqlCommand asignarComandoSql(String query, SqlConnection conexion)
        {
            return new SqlCommand(query, conexion);
        }

        public static Columna asignarValorColumna(String atributo, String valorAtributo)
        {
            return new Columna(atributo, valorAtributo);
        }

        public static DataTable asignarTablaDeDatos()
        {
            return new DataTable();
        }

        public static SqlDataAdapter asignarAdaptadorDeDatos(SqlCommand comandoSql)
        {
            return new SqlDataAdapter(comandoSql);
        }

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