using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.M14;
using BOReserva.DataAccess.DataAccessObject.M09;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.DataAccess.DataAccessObject.M03;
using BOReserva.DataAccess.DataAccessObject.M11;
using BOReserva.DataAccess.DataAccessObject.M12;
using BOReserva.DataAccess.Model;
using BOReserva.M10;
using BOReserva.DataAccess.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace BOReserva.DataAccess.DataAccessObject

{
    /// <summary>
    /// Clase que fabrica los distintos DAO
    /// </summary>
    public class FabricaDAO
    {
        #region Lugar ( DAOLugar - DAOPais - DAOCiudad ) 

        public static DAO instanciarDaoLugar()
        {
            return new DAOLugar();
        }

        /// <summary>
        /// Metodo que instacia DAOPais
        /// </summary>
        /// <returns>Retorna DAOPais</returns>
        public static DAO instanciarDaoPais()
        {
            return new DAOPais();
        }

        /// <summary>
        /// Metodo que instacia DAOCiudad
        /// </summary>
        /// <returns>Retorna DAOCiudad</returns>
        public static DAO instanciarDaoCiudad()
        {
            return new DAOCiudad();
        }

        #endregion

        #region M01_Login
        /// <summary>
        /// Método para instanciar DAOLogin
        /// </summary>
        /// <returns>Objeto DAOLogin</returns>
        public static DAO instanciarDaoLogin()
        {
            return new DAOLogin();
        }
        #endregion

        #region M09_Gestion_Hoteles_Por_Ciudad

        /// <summary>
        /// Metodo que instacia DAOHotel
        /// </summary>
        /// <returns>Retorna DAOHotel</returns>
        public static DAO instanciarDaoHotel() {
            return new DAOHotel();
        }



        /// <summary>
        /// Metodo que instacia DAOHabitacion
        /// </summary>
        /// <returns>Retorna DAOHabitacion</returns>
        public static DAOHabitacion instanciarDaoHabitacion()

        {
            return new DAOHabitacion();
        }
        #endregion

        #region M16_Gestion_Reclamos
        public static DAO instanciarDaoReclamo() 
        {
            return new DAOReclamo();
        }

        public static IDAOReclamo instanciarDaoReclamoPersonalizado()
        {
            return new DAOReclamo();
        }
        #endregion

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

        # region M05_Boleto y checkIn

        public static DAO instanciarDaoPasajero()
        {
            return new DAOPasajero();
        }

        public static DAO instanciarDaoBoleto()
        {
            return new DAOBoleto();
		}

        public static DAO instanciarDaoCheckIn()
        {
            return new DAOChecking();
        }
        #endregion

        #region M08_Automoviles
        public static DAO CrearDaoAutomovil()
        {
            return new DAOAutomovil();
        }
        #endregion

        #region Modulo 10
        /// <summary>
        /// Inicializar IDAORestaurant
        /// </summary>
        /// <returns></returns>
        public static IDAORestaurant RestaurantBD()
        {
            return new DAORestaurant();

        }
        /// <summary>
        /// Valores de Horarios 
        /// </summary>
        /// <returns></returns>
        public static List<String> listarHorario()
        {
            return new List<String>
            { "07:00", "08:00", "09:00", "10:00", "11:00",
              "12:00", "13:00", "14:00", "15:00", "16:00",
              "17:00", "18:00", "19:00", "20:00", "21:00",
              "22:00", "23:00", "00:00"
            };
        }
       
     
        /// <summary>
        /// Metodo para asignar parametros para el store procedured
        /// </summary>
        /// <param name="nombreAtributo"></param>
        /// <param name="tipoDeDato"></param>
        /// <param name="valorAtributo"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, string valorAtributo, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, valorAtributo, output);
        }

        /// <summary>
        /// Metodo para asignar parametros para el store procedured
        /// </summary>
        /// <param name="nombreAtributo"></param>
        /// <param name="tipoDeDato"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, output);
        }

        /// <summary>
        /// Metodo para asignar parametros para el store procedured
        /// </summary>
        /// <returns></returns>
        public static List<Parametro> asignarListaDeParametro()
        {
            return new List<Parametro>();
        }
               
        #endregion

        #region M11_Gestion_Ofertas_Y_Paquetes
        /// <summary>
        /// Método que crea la instancia de DAOPaquete
        /// </summary>
        /// <returns>Retorna la instancia a la clase DAOPaquete</returns>
        public static DAOPaquete instanciarDaoPaquete()
        {
            return new DAOPaquete(); 
        }

        /// <summary>
        /// Método que crea la instancia de DAOOferta
        /// </summary>
        /// <returns>Retorna la instancia a la clase DAOOferta</returns>
        public static DAOOferta instanciarDaoOferta()
        {
            return new DAOOferta();
        }
        #endregion

        #region M13_Roles
        ///<summary>
        ///Instancia DAORol
        ///</summary>
        public static DAO instanciarDAORol()
        {
            return new DAORol();
        }
        ///<summary>
        ///Instancia DAOPermiso
        ///</summary>
        public static DAO instanciarDAOPermiso()
        {
            return new DAOPermiso();
        }
        #endregion

        #region M14_Cruceros
        public static DAO instanciarDaoCrucero()
        {
            return new DAOCruceros();
            
        }

        public static DAO instanciarDaoCabina()
        {
            return new DAOCabina();
        }

        public static DAO instanciarDaoCamarote()
        {
            return new DAOCamarotes();
        }

        public static DAO instanciarDaoItinerario()
        {
            return new DAOItinerario();
        }

        #endregion

        #region M06 GESTION DE COMIDA

        public static DAOComida instanciarComida()
        {
            return new DAOComida();
        }

        #endregion

        #region M02_Gestion_Avion

        public static DAO instanciarDaoAvion()
        {
            return new DAOAvion();
        }

        #endregion

        #region M03_Ruta
        /// <summary>
        /// Método que crea la instancia de DAORuta
        /// </summary>
        /// <returns>Retorna la instancia a la clase DAORuta</returns>
        public static DAO instanciarDAORuta()
        {
            return new DAORuta();
        }

        #endregion

        #region M12_Usuarios

        public static DAO instanciarDaoUsuario()
        {
            return new DAOUsuario();
    }
        
        #endregion

        #region M07_Gestion_ReclamosEquipaje

        /// <summary>
        /// Intancia Reclamo Equipaje
        /// </summary>
        /// <returns>DAO</returns>
        public static DAO instanciarDaoReclamoEquipaje()
        {
            return new DAOReclamoEquipaje();
        }

        public static IDAOReclamoEquipaje instanciarDaoReclamoEquipajePersonalizado()
        {
            return new DAOReclamoEquipaje();
        }

        #endregion

        #region M07_Gestion_Equipaje

        /// <summary>
        /// Intancia Equipaje
        /// </summary>
        /// <returns>DAO</returns>
        public static DAO instanciarDaoEquipaje()
        {
            return new DAOEquipaje();
        }

        public static IDAOEquipaje instanciarDaoEquipajePersonalizado()
        {
            return new DAOEquipaje();
        }
        #endregion
    }

}