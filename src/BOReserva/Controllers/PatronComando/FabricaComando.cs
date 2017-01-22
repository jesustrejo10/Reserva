using BOReserva.Controllers.PatronComando.M09;
using BOReserva.Controllers.PatronComando.M02;
using BOReserva.DataAccess.Domain;
using BOReserva.M10.Comando.gestion_restaurantes;
using BOReserva.Models.gestion_automoviles;
using System;
using System.Collections.Generic;
using BOReserva.Controllers.PatronComando;
using System.Web;
using System.Linq;
using BOReserva.Controllers.PatronComando.M10;
using BOReserva.Controllers.PatronComando.M16;
using BOReserva.DataAccess.Domain.M14;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Fabrica de todos los comandos de la aplicacion.
    /// Esta clase es utilizada para instanciar a los comandos
    /// </summary>
    public class FabricaComando
    {
        #region M02_Gestion_Avion
        #region crearM02AgregarAvion
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COAgregarHotel
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Hotel</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM02AgregarAvion(Entidad e)
        {

            return new M02_COAgregarAvion((Avion)e);

        }

        #endregion
        #region crearM02VisualizarAvion
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COVisualizarHoteles
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COVisualizarHoteles.
        /// </returns>
        public static Command<Dictionary<int, Entidad>> crearM02VisualizarAviones()
        {

            return new M02_COVisualizarAvion();

        }

        #endregion
        #region crearM02ConsultarAvion
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COConsultarHoteles
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_COConsultarHoteles.
        /// </returns>
        public static Command<Entidad> crearM02ConsultarAvion(int id)
        {

            return new M02_COConsultarAvion(id);

        }

        #endregion
        #region crearM02ModificarAvion
        public static Command<string> crearM02ModificarAvion(Entidad avion, int idmodificar)
        {

            return new M02_COModificarAvion(avion, idmodificar);

        }
        #endregion
        #region crearM02EliminarAvion
        public static Command<string> crearM02EliminarAvion(Entidad avion,int ideliminar)
        {
            return new M02_COEliminarAvion(avion,ideliminar);
        }
        #endregion
        #region crearM02DisponibilidadAvion
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_CODisponibilidadHotel
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M09_CODisponibilidadHotel.
        /// </returns>
        public static Command<String> crearM02DisponibilidadAvion(Entidad avion, int disponibilidad)
        {

            return new M02_CODisponibilidadAvion(avion, disponibilidad);

        }
        #endregion
        #endregion


        # region Lugar ( COLugar - COPais - COCiudad ) 

        public static Command<Dictionary<int, Entidad>> consultarTodosPais(Entidad e)
        {
            return new GeneralLugar.COConsultarTodosPais(e);
        }

        public static Command<Dictionary<int, Entidad>> consultarTodosCiudad(Entidad e)
        {
            return new GeneralLugar.COConsultarTodosCiudad(e);
        }

        #endregion

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

        #region M16_GESTION_RECLAMOS
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando M16_COAgregarReclamo
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo reclamo</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM16_AgregarReclamo(Entidad e) 
        {
            return new M16_COAgregarReclamo((Reclamo)e);
        }
        public static Command<String> crearM16AgregarReclamo(Entidad e)
        {

            return new M16_COAgregarReclamo((Reclamo)e);

        }
        public static Command<Dictionary<int, Entidad>> crearM16VisualizarReclamos()
        {

            return new M16_COConsultarReclamo();

        }
        public static Command<Entidad> crearM16ConsultarUsuario(int idReclamo)
        {

            return new M16_COConsultarReclamoDetalle(idReclamo);

        }

        public static Command<String> crearM16EliminarReclamo(int id)
        {
            return new M16_COEliminarReclamo(id); 

        }

        public static Command<String> crearM16ActualizarReclamo(int id, int estado)
        {
            return new M16_COActualizarReclamo(id, estado);

        }

        #endregion

        #region M14_Gestion_Cruceros

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M14_COAgregarCrucero
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Crucero</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM14AgregarCrucero(Entidad e)
        {

            return new M14_COAgregarCrucero((Crucero) e);
            

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M14_COAgregarCrucero
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Crucero</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM14AgregarCabina(Entidad e)
        {

            return new M14_COAgregarCabina((Cabina) e);
            
        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M14_COVisualizarCruceros
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M14_COVisualizarCruceros.
        /// </returns>
        public static Command<Dictionary<int, Entidad>> crearM14VisualizarCruceros()
        {

            return new M14_COVisualizarCruceros();

        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M14_COVisualizarItinerario
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M14_COVisualizarItinerario.
        /// </returns>       
        public static Command<Dictionary<int, Entidad>> crearM14Visualizaritinerario()
        {

            return new M14_COVisualizarItinerario();
        }


        public static Command<Dictionary<int, Entidad>> crearM14VisualizarCabinasCrucero(string crucero)
        {

            return new M14_COListarCabinaCrucero(crucero);
        }

        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M14_COVisualizarCabinas
        /// </summary>
        /// <returns>
        /// Retorna la instancia del comando M14_COVisualizarCabinas.
        /// </returns>
        public static Command<Dictionary<int, Entidad>> crearM14VisualizarCabinas(int id)
        {

            return new M14_COVisualizarCabinas(id);

        }

        #endregion

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

        /// <summary>
        /// Metodo para instanciar el comando M04_LugarOrigen
        /// </summary>
        /// <param name="ciudadO">id de la ciudad origen</param>
        /// <returns>lista con las ciudades destino</returns>
        public static Command<List<Entidad>> ConsultarM04_LugarDestino(int ciudadO)
        {
            return new M04.M04_COLugarDestino(ciudadO);
        }

        /// <summary>
        /// Metodo para instanciar el comando M04_LugarOrigen
        /// </summary>
        /// <param name="idRuta">id de la ruta</param>
        /// <returns>lista con los aviones disponibles para la ruta seleccionada</returns>
        public static Command<List<Entidad>> ConsultarM04_BuscarAvionRuta(int idRuta)
        {
            return new M04.M04_COBuscarAvionRuta(idRuta);
        }

        #endregion

        #region M13_Roles

        public static Command<String> crearM13_AgregarRol(Entidad e)
        {
            return new M13_COAgregarRol((Rol)e);
        }


        public static Command<String> crearM13_AgregarRolPermiso(Entidad e)
        {
            return new M13_COAgregarRolPermiso((Rol)e);
        }

        public static Command<List<Entidad>> crearM13_ConsultarRoles()
        {
            return new M13_COConsultarRoles();
        }

        public static Command<List<Entidad>> crearM13_ConsultarPermisos(int id)
        {
            return new M13_COConsultarPermisos(id);
        }

        public static Command<Entidad> crearM13_ConsultarModulos(int id)

        {
            return new M13_COConsultarModulos(id);
        }

        public static Command<List<Entidad>> crearM13_ListarPermisos()
        {
          return new M13_COListarPermisos();
        }

        public static Command<Entidad> crearM13_ConsultarRol(int id)
        {
            return new M13_COConsultarRol(id);
        }

        public static Command<String> crearM13_EliminarRol(Entidad rol, int id)
        {
            return new M13_COEliminarRol(rol, id);
        }

        public static Command<List<Entidad>> crearM13_ConsultarPermiso(int id)
        {
            return new M13_COConsultarPermiso(id);
        }

        public static Command<String> crearM13_EliminarPermisos(int id)

        {
            return new M13_COEliminarPermisos(id);
        }

        public static Command<List<Entidad>> crearM13_ConsultarPermisosAsignados(Entidad rol, int id)
        {
            return new M13_COConsultarPermisosAsociados(rol, id);
        }

        public static Command<String> crearM13_ModificarRol(Entidad rol, int idmodificar)
        {
         return new M13_COModificarRol(rol, idmodificar);
        }

        public static Command<List<String>> crearM13_ConsultarPermisosUsuario (int id)
        {
            return new M13_COConsultarPermisosUsuario(id);
        }

        #endregion

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

        public static Command<List<Entidad>> ConsultarBoletos()
        {
            return new M05_COConsultarBoletos();
        }
        public static Command<List<Entidad>> ConsultarBoletos(int id)
        {
            return new M05_COConsultarBoletos( id );
        }

        public static Command<List<Entidad>> ConsultarBoletosPasajero(int id)
        {
            return new M05_COConsultarBoletosPasajero(id);
        }

        public static Command<Entidad> consultarM05BoletopasajeroBD(int id)
        {
            return new M05_COConsultarBoletoBD(id);
        }

        public static Command<List<Entidad>> ConsultarPasajeros(int id)
        {
            return new M05_COConsultarBoletosPasajero(id);
        }

        public static Command<List<Entidad>> consultarM05listaVuelos(int id)
        {
            return new M05_COConsultarBoletosVuelo(id);
        }

        public static Command<List<Entidad>> consultarM05listaVuelosBD(string fechaida, string fechavuelta, int idorigen, int iddestino, string tipo)
        {
            return new M05_COConsultarListaVuelo(fechaida, fechavuelta, idorigen, iddestino, tipo);
        }


        #endregion

        #region M08_Automoviles

        public static Command<bool> activarAutomovil(Entidad e)
        {
            return new M08.M08_COActivarAutomovil(e);
        }

        public static Command<bool> agregarAutomovil(Entidad e)
        {
            return new M08.M08_COAgregarAutomovil(e);
        }

        public static Command<Entidad> buscarAutomovil(Entidad e)
        {
            return new M08.M08_COBuscarAutomovil(e);
        }

        public static Command<List<Entidad>> listarAutomovil(Entidad e)
        {
            return new M08.M08_COListarAutomovil(e);
        }

        public static Command<bool> modificarAutomovil(Entidad e)
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
        /// <param name="comandoR"></param>
        /// <param name="_objeto"></param>
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
                        case comandoRestaurant.LISTAR_RESTAURANT:
                            return new M10_COListarRestaurantId();
                    }
                    return new M10_COConsultarRestaurant(_objeto);

                default:
                    return null;
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

        /// <summary>
        /// Comandos para cargar hora y lugar ciudades
        /// </summary>
        public enum comandoVista
        {
            CARGAR_LUGAR,
            CARGAR_HORA
        }

        /// <summary>
        /// Comando para consultas adicionales de restaurante
        /// </summary>
        public enum comandoRestaurant
        {
            NULO,
            CONSULTAR_ID,
            LISTAR_RESTAURANT
        }

        /// <summary>
        /// Comandos globales para hacer CRUD
        /// </summary>
        public enum comandosGlobales
        {
            CREAR,
            ELIMINAR,
            ACTUALIZAR,
            CONSULTAR
        }

        /// <summary>
        /// Metodo para listar los lugares (Ciudades)
        /// </summary>
        /// <param name="lugar"></param>
        /// <returns></returns>
        public static List<Lugar> listaLugares(Lugar lugar)
        {
            List<Lugar> lista = new List<Lugar>();
            lista.Add(lugar);
            return lista;
        }
        #endregion

        #region M06 GESTION COMIDA

        public enum comandosComida
        {
            CREAR_COMIDA,
            CREAR_COMIDA_VUELO,
            ELIMINAR_COMIDA,
            ACTUALIZAR_COMIDA,
            CONSULTAR_COMIDAS,
            CONSULTAR_COMIDAS_VUELOS,
            CONSULTAR_VUELOS,
            DESHABILITAR_COMIDA,
            HABILITAR_COMIDA,
            RELLENAR_COMIDA,
            EDITAR_COMIDA
        }


        public static object gestionComida(comandosComida _comando, Entidad _objeto)
        {
            switch (_comando)
            {
                case comandosComida.CREAR_COMIDA:
                    return new M06_COAgregarComida(_objeto);

                case comandosComida.CREAR_COMIDA_VUELO:
                    return new M06_COAgregarComidaVuelo(_objeto);

                case comandosComida.CONSULTAR_COMIDAS:
                    return new M06_COConsultarComidas();

                case comandosComida.CONSULTAR_COMIDAS_VUELOS:
                    return new M06_COConsultarComidasVuelos();
                case comandosComida.CONSULTAR_VUELOS:
                    return new M06_COConsultarVuelos();

                case comandosComida.DESHABILITAR_COMIDA:
                    return new M06_COCambiarEstatusComida(_objeto, 0);

                case comandosComida.HABILITAR_COMIDA:
                    return new M06_COCambiarEstatusComida(_objeto, 1);

                case comandosComida.RELLENAR_COMIDA:
                    return new M06_CORellenarComida(_objeto);

                case comandosComida.EDITAR_COMIDA:
                    return new M06_COEditarComida(_objeto);

                default:
                    return new M06_COAgregarComida(_objeto);
            }

        }
        #endregion
    }
        
}