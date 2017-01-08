using BOReserva.Models.gestion_hoteles;
using BOReserva.Models.gestion_reclamos;
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
        public static Entidad InstanciarHotel(String nombre, String direccion, int fkCiudad, int clasificacion, String webPage, String email, int capacidad){

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

            return new Hotel(nombre,direccion,email,paginaWeb,clasificacion,capacidad,city);
        }

        public static Entidad InstanciarPais(String nombre) {
            return new Pais();
        }

        public static Entidad InstanciarCiudad(String ciudad) { 
            return new Ciudad();
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
        /// <param name="matriculaAvion"></param>
        /// <returns>Retorna una instancia de la clase vuelo con todos sus atributos</returns>
        public static Entidad crearVuelo(int id, String codigoVuelo, String ciudadOrigen, String ciudadDestino, 
                                         String fechaDespegue, String status, String fechaAterrizaje, 
                                         String matriculaAvion)
        {
            return new Vuelo(id, codigoVuelo, ciudadOrigen, ciudadDestino, fechaDespegue, status, fechaAterrizaje,
                             matriculaAvion);
        }
        #endregion  
    }
}
            return new Ciudad();
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
            String estado=model._estadoReclamo;
                       
            return new Reclamo(titulo,detalle,fecha,estado);
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
        /// <param name="matriculaAvion"></param>
        /// <returns>Retorna una instancia de la clase vuelo con todos sus atributos</returns>
        public static Entidad crearVuelo(int id, String codigoVuelo, String ciudadOrigen, String ciudadDestino, 
                                         String fechaDespegue, String status, String fechaAterrizaje, 
                                         String matriculaAvion)
            return new Vuelo(id, codigoVuelo, ciudadOrigen, ciudadDestino, fechaDespegue, status, fechaAterrizaje,
                             matriculaAvion);
        }
        #endregion  
