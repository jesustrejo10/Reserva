using FOReserva.Datos.Dao.gestion_reserva_automovil;
using FOReserva.Datos.InterfazDao.gestion_reserva_automovil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.Datos.Fabrica
{
    public static class FabricaDatosSql
    {

        #region Modulo 19
        public static IReservaAutomovilDAO ReservaAutomovilBD()
        {
            return new ReservaAutomovilDAO();
        }
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