using BOReserva.Datos.Dao.gestion_restaurantes;
using BOReserva.Datos.InterfazDao.gestion_restaurantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Datos.Fabrica
{
    public static class FabricaDatosSql
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10
        public static IRestaurantDAO RestaurantBD()
        {
            return new RestaurantDAO();

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

        #region Modulo 11
        #endregion

        #region Modulo 12
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        #endregion

        #region Global

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

        #endregion
    }
}