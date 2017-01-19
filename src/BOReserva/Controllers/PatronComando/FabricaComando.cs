using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers.PatronComando.M09;
using BOReserva.Controllers.PatronComando.M12;
using BOReserva.DataAccess.Domain;
using BOReserva.M10.Comando.gestion_restaurantes;
using BOReserva.Controllers.PatronComando;
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
        #region M09_Gestion_Hoteles_Por_Ciudad

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
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COVisualizarHoteles.
        /// </returns>
        public static Command<Dictionary<int, Entidad>> crearM09VisualizarHoteles()
        {

            return new M09_COVisualizarHoteles();

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COConsultarHoteles
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COConsultarHoteles.
        /// </returns>
        public static Command<Entidad> crearM09ConsultarHotel(int id)
        {

            return new M09_COConsultarHotel(id);

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COModificarHoteles
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COModificarHoteles.
        /// </returns>
        public static Command<String> crearM09ModificarHotel(Entidad hotel, int idmodificar)
        {

            return new M09_COModificarHotel(hotel, idmodificar);

        }


        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COEliminarHoteles
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COEliminarHoteles.
        /// </returns>
        public static Command<String> crearM09EliminarHotel(Entidad hotel, int ideliminar)
        {

            return new M09_COEliminarHotel(hotel, ideliminar);

        }


        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_CODisponibilidadHotel
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_CODisponibilidadHotel.
        /// </returns>
        public static Command<String> crearM09DisponibilidadHotel(Entidad hotel, int disponibilidad)
        {

            return new M09_CODisponibilidadHotel(hotel, disponibilidad);

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COObtenerPaises
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COObtenerPaises.
        /// </returns>
        public static Command<Dictionary<int, Entidad>> crearM09ObtenerPaises()
        {
            return new M09_COObtenerPaises();
        }


        #endregion

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando M16_COAgregarReclamo
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo reclamo</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
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
        public static Command<String> crearM04_AgregarVuelo(Entidad vuelo)
        {
            return new M04.M04_COAgregarVuelo();
        }

        /// <summary>
        /// Método para instanciar el comando M04_COConsultarTodos
        /// </summary>
        /// <param name="vuelo"></param>
        /// <returns>Instancia M04_COConsultarTodosVuelos</returns>
        public static Command<List<Entidad>> consultarM04_ConsultarTodos()
        {
            return new M04.M04_COConsultarTodosVuelos();
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

        public static Command<String> crearM05EliminarBoleto(int id)
        {
            return new M05_COEliminarBoleto(id);
        }

        public static Command<String> buscarM05nombreCiudad(Entidad e)
        {
            return new M05_COBuscarnombreciudad(e);
        }

        public static Command<String> modificarM05modificarPasajero(Entidad e)
        {
            return new M05_COModificarPasajero((Pasajero)e);
        }

        #endregion

        #region M08_Automoviles

        public static Command<String> activarAutomovil(Entidad e)
        {
            return new M08.M08_COActivarAutomovil(e);
        }

        public static Command<String> agregarAutomovil(Entidad e)
        {
            return new M08.M08_COAgregarAutomovil(e);
        }

        public static Command<String> buscarAutomovil(Entidad e)
        {
            return new M08.M08_COBuscarAutomovil(e);
        }

        public static Command<String> desactivarAutomovil(Entidad e)
        {
            return new M08.M08_CODesactivarAutomovil(e);
        }

        public static Command<String> listarAutomovil(Entidad e)
        {
            return new M08.M08_COListarAutomovil(e);
        }

        public static Command<String> modificarAutomovil(Entidad e)
        {
            return new M08.M08_COModificarAutomovil(e);
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
                    return new M10_COActualizarRestaurant(_objeto);

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
        /// <summary>
        /// Devuelve los objetos para inicializar los combobox de la vista restaurant
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
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

        #region M12_Gestion_Usuarios

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M12_COAgregarUsuario
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Usuario</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM12AgregarUsuario (Entidad e)
        {
            return new M12_COAgregarUsuario((Usuario)e);
        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M12_COObtenerRoles
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M12_COObtenerRoles.
        /// </returns>
        public static Command<Dictionary<int, Entidad>> crearM12ObtenerRoles()
        {
            return new M12_COObtenerRoles();
        }

        #endregion

    }
}