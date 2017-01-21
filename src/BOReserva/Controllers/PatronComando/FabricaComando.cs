using BOReserva.Controllers.PatronComando.M09;
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
        /// <param name="precio">Precio por habitacion/param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM09AgregarHotel(Entidad e, int precio) {

            return new M09_COAgregarHotel((Hotel)e, precio);

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
        /// <param name="id">Identificador del hotel a consultar</param>
        /// <returns>Retorna la instancia del comando M09_COConsultarHoteles.</returns>
        public static Command<Entidad> crearM09ConsultarHotel(int id)
        {

            return new M09_COConsultarHotel(id);

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COModificarHoteles
        /// </summary>
        /// <param name="hotel">Hotel a modificar</param>
        /// <param name="idmodificar">Identificador del hotel a modificar</param>
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
        /// <param name="hotel">Hotel a eliminar</param>
        /// <param name="ideliminar">Identificador del hotel a eliminar</param>
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
        /// <param name="hotel">Hotel a modificar disponibilidad</param>
        /// <param name="disponibilidad">Nuevo estado de disponibilidad</param>
        /// <returns>
        /// Retorna la instancia del comando M09_CODisponibilidadHotel.
        /// </returns>
        public static Command<String> crearM09DisponibilidadHotel(Entidad hotel, int disponibilidad)
        {

            return new M09_CODisponibilidadHotel(hotel, disponibilidad);

        }


        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COAgregarHabitaciones
        /// </summary>
        /// <param name="hotel">Hotel al cual se le añadiran las habitaciones</param>
        /// <param name="precio">Precio por habitacion</param>
        /// <returns>
        /// Retorna la instancia del comando M09_COAgregarHabitaciones.
        /// </returns>
        public static Command<int> crearM09AgregarHabitaciones(Entidad hotel, int precio)
        {

            return new M09_COAgregarHabitaciones((Hotel)hotel, precio);

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

        public static Command<Entidad> mostrarM05boleto(int id)
        {
            return new M05_COConsultarBoleto(id);
        }

        public static Command<int> mostrarM05idaVuelta(int id)
        {
            return new M05_COMostrarIdaVuelta(id);
        }

        public static Command<bool> verificarM05Boleto(int codigo_vuelo, String tipo)
        {
            return new M05_COVerificarDisponibilidadBoleto(codigo_vuelo, tipo);
        }

        public static Command<int> modificarM05modificarBoleto(Entidad e)
        {
            return new M05_COModificarBoleto((Boleto)e);
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
		
		public static Command<String> crearM16AgregarReclamo(Entidad e)
        {

            return new M16_COAgregarReclamo((Reclamo)e);

        }
        public static Command<Dictionary<int, Entidad>> crearM16VisualizarReclamos()
        {

            return new M16_COConsultarReclamo();

        }

        #region M06 GESTION COMIDA

        public enum comandosComida
        {
            CREAR_COMIDA,
            ELIMINAR_COMIDA,
            ACTUALIZAR_COMIDA,
            CONSULTAR_COMIDAS,
            CONSULTAR_COMIDAS_VUELOS
        }

        public static object gestionComida(comandosComida _comando, Entidad _objeto)
        {
            switch (_comando)
            {
                case comandosComida.CREAR_COMIDA:
                    return new M06_COAgregarComida(_objeto);
                case comandosComida.CONSULTAR_COMIDAS:
                    return new M06_COConsultarComidas();
                case comandosComida.CONSULTAR_COMIDAS_VUELOS:
                    return new M06_COConsultarComidasVuelos();
                default:
                    return new M06_COAgregarComida(_objeto);
            }
        }

        #endregion
    }

}