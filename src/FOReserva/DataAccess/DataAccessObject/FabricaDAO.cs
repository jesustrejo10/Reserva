using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.DataAccessObject.M19;
using FOReserva.DataAccess.DataAccessObject.M22;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject.M20;
using FOReserva.DataAccess.DataAccessObject.M14;
using FOReserva.DataAccess.DataAccessObject.M22Cruceros;

namespace FOReserva.DataAccess.DataAccessObject

{
    /// <summary>
    /// Clase encargada de instanciar los DAO respectivos para cada modulo
    /// </summary>
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

        public static IDAOReclamo reclamoPersonalizado()
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

        public static DAO instanciarDaoPais()
        {
            return new DAOPais();
        }

        public static DAO instanciarDaoCiudad()
        {
            return new DAOCiudad();
        }
        #endregion

        #region Modulo 20
        public static DAORevision CreateDAORevision()
        {
            return new DAORevision();
        }

        #endregion


        #region Modulo 22 ReservaCrucero
        public static DAO instanciarDaoReservaCrucero()
        {
            return new DAOReservaCrucero();
        }


        
        public static Parametro asignar(string nombreAtributo, SqlDbType tipoDeDato, string valorAtributo, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, valorAtributo, output);
        }

        
        #endregion


        #region M22_Gestion_Reserva_Habitacion
        /// <summary>
        /// Metodo que instancia el DAO de Reserva de Habitacion
        /// </summary>
        /// <returns>Una instancia del DAO de Reserva de Habitacion</returns>
        public static IDAOReservaHabitacion instanciarDaoReservaHabitacion()
        {
            return new DAOReservaHabitacion();
        }

        #endregion


        #region M14_RegistroUsuario



        public static DAORegistroU instanciarDaoUsuario()
        {
            return new DAORegistroU();
        }

        #endregion


    }
}