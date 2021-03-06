﻿using BOReserva.Models;
using BOReserva.Models.gestion_cruceros;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_reclamos;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Models.gestion_roles;
using BOReserva.DataAccess.Domain;
using BOReserva.Models.gestion_aviones;
using BOReserva.Models.gestion_usuarios;
using BOReserva.Models.gestion_ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_reclamo_equipaje;
using BOReserva.DataAccess.Domain.M14;
        

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada con la finalidad de instanciar a cualquier objeto dentro del Dominio
    /// </summary>D:\UCAB\Desarrollo\Reserva\src\BOReserva\DataAccess\Domain\FabricaEntidad.cs
    public class FabricaEntidad
    {
        #region M01_Login 
        public static Usuario crearUsuario()
        {
            return new Usuario();
        }

        public static Usuario crearUsuario(String _correo)
        {
            return new Usuario()
            {
                correo = _correo
            };
        }

        public static Usuario crearUsuario(String _correo, String _clave)
        {
            return new Usuario()
            {
                correo = _correo,
                contrasena = _clave
            };
        }

        public static Usuario crearUsuario(int _id, int _rol, String _nombre, String _apellido, String _correo, String _clave, String _fechaCreacion, String _activo)
        {
            return new Usuario()
            {
                id = _id,
                rol = _rol,
                nombre = _nombre,
                apellido = _apellido,
                correo = _correo,
                contrasena = _clave,
                fechaCreacion = _fechaCreacion,
                activo = _activo
            };
        }
        #endregion

        #region M09_Gestion_Hoteles_Por_Ciudad
        /// <summary>
        /// Clase que retorna la instacia de un hotel
        /// </summary>
        /// <param name="nombre">Nombre del hotel</param>
        /// <param name="direccion">Direccion del hotel</param>
        /// <param name="fkCiudad">Ciudad donde esta el hotel</param>
        /// <param name="clasificacion">Clasificacion del hotel</param>
        /// <param name="webPage">Pagina web del hotel</param>
        /// <param name="email">Email del hotel</param>
        /// <param name="capacidad">Capacidad del hotel</param>
        /// <returns>Retorna una entidad</returns>
        public static Entidad InstanciarHotel(String nombre, String direccion, int fkCiudad, int clasificacion, String webPage, String email, int capacidad)
        {

            return new Hotel();
        }

        /// <summary>
        /// Clase que instacia un hotel
        /// </summary>
        /// <param name="model">Modelo proveniente de la vista M09_AgregarHotel</param>
        /// <param name="c">Ciudad donde esta el hotel</param>
        /// <returns></returns>
        public static Entidad InstanciarHotel(CAgregarHotel model, Entidad c)
        {
            Ciudad city = (Ciudad)c;

            String nombre = model._nombre;
            String direccion = model._direccion;
            int clasificacion = model._clasificacion;
            int capacidad = model._capacidadHabitacion;
            String paginaWeb = model._paginaWeb;
            String email = model._email;
            int precio = model._precioHabitacion;
            return new Hotel(nombre, direccion, email, paginaWeb, clasificacion, capacidad, city, precio);
        }

        /// <summary>
        /// Clase que instacia un hotel
        /// </summary>
        /// <param name="model">Modelo proveniente de la vista M09_ModificarHotel</param>
        /// <param name="c">Ciudad donde esta el hotel</param>
        /// <returns></returns>
        public static Entidad InstanciarHotel(CModificarHotel model, Entidad c)
        {
            Ciudad city = (Ciudad)c;

            String nombre = model._nombre;
            String direccion = model._direccion;
            int clasificacion = model._clasificacion;
            int capacidad = model._capacidadHabitacion;
            String paginaWeb = model._paginaWeb;
            String email = model._email;
            int precio = model._precioHabitacion;
            return new Hotel(nombre, direccion, email, paginaWeb, clasificacion, capacidad, city, precio);
        }

        /// <summary>
        /// Clase que instacia un hotel
        /// </summary>
        /// <param name="model">Modelo proveniente de la vista M09_ModificarHotel</param>
        /// <param name="c">Ciudad donde esta el hotel</param>
        /// <returns></returns>
        public static Entidad InstanciarHotel(CModificarHotel model)
        {
            String nombre = model._nombre;
            String direccion = model._direccion;
            int clasificacion = model._clasificacion;
            int capacidad = model._capacidadHabitacion;
            String paginaWeb = model._paginaWeb;
            String email = model._email;
            int precio = model._precioHabitacion;
            return new Hotel(nombre, direccion, email, paginaWeb, clasificacion, capacidad, null, precio);
        }

        /// <summary>
        /// Clase que instancia un pais
        /// </summary>
        /// <param name="nombre">Nombre del pais</param>
        /// <returns></returns>
        public static Entidad InstanciarPais(String nombre)
        {
            return new Pais();
        }

        /// <summary>
        /// Clase que instancia un pais
        /// </summary>
        /// <param name="id">Id del pais</param>
        /// <param name="nombre">Nombre del pais</param>
        /// <returns></returns>
        public static Entidad InstanciarPais(int id, String nombre)
        {
            return new Pais(id, nombre);
        }

        /// <summary>
        /// Clase que instancia una ciudad
        /// </summary>
        /// <param name="ciudad">Nombre de la ciudad</param>
        /// <returns></returns>
        public static Entidad InstanciarCiudad(String ciudad)
        {
            return new Ciudad();
        }

        /// <summary>
        /// Clase que instancia una ciudad
        /// </summary>
        /// <param name="id">Id de la ciudad</param>
        /// <param name="nombre">Nombre de la ciudad</param>
        /// <param name="fkPais">Pais al cual pertenece</param>
        /// <returns></returns>
        public static Entidad InstanciarCiudad(int id, String nombre, int fkPais)
        {
            return new Ciudad(id, nombre, fkPais);
        }

        /// <summary>
        /// Clase que instancia una habitacion
        /// </summary>
        /// <param name="precio">Precio de la habitacion</param>
        /// <param name="fkHotel">Hotel al cual pertenece</param>
        /// <returns></returns>
        public static Entidad InstanciarHabitacion(int precio, int fkHotel)
        {
            return new Habitacion(precio, fkHotel);
        }

        #endregion 

        #region M16_GestionReclamos

        public static Entidad InstanciarReclamo()
        {
            return new Reclamo();
        }
        public static Entidad InstanciarReclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int usuario)
        {
            return new Reclamo(tituloReclamo, detalleReclamo, fechaReclamo, estadoReclamo, usuario);
        }
        public static Entidad InstanciarReclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo)
        {
            return new Reclamo(tituloReclamo, detalleReclamo, fechaReclamo, estadoReclamo);
        }

        public static Entidad InstanciarReclamo(int reclamo, String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int usuario)
        {
            return new Reclamo(reclamo, tituloReclamo, detalleReclamo, fechaReclamo, estadoReclamo, usuario);
        }
        public static Entidad InstanciarReclamo(CAgregarReclamo model)
        {
            String titulo = model._tituloReclamo;
            String detalle = model._detalleReclamo;
            String fecha = model._fechaReclamo;
            int estado = model._estadoReclamo;
            int usuario = model._usuario;

            return new Reclamo(titulo, detalle, fecha, estado, usuario);
        }

        public static Entidad InstanciarReclamo(CModificarReclamo model)
        {
            int id = model._idReclamo;
            String titulo = model._tituloReclamo;
            String detalle = model._detalleReclamo;
            String fecha = model._fechaReclamo;
            int estado = model._estadoReclamo;
            Reclamo r = new Reclamo(id, titulo, detalle, fecha, estado);
            return r;
        }
        public static List<Reclamo> InstanciarListaReclamo(Dictionary<int, Entidad> listaEntidad) 
        {
            List<Reclamo> lista = new List<Reclamo>();
            foreach (var e in listaEntidad)
            {
                Reclamo nuevoReclamo = (Reclamo)e.Value;
                lista.Add(nuevoReclamo);

            }
            return lista;
        }

        /// <summary>
        /// Instanciacion para una lista vacia
        /// </summary>
        /// <returns>Lista de reclamos vacia</returns>
        public static List<Reclamo> InstanciarListaReclamo()
        {
            return new List<Reclamo>();
        }
