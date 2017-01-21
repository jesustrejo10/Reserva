using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers.PatronComando.M03;
using BOReserva.Controllers.PatronComando.M09;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M03;
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

        public static Command<String> crearM16_AgregarReclamo(Entidad e) 
        {
            return new M16_COAgregarReclamo((Reclamo)e);
        }
        

        #region M04_Vuelo
        public static Command<String> crearVuelo(Entidad vuelo)
        {
            return new M04.M04_COAgregarVuelo();
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

        #region M03_Ruta
        public static Command<String> crearM03_AgregarRuta(Entidad e)
        {

            return new M03_COAgregarRuta((Ruta)e);

        }
        public static Command<Dictionary<int, Entidad>> crearM03_ConsultarDestinos(String origen)
        {

            return new M03_COConsultarDestinos(origen);

        }
        public static Command<Boolean> crearM03_DeshabilitarRuta(int id)
        {

            return new M03_CODeshabilitarRuta(id);

        }
        public static Command<Boolean> crearM03_HabilitarRuta(int id)
        {

            return new M03_COHabilitarRuta(id);

        }
        public static Command<Dictionary<int, Entidad>> crearM03_ListarLugares()
        {

            return new M03_COListarLugares();

        }
        public static Command<Boolean> crearM03_ModificarRuta(Entidad e, int id)
        {

            return new M03_COModificarRuta((Ruta)e,id);

        }
        public static Command<Entidad> crearM03_MostrarRuta(Entidad e, int id)
        {

            return new M03_COMostrarRuta((Ruta)e,id);

        }

        public static Command<Boolean> crearM03_ValidarRuta(Entidad e,int id)
        {

            return new M03_COValidarRuta((Ruta)e, id);

        }

        #endregion

    }
}