﻿using BOReserva.Models;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_reclamos;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models.gestion_roles;
using BOReserva.Models.gestion_ofertas;
using BOReserva.DataAccess.Domain.M06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
        



namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada con la finalidad de instanciar a cualquier objeto dentro del Dominio

    /// </summary>
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
                clave = _clave
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
                clave = _clave,
                fechaCreacion = _fechaCreacion,
                activo = _activo
            };
        }
        #endregion

        #region M09_Gestion_Hoteles_Por_Ciudad
        public static Entidad InstanciarHotel(String nombre, String direccion, int fkCiudad, int clasificacion, String webPage, String email, int capacidad)
        {

            return new Hotel();
        }

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
            return new Hotel(nombre, direccion, email, paginaWeb, clasificacion, capacidad, city,precio);
        }

        public static Entidad InstanciarHotel(CModificarHotel model, Entidad c)
        {
            Ciudad city = (Ciudad)c;

            String nombre = model._nombre;
            String direccion = model._direccion;
            int clasificacion = model._clasificacion;
            int capacidad = model._capacidadHabitacion;
            String paginaWeb = model._paginaWeb;
            String email = model._email;

            return new Hotel(nombre, direccion, email, paginaWeb, clasificacion, capacidad, city);
        }

        public static Entidad InstanciarPais(String nombre)
        {
            return new Pais();
        }
        public static Entidad InstanciarPais(int id, String nombre)
        {
            return new Pais(id, nombre);
        }

        public static Entidad InstanciarCiudad(String ciudad)
        {
            return new Ciudad();
        }

        public static Entidad InstanciarCiudad(int id, String nombre, int fkPais)
        {
            return new Ciudad(id,nombre,fkPais);
        }

        public static Entidad InstanciarHabitacion(int precio, int fkHotel)
        {
            return new Habitacion( precio, fkHotel);
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

        public static Entidad InstanciarReclamo(int reclamo , String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int usuario)
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
        public static List<Reclamo> InstanciarListaReclamo(Dictionary<int, Entidad> listaEntidad) 
        {
            List<Reclamo> lista = new List<Reclamo>();
            foreach(var e in listaEntidad)
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
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
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

        public static Entidad InstanciarPasajero(int id, String nombre1, String nombre2, String apellido1, String apellido2, String sexo,
         string fecha, String correo)
        {
            DateTime fecha_nac = Convert.ToDateTime(fecha);
            return new Pasajero(id, nombre1, nombre2, apellido1, apellido2, sexo, fecha_nac, correo);
		}
        #endregion

        #region M08_Automoviles
        public static Entidad InstanciarAutomovil(String matricula, String modelo, String fabricante, String anio, String tipovehiculo,
                                                  String kilometraje, String cantpasajeros, String preciocompra, String precioalquiler,
                                                  String penalidaddiaria, String fecharegistro, String color, String disponibilidad,
                                                  String transmision, String pais, String ciudad, String fk_ciudad)
        {
            return new Automovil( matricula,  modelo, fabricante, anio, tipovehiculo,
                                  kilometraje, cantpasajeros, preciocompra, precioalquiler,
                                  penalidaddiaria, fecharegistro, color, disponibilidad,
                                  transmision, pais, ciudad, fk_ciudad);
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

        public static Entidad InstanciarPermiso(String permiso)
        {
            return new Permiso();
        }

        public static Entidad crearRol(int id, String nombre)
        {
            return new Rol(id, nombre);
        }

        public static Entidad crearPermiso(int id, String nombre)
        {
            return new Permiso(id, nombre);
        }

        public static Entidad crearModulo(int id, String nombre)
        {
            return new Modulo(id, nombre);
        }
        #endregion

        #region M06 GESTION COMIDA

        public static Entidad instanciarComida(string nombre, string tipo, int estatus, string descripcion) {
            return new Comida(nombre, tipo, estatus, descripcion);
        }

        public static Entidad instanciarComida()
        {
            return new Comida();
        }

        public static Entidad instanciarComidaVuelo(int id, string comida, string codigoVuelo, int cantidad)
        {
            return new ComidaVuelo(id, comida, codigoVuelo, cantidad);
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
            return new Oferta(idOferta, nombreOferta, listaPaquetes , porcentajeOferta, fechaIniOferta, fechaFinOferta, 
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

        #endregion
    }
}