#endregion

        #region M04_Vuelo
        /// <summary>
        /// Se crea una instancia de la clase Vuelo con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigoVuelo"></param>
        /// <param name="ruta"></param>
        /// <param name="fechaDespegue"></param>
        /// <param name="status"></param>
        /// <param name="fechaAterrizaje"></param>
        /// <param name="avion"></param>
        /// <returns>Retorna una instancia de la clase vuelo con todos sus atributos</returns>
        public static Entidad InstanciarVuelo(int id, String codigoVuelo, Ruta ruta, DateTime fechaDespegue,
                                          String status, DateTime fechaAterrizaje, Avion avion)
        {
            return new Vuelo(id, codigoVuelo, ruta, fechaDespegue, status, fechaAterrizaje,
                             avion);
        }


        /// <summary>
        /// Instanciar vuelo sin ningun parametro
        /// </summary>
        /// <returns>Entidad vuelo vacia</returns>
        public static Entidad InstanciarVuelo()
        {
            return new Vuelo();
        }

        /// <summary>
        /// Instancia vuelo fecha de aterrizaje y avion
        /// </summary>
        /// <param name="fechaAterrizaje">fecha de Aterrizaje</param>
        /// <param name="avion">clase avion</param>
        /// <returns>Entidad Vuelo</returns>
        public static Entidad InstanciarVuelo(DateTime fechaAterrizaje, Avion avion)
        {
            return new Vuelo(fechaAterrizaje, avion);
        }

        public static Entidad InstanciarCiudad(int id, String ciudadO)
        {
            return new Ciudad(id, ciudadO);
        }
        #endregion

        #region M05_Boleto_y_checkin

        public static Entidad InstanciarBoleto(int idorigen, int iddestino, int pasaporte, int monto, string tipo, int idvuelo, string fecha)
        {
            return new Boleto(idorigen, iddestino, pasaporte, monto, tipo, idvuelo, fecha);
        }

        public static Entidad InstanciarDetalleBoleto(Entidad boleto)
        {
            return new BoletoDetalle((Boleto)boleto);
        }

        public static Entidad InstanciarPasajero(int id, String nombre1, String nombre2, String apellido1, String apellido2, String sexo,
         string fecha, String correo)
        {
            DateTime fecha_nac = Convert.ToDateTime(fecha);
            return new Pasajero(id, nombre1, nombre2, apellido1, apellido2, sexo, fecha_nac, correo);
		}

        public static Entidad InstanciarBoardingPass(int vuelo, DateTime fechaPartida, DateTime fechaLlegada, String horaPartida, int origen, int destino,
            String nombreOri, String nombreDest, int boleto, String asiento, String nombre, String apellido)
        {
            return new BoardingPass(vuelo, fechaPartida, fechaLlegada, horaPartida, origen, destino,
              nombreOri, nombreDest, boleto, asiento, nombre, apellido);
        }
        #endregion

        #region M08_Automoviles

        public static Entidad CrearAutomovil(String matricula, String modelo, String fabricante, String anio, String tipovehiculo,
                                                  String kilometraje, String cantpasajeros, String preciocompra, String precioalquiler,
                                                  String penalidaddiaria, String fecharegistro, String color, String disponibilidad,
                                                  String transmision, String pais, String ciudad, String fk_ciudad)
        {
            return new Automovil(matricula, modelo, fabricante, anio, tipovehiculo,
                                  kilometraje, cantpasajeros, preciocompra, precioalquiler,
                                  penalidaddiaria, fecharegistro, color, disponibilidad,
                                  transmision, pais, ciudad, fk_ciudad);
        }

        public static Entidad CrearAutomovil(String matricula)
        {
            Automovil automovil = new Automovil();
            automovil.matricula = matricula;
            return automovil;
        }

        #endregion

        #region Modulo 10
        public static CRestauranteModelo crearRestaurant(string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo crearRestaurant(int id, string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(id, nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo crearRestaurant()
        {
            return new CRestauranteModelo();
        }
       

        public static Lugar crearLugar(int idLugar, string nombreLugar)
        {
            return new Lugar(idLugar, nombreLugar);
        }

        public static List<Lugar> crearListaLugar()
        {
            return new List<Lugar>();
        }

        public static List<CRestauranteModelo> crearListaRestarant()
        {
            return new List<CRestauranteModelo>();
        }

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }

        #endregion

        #region Modulo 13
        public static Entidad InstanciarRol(CRoles model)
        {
            String nombre = model.Nombre_rol;
            return new Rol(nombre);
        }
        public static Entidad InstanciarRolId(CRoles model)
        {
            int idRol = model.Id_Rol;
            return new Rol(idRol);
        }

        public static Entidad InstanciarRolPermiso(String rol, String permiso)
        {
            return new Rol(rol, permiso);
        }

        public static Entidad InstanciarPermiso(CModulo_detallado model)
        {
            String _nombre = model.Nombre;
            String url = model.Url;
            return new Permiso(_nombre, url);
        }

        public static Entidad crearRol(int id, String nombre)
        {
            return new Rol(id, nombre);
        }
        
        public static Entidad crearPermiso(int id, String nombre)
        {
            return new Permiso(id, nombre);
        }
        public static Entidad InstanciarRolIdNombre(CRoles model)
        {
            int idRol = model.Id_Rol;
            String nombreRol = model.Nombre_rol;
            return new Rol(idRol, nombreRol);
        }
        
        public static Entidad crearPermiso(int id, String nombre, String url)
        {
            return new Permiso(id, nombre, url);
        }
        #endregion

        #region M14 Cruceros

        //instancia cabina con nombre de crucero, no con FK

        public static Entidad InstanciarCabinaN(CGestion_cabina cabina)
        {
            return new Cabina(cabina._idCabina, cabina._nombreCabina, cabina._precioCabina, cabina._estatus, cabina._cruceroNombre);
        }

        /// <summary>
        /// Clase que instacia un Crucero
        /// </summary>
        /// <param name="model">Modelo proveniente de la vista M14_AgregarCrucero y M14_modificarCrucero</param>
        /// <param name="c">Modelo del Crucero</param>
        /// <returns></returns>
        public static Entidad InstanciarCrucero(CGestion_crucero crucero)
        {

            return new Crucero(crucero._idCrucero, crucero._nombreCrucero, crucero._companiaCrucero, crucero._capacidadCrucero, crucero._estatus);
        }    

        //instancia cabina con nombre de crucero, no con FK
        public static Entidad InstanciarCabina(CGestion_cabina cabina)
        {
            return new Cabina(cabina._idCabina, cabina._nombreCabina, cabina._precioCabina, cabina._estatus, cabina._fkCrucero);
        }

        public static Entidad InstanciarCamaroteN(CGestion_camarote camarote)
        {
            return new Camarote(camarote._idCamarote, camarote._cantidadCama, camarote._tipoCama, camarote._estatus, camarote._cabinaNombre);
        }

        public static Entidad InstanciarItinerarioN(CGestion_itinerario itinerario)
        {
            return new Itinerario(itinerario._id, itinerario._fechaInicio, itinerario._fechaFin, itinerario._estatus, itinerario._origen, itinerario._destino, itinerario._crucero);
        }


        #endregion


        #region M02_Gestion_Avion

        public static Entidad InstanciarAvion(int id, string matricula, string modelo, int capacidadTurista, int capacidadEjecutiva, int capacidadVIP, float capacidadEquipaje, float distanciaMaximaVuelo, float velocidadMaxima, float capacidadCombustible, int disponibilidad)
            {
           
            return new Avion();
        }

        public static Entidad InstanciarAvion(CAgregarAvion model)
        {

         
            string matricula = model._matriculaAvion;
            string modelo = model._modeloAvion;
            int capacidadturistica = model._capacidadPasajerosTurista;
            int capacidadEjecutiva = model._capacidadPasajerosEjecutiva;
            int capacidadVIP = model._capacidadPasajerosVIP;
            float capacidadEquipaje = model._capacidadEquipaje;
            float distanciaMaximaVuelo = model._distanciaMaximaVuelo;
            float velocidadMaxima = model._velocidadMaximaDeVuelo;
            float capacidadCombustible = model._capacidadMaximaCombustible;
            int disponibilidad = model._disponibilidad;



            return new Avion(matricula, modelo, capacidadturistica, capacidadEjecutiva, capacidadVIP, capacidadEquipaje, distanciaMaximaVuelo, velocidadMaxima, capacidadCombustible, disponibilidad);
        }

        public static Entidad InstanciarAvion(CModificarAvion model)
        {

            string matricula = model._matriculaAvion;
            string modelo = model._modeloAvion;
            int capacidadturistica = model._capacidadPasajerosTurista;
            int capacidadEjecutiva = model._capacidadPasajerosEjecutiva;
            int capacidadVIP = model._capacidadPasajerosVIP;
            float capacidadEquipaje = model._capacidadEquipaje;
            float distanciaMaximaVuelo = model._distanciaMaximaVuelo;
            float velocidadMaxima = model._velocidadMaximaDeVuelo;
            float capacidadCombustible = model._capacidadMaximaCombustible;
            int disponibilidad = model._disponibilidad;


            return new Avion(matricula, modelo, capacidadturistica, capacidadEjecutiva, capacidadVIP, capacidadEquipaje, distanciaMaximaVuelo, velocidadMaxima, capacidadCombustible, disponibilidad);
       
        }
        #endregion

        #region M06 GESTION COMIDA

        public static Entidad instanciarComida(string nombre, string tipo, int estatus, string descripcion)
        {
            return new Comida(nombre, tipo, estatus, descripcion);
        }

        public static Entidad instanciarComida(int id, string nombre, string tipo, int estatus, string descripcion)
        {
            return new Comida(id, nombre, tipo, estatus, descripcion);
        }

        public static Entidad instanciarComida()
        {
            return new Comida();
        }

        public static Entidad instanciarComida(int id)
        {
            return new Comida(id);
        }

        public static Entidad instanciarComidaVuelo(int id, string comida, string codigoVuelo, int cantidad)
        {
            return new ComidaVuelo(id, comida, codigoVuelo, cantidad);
        }

        public static Entidad instanciarComidaVuelo(int id, string comida, int cantidad)
        {
            return new ComidaVuelo(id, comida, cantidad);
        }

        #endregion

        #region M03_Ruta
        /// <summary>
        /// Se crea una instancia de la clase Ruta con todos sus atributos
        /// </summary>
        /// <param name="_idRuta"></param>
        /// <param name="_distancia"></param>
        /// <param name="_status"></param>
        /// <param name="_tipo"></param>
        /// <param name="_origenRuta"></param>
        /// <param name="_destinoRuta"></param>
        /// <returns>Retorna una instancia de la clase ruta con todos sus atributos</returns>
        public static Entidad InstanciarRuta(int _idRuta, int _distancia, String _status, String _tipo,
                                          String _origenRuta, String _destinoRuta)
        {
            return new Ruta(_idRuta, _distancia, _status, _tipo, _origenRuta, _destinoRuta);
        }
        public static Entidad InstanciarRuta(CAgregarRuta model)
        {
            

            String origen = model._origenRuta;
            String destino = model._destinoRuta;
            String tipo = model._tipoRuta;
            String status = model._estadoRuta;
            int distanciaRuta = model._distanciaRuta;
          

            return new Ruta(distanciaRuta, status, tipo, origen, destino);
        }

        #endregion

        #region M12_Usuarios 
        public static Entidad InstanciarUsuario(int id, string nombre, string apellido, string correo, string contrasena, int fkRol, DateTime fechaCreacion, string activo)
        {
            return new Usuario();
        }

        public static Entidad InstanciarUsuario(CAgregarUsuario model, int idRol)
        {
            string nombre = model._nombre;
            string apellido = model._apellido;
            string correo = model._correo;
            string contrasena = model.contraseñaUsuario;
            DateTime fechaCreacion = model._fechaCreacion;
            string activo = model._activo;

            return new Usuario(nombre, apellido, correo, contrasena, idRol, fechaCreacion, activo);
        }

        public static Entidad InstanciarUsuario(CModificarUsuario model, int idRol)
        {
            string nombre = model._nombre;
            string apellido = model._apellido;
            string correo = model._correo;
            string contrasena = model.contraseñaUsuario;
            DateTime fechaCreacion = model._fechaCreacion;
            string activo = model._activo;

            return new Usuario(nombre, apellido, correo, contrasena, idRol, fechaCreacion, activo);
        }

        public static Entidad InstanciarRol(int rol)
        {
            return new Rol();
        }

        #endregion

        #region M11 Gestión de ofertas y Paquetes

        /// <summary>
        /// Agregar oferta
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Entidad InstanciarOferta(CAgregarOferta model)
        {
            return new Oferta(model._nombreOferta, model._porcentajeOferta, model._fechaIniOferta,
                              model._fechaFinOferta, model._estadoOferta);
        }

        /// <summary>
        /// Agregar oferta
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public static Entidad InstanciarOferta(int idOferta, String nombreOferta, List<String> listaPaquetes,
                                               float porcentajeOferta, DateTime fechaIniOferta, DateTime fechaFinOferta,
                                               Boolean estadoOferta)
        {
            return new Oferta(idOferta, nombreOferta, listaPaquetes, porcentajeOferta, fechaIniOferta, fechaFinOferta,
                               estadoOferta);
        }



        /// <summary>
        /// Para la parte de agregar paquete necesitamos instanciar un paquete primero
        /// </summary>
        /// <param name="paquete"></param>
        /// <returns></returns>
        public static Entidad InstanciarPaquete(CPaquete paquete)
        {
            String nombrePaquete = paquete._nombrePaquete;
            float precioPaquete = paquete._precioPaquete;
            String idAuto = paquete._idAuto;
            int? idRestaurante = paquete._idRestaurante;
            int? idHotel = paquete._idHabitacion; //En realidad es el id del hotel
            int? idCrucero = paquete._idCrucero;
            int? idVuelo = paquete._idVuelo;
            DateTime? fechaIniAuto = paquete._fechaIniAuto;
            DateTime? fechaIniRest = paquete._fechaIniRest;
            DateTime? fechaIniHotel = paquete._fechaIniHabi; //Fecha de inicio para el hotel
            DateTime? fechaIniCruc = paquete._fechaIniCruc;
            DateTime? fechaIniVuelo = paquete._fechaIniVuelo;
            DateTime? fechaFinAuto = paquete._fechaFinAuto;
            DateTime? fechaFinRest = paquete._fechaFinRest;
            DateTime? fechaFinHotel = paquete._fechaFinHabi; //Fecha fin para el hotel
            DateTime? fechaFinCruc = paquete._fechaFinCruc;
            DateTime? fechaFinVuelo = paquete._fechaFinVuelo;
            bool estadoPaquete = paquete._estadoPaquete;
            return new Paquete(nombrePaquete, precioPaquete, idAuto, idRestaurante, idHotel, idCrucero, idVuelo,
                               fechaIniAuto, fechaIniRest, fechaIniHotel, fechaIniCruc, fechaIniVuelo, fechaFinAuto,
                               fechaFinRest, fechaFinHotel, fechaFinCruc, fechaFinVuelo, estadoPaquete);

        }

        /// <summary>
        ///Instanciar Oferta con model CModificarOferta
        /// </summary>
        /// <param name="model">del tipo CModificarOferta</param>
        /// <returns></returns>
        public static Entidad InstanciarOferta(CModificarOferta model, Boolean estadoOferta, int id)
        {
            return new Oferta(id, model._nombreOferta, model._porcentajeOferta, model._fechaIniOferta,
                              model._fechaFinOferta, estadoOferta);
        }

        public static Entidad InstanciarPaquete(int idpaquete, String nombrepaquete, float preciopaquete,
                                                    bool estadopaquete)
        {


            return new Paquete(idpaquete, nombrepaquete, preciopaquete, estadopaquete);

        }

        #endregion

        #region M07_ReclamosEquipaje

        /// <summary>
        /// Instancia Reclamo de Equipaje sin parametros
        /// </summary>
        /// <returns>Entidad instanciada</returns>
        public static Entidad InstanciarReclamoEquipaje()
        {
            return new ReclamoEquipaje();
        }

        /// <summary>
        /// Instancia Reclamo con parametros
        /// </summary>
        /// <param name="descripcionReclamo">Descripcion del reclamo</param>
        /// <param name="fechaReclamo">Fecha del reclamo</param>
        /// <param name="estadoReclamo">Estado del reclamo (abierto, cerrado)</param>
        /// <param name="pasajero">Pasajero involucrado</param>
        /// <param name="equipaje">Equipaje extraviado</param>
        /// <returns>Entidad instanciada</returns>
        public static Entidad InstanciarReclamoEquipaje(String descripcionReclamo, String fechaReclamo, String estadoReclamo, int pasajero, int equipaje)
        {
            return new ReclamoEquipaje(descripcionReclamo, fechaReclamo, estadoReclamo, pasajero, equipaje);
        }

        /// <summary>
        /// Instancia Reclamo con parametros segun id enviado
        /// </summary>
        /// <param name="idreclamo">ID Reclamo</param>
        /// <param name="descripcionReclamo">Descripcion del reclamo</param>
        /// <param name="fechaReclamo">Fecha del reclamo</param>
        /// <param name="estadoReclamo">Estado del reclamo (abierto, cerrado)</param>
        /// <param name="pasajero">Pasajero involucrado</param>
        /// <param name="equipaje">Equipaje extraviado</param>
        /// <returns>Entidad instanciada</returns>
        public static Entidad InstanciarReclamoEquipaje(int idreclamo, String descripcionReclamo, String fechaReclamo, String estadoReclamo, int pasajero, int equipaje)
        {
            return new ReclamoEquipaje(idreclamo, descripcionReclamo, fechaReclamo, estadoReclamo, pasajero, equipaje);
        }

        /// <summary>
        /// Instancia en modelo el Reclamo Equipaje
        /// </summary>
        /// <param name="model">Modelo a instanciar</param>
        /// <returns>Entidad instanciada</returns>
        public static Entidad InstanciarReclamoEquipaje(CAgregarReclamoEquipaje model)
        {
            String descripcion = model._descripcionReclamo;
            String fecha = model._fechaReclamo;
            String status = model._estadoReclamo;
            int pasajero = model._pasajero;
            int equipaje = model._equipaje;

            return new ReclamoEquipaje(descripcion, fecha, status, pasajero, equipaje);
        }

        /// <summary>
        /// Instancia lista de reclamos de equipaje
        /// </summary>
        /// <param name="listaEntidad">Lista a instanciar</param>
        /// <returns>Lista de reclamos</returns>
        public static List<ReclamoEquipaje> InstanciarListaReclamoEquipaje(Dictionary<int, Entidad> listaEntidad)
        {
            List<ReclamoEquipaje> lista = new List<ReclamoEquipaje>();
            foreach (var e in listaEntidad)
            {
                ReclamoEquipaje nuevoReclamo = (ReclamoEquipaje)e.Value;
                lista.Add(nuevoReclamo);
            }
            return lista;
        }

        /// <summary>
        /// Instanciacion para una lista vacia
        /// </summary>
        /// <returns>Lista de reclamos de equipaje vacia</returns>
        public static List<ReclamoEquipaje> InstanciarListaReclamoEquipaje()
        {
            return new List<ReclamoEquipaje>();
        }

        #endregion

        #region M07_Equipaje

        /// <summary>
        /// Instanciar Equipaje
        /// </summary>
        /// <returns>Entidad Instanciada</returns>

        public static Entidad InstanciarEquipaje()
        {
            return new Equipaje();
        }

        /// <summary>
        /// Instanciar Equipaje con parametros
        /// </summary>
        /// <param name="peso">Peso equipaje</param>
        /// <param name="abordaje">Pase Abordaje asociado</param>
        /// <returns>Entidad instanciada con parametros</returns>
        public static Entidad InstanciarEquipaje(int id, int peso, int abordaje)
        {
            return new Equipaje(id, peso, abordaje);
        }

        /// <summary>
        /// Instancia lista de equipaje
        /// </summary>
        /// <param name="listaEntidad">Lista a instanciar</param>
        /// <returns>Lista de equipajes</returns>
        public static List<Equipaje> InstanciarListaEquipaje(Dictionary<int, Entidad> listaEntidad)
        {
            List<Equipaje> lista = new List<Equipaje>();
            foreach (var e in listaEntidad)
        {
                Equipaje nuevoReclamo = (Equipaje)e.Value;
                lista.Add(nuevoReclamo);
        }
            return lista;
        }

        /// <summary>
        /// Instanciacion para una lista vacia
        /// </summary>
        /// <returns>Lista de reclamos de equipaje vacia</returns>
        public static List<Equipaje> InstanciarListaEquipaje()
        {   
            return new List<Equipaje>();
        }

        public static Entidad InstanciarPaquete(CPaquete paquete, Boolean estadoPaquete, int id)
        {
            return new Paquete(id, paquete._nombrePaquete, paquete._precioPaquete, paquete._idAuto, 
                               paquete._idRestaurante, paquete._idHabitacion, paquete._idCrucero, 
                               paquete._idVuelo, paquete._fechaIniAuto, paquete._fechaIniRest, 
                               paquete._fechaIniHabi, paquete._fechaIniCruc, paquete._fechaIniVuelo, 
                               paquete._fechaFinAuto, paquete._fechaFinRest, paquete._fechaFinHabi, 
                               paquete._fechaFinCruc, paquete._fechaFinVuelo, 
                               estadoPaquete);
        }

        #endregion
    }
}
