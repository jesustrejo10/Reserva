using BOReserva.Models;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_reclamos;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models.gestion_roles;
using BOReserva.Models.gestion_ofertas;
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

            return new Hotel(nombre, direccion, email, paginaWeb, clasificacion, capacidad, city);
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

        #endregion 
        public static Entidad InstanciarReclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int usuario)
        {
            return new Reclamo();
        }
        public static Entidad InstanciarReclamo(CAgregarReclamo model, Entidad c)
        {
            String titulo = model._tituloReclamo;
            String detalle = model._detalleReclamo;
            String fecha = model._fechaReclamo;
            int estado = model._estadoReclamo;
            int usuario = model._usuario;

            return new Reclamo(titulo, detalle, fecha, estado, usuario);
        }

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
        public static Entidad crearVuelo(int id, String codigoVuelo, int ruta, DateTime fechaDespegue,
                                          String status, DateTime fechaAterrizaje, int avion)
        {
            return new Vuelo(id, codigoVuelo, ruta, fechaDespegue, status, fechaAterrizaje,
                             avion);
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

        public static Entidad InstanciarRol(CRoles model)
        {
            String nombre = model.Nombre_rol;

            return new Rol(nombre);
        }

        public static Entidad InstanciarRolPermiso(String rol, String permiso)
        {
            return new Rol(rol, permiso);
        }

        public static Entidad InstanciarPermiso(String permiso)
        {
            return new Permiso();
        }

        #region M11 Gestión de ofertas y Paquetes

        //Agregar oferta
        public static Entidad InstanciarOferta(CAgregarOferta model) {
            return new Oferta(model._nombreOferta, model._porcentajeOferta, model._fechaIniOferta,
                              model._fechaFinOferta, model._estadoOferta);
        }
        public static Entidad InstanciarPaquete(CPaquete paquete)
        {
            String nombrePaquete = paquete._nombrePaquete;
            float precioPaquete = paquete._precioPaquete;
            String idAuto = paquete._idAuto;
            int idRestaurante =  (int) paquete._idRestaurante;
            int idHotel = (int) paquete._idHabitacion; //En realidad es el id del hotel
            int idCrucero = (int) paquete._idCrucero;
            int idVuelo = (int) paquete._idVuelo;
            DateTime fechaIniAuto = (DateTime) paquete._fechaIniAuto;
            DateTime fechaIniRest = (DateTime) paquete._fechaIniRest;
            DateTime fechaIniHotel = (DateTime)paquete._fechaIniHabi; //Fecha de inicio para el hotel
            DateTime fechaIniCruc = (DateTime) paquete._fechaIniCruc;
            DateTime fechaIniVuelo = (DateTime)paquete._fechaIniVuelo;
            DateTime fechaFinAuto = (DateTime)paquete._fechaFinAuto;
            DateTime fechaFinRest = (DateTime) paquete._fechaFinRest;
            DateTime fechaFinHotel = (DateTime)paquete._fechaFinHabi; //Fecha fin para el hotel
            DateTime fechaFinCruc = (DateTime)paquete._fechaFinCruc;
            DateTime fechaFinVuelo = (DateTime)paquete._fechaFinVuelo;
            return new Paquete(nombrePaquete, precioPaquete, idAuto, idRestaurante, idHotel, idCrucero, idVuelo, 
                               fechaIniAuto, fechaIniRest, fechaIniHotel, fechaIniCruc, fechaIniVuelo, fechaFinAuto,
                               fechaFinRest, fechaFinHotel, fechaFinCruc, fechaFinVuelo);

        }
        #endregion

    }
}
