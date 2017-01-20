using FOReserva.DataAccess;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.DataAccessObject.M19;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject

{
    public class FabricaDAO
    {
        #region M16 Reclamos

        /// <summary>
        /// Metodo que instancia el DAO de reclamos
        /// </summary>
        /// <returns>una instancia del DAO de reclamos</returns>
        public static DAO instanciarDaoReclamo()
        {
            return new DAOReclamo();
        }
        #endregion

        #region Modulo 19
        public static IDAOReservaAutomovil ReservaAutomovilBD()
        {
            return new DAOReservaAutomovil();
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
    }
}