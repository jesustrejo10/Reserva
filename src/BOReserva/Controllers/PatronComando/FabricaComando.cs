using BOReserva.DataAccess.Domain;
using BOReserva.M10.Comando.gestion_restaurantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Fabrica de todos los comandos de la aplicacion.
    /// Esta clase es utilizada para instanciar a los comandos
    /// </summary>
    public class FabricaComando
    {
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COAgregarHotel
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Hotel</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM09AgregarHotel(Entidad e) {

            return new M09_COAgregarHotel((Hotel)e);

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COVisualizarHoteles
        /// <returns>Retorna la instancia del comando M09_COVisualizarHoteles.</returns>
        public static Command<Dictionary<int, Entidad>> crearM09VisualizarHoteles()
        {

            return new M09_COVisualizarHoteles();

        }

        public static Command<String> crearM16_AgregarReclamo(Entidad e) 
        {
            return new M16_COAgregarReclamo((Reclamo)e);
        }
        

        #region M04_Vuelo
        /// <summary>
        /// Método para instanciar el comando M04_COAgregarVuelo
        /// </summary>
        /// <param name="vuelo"></param>
        /// <returns>Instancia M04_COAgregarVuelo</returns>
        public static Command<String> CrearM04_AgregarVuelo(Entidad vuelo)
        {
            return new M04.M04_COAgregarVuelo();
        }

        /// <summary>
        /// Método para instanciar el comando M04_COConsultarTodos
        /// </summary>
        /// <returns>Instancia M04_COConsultarTodosVuelos</returns>
        public static Command<List<Entidad>> ConsultarM04_ConsultarTodos()
        {
            return new M04.M04_COConsultarTodosVuelos();
        }

        /// <summary>
        /// Metodo para instanciar el comando cambiar status del modulo de vuelos
        /// </summary>
        /// <param name="vuelo">id del vuelo al que se le cambiara el status</param>
        /// <returns>Instancia del M04_COCambiarStatus</returns>
        public static Command<Boolean> M04_CambiarStatus(int vuelo)
        {
            return new M04.M04_COCambiarStatus(vuelo);
        }

        /// <summary>
        /// Metodo para instanciar el comando M04_LugarOrigen
        /// </summary>
        /// <returns>Instancia del metodo M04_COLugarOrigen</returns>
        public static Command<List<Entidad>> ConsularM04_LugarOrigen()
        {
            return new M04.M04_COLugarOrigen();
        }

        #endregion

        public static Command<String> crearM13_AgregarRol(Entidad e)
        {

            return new M13_COAgregarRol((Rol)e);

        }

        public static Command<String> crearM13_AgregarRolPermiso(Entidad e)
        {

            return new M13_COAgregarRolPermiso((Rol)e);

        }
        #region M05_Boleto
        public static Command<String> crearM05AgregarPasajero(Entidad e)
        {
            return new M05_COAgregarPasajero((Pasajero)e);

        }

        public static Command<String> crearM05CrearBoleto(Entidad e)
        {
            return new M05_COCrearBoleto((Boleto)e);
        }
        #endregion

        #region Modulo 10 Gestion Restaurante

        #region Comandos Generales 
        /// <summary>
        /// Metodo que recibe un comando para Crear, Actualizar, Eliminar o Consultar
        /// la variable comando recibe comandosGlobales.CREAR, comandosGlobales.ELIMINAR
        /// comandosGlobales.ACTUALIZAR, comandosGlobales.CONSULTAR 
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>regresa un tipo Objecto que debe ser casteado segun sea el caso</returns>
        public static Object comandosRestaurant(comandosGlobales comando, comandoRestaurant comandoR, Entidad _objeto)
        {
            switch (comando)
            {
                case comandosGlobales.CREAR:
                    return new M10_COCrearRestaurant(_objeto);

                case comandosGlobales.ELIMINAR:
                    return new M10_COEliminarRestaurant(_objeto);

                case comandosGlobales.ACTUALIZAR:
                    return new comandoActualizarRestaurant(_objeto);

                case comandosGlobales.CONSULTAR:

                    switch (comandoR)
                    {
                        case comandoRestaurant.NULO:
                            break;
                        case comandoRestaurant.CONSULTAR_ID:
                            return new M10_COConsultarRestaurantId(_objeto);
                    }
                    return new M10_COConsultarRestaurant(_objeto);

                default:
                    return new M10_COConsultarRestaurant(_objeto);
            }
        }
        #endregion
        #region comandos de las interfaces Restaurant
        public static Object comandosVistaRestaurant(comandoVista comando)
        {
            switch (comando)
            {
                case comandoVista.CARGAR_LUGAR:
                    return new M10_COConsultarLugar();
                case comandoVista.CARGAR_HORA:
                    return new M10_COCargarHorario();
                default:
                    return new M10_COConsultarLugar();
            }

        }
        #endregion


        public enum comandoVista
        {
            CARGAR_LUGAR,
            CARGAR_HORA
        }

        public enum comandoRestaurant
        {
            NULO,
            CONSULTAR_ID
        }

        public enum comandosGlobales
        {
            CREAR,
            ELIMINAR,
            ACTUALIZAR,
            CONSULTAR
        }

        public static List<Lugar> listaLugares(Lugar lugar)
        {
            List<Lugar> lista = new List<Lugar>();
            lista.Add(lugar);
            return lista;
        }
        #endregion

    }
}