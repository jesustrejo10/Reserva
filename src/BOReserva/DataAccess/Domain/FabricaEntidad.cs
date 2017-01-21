﻿using BOReserva.Models;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_reclamos;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models.gestion_roles;
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

        public static Entidad InstanciarPais(String nombre)
        {
            return new Pais();
        }

        public static Entidad InstanciarCiudad(String ciudad)
        {
            return new Ciudad();
        }

        /// <summary>
        /// Metodo que instancia la clase ciudad
        /// </summary>
        /// <param name="id">id de la ciudad</param>
        /// <param name="ciudad">nombre de la ciudad</param>
        /// <returns>Instancia de la clase ciudad</returns>
        public static Entidad InstanciarCiudad(int id, String ciudad)
        {
            return new Ciudad(id, ciudad);
        }

        public static Entidad InstanciarReclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, String estadoReclamo)
        {
            return new Reclamo();
        }
        public static Entidad InstanciarReclamo(CAgregarReclamo model, Entidad c)
        {
            String titulo = model._tituloReclamo;
            String detalle = model._detalleReclamo;
            String fecha = model._fechaReclamo;
            String estado = model._estadoReclamo;

            return new Reclamo(titulo, detalle, fecha, estado);
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
        public static CRestauranteModelo inicializarRestaurant(string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo inicializarRestaurant(int id, string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(id, nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo inicializarRestaurant()
        {
            return new CRestauranteModelo();
        }
        #endregion

        public static Lugar inicializarLugar(int idLugar, string nombreLugar)
        {
            return new Lugar(idLugar, nombreLugar);
        }

        public static List<Lugar> inicializarListaLugar()
        {
            return new List<Lugar>();
        }

        public static List<CRestauranteModelo> inicializarListaRestarant()
        {
            return new List<CRestauranteModelo>();
        }

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }

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

    }
}
