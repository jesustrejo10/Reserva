using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Model
{
    /// <summary>
    /// Clase que sirve de cache de la aplicacion
    /// </summary>
    public class Cache
    {


        /// <summary>
        /// Variable publica estatica, en la que se guardan los hoteles una vez son consultados
        /// en la bd
        /// </summary>
        public static Dictionary<int, Entidad> mapHoteles = new Dictionary<int, Entidad>();

        /// <summary>
        /// Metodo que es el encargado de Actualizar los hoteles en el cache de los hoteles
        /// </summary>
        /// <param name="hotelConNuevosCampos">
        /// Recibe un Hotel, con los campos a actualizar
        /// </param>
        public static void actualizarMapHoteles(Hotel hotelConNuevosCampos){
            try
            {
                if (mapHoteles.ContainsKey(hotelConNuevosCampos._id))
                {
                    Hotel hotelEnCache = (Hotel)mapHoteles[hotelConNuevosCampos._id];
                    //Para el modificar solo se alteran ciertos Valores.
                    //por lo que al hotelConNuevosCampos en cache le asigno los valores nuevos y actualizo el map
                    hotelEnCache._clasificacion = hotelConNuevosCampos._clasificacion;
                    hotelEnCache._nombre = hotelConNuevosCampos._nombre;
                    hotelEnCache._paginaWeb = hotelConNuevosCampos._paginaWeb;
                    hotelEnCache._email = hotelConNuevosCampos._email;
                    hotelEnCache._direccion = hotelConNuevosCampos._direccion;
                    // Ahora Elimino el Hotel del cache
                    mapHoteles.Remove(hotelConNuevosCampos._id);
                    //lo agrego Actualizado
                    mapHoteles.Add(hotelEnCache._id, hotelEnCache);
                }
            }
            catch (Exception e) { 
                //Escribir en Log
                Debug.Write("e");
            }
        }

        /// <summary>
        /// Metodo encargado de devolver un Hotel si se encuentra en cache
        /// </summary>
        /// <param name="id">
        /// Recibe el Id del hotel que se busca
        /// </param>
        /// <returns>
        /// Retorna un hotel almacenado en cache
        /// </returns>
        public static Entidad retornarHotelPorId(int id)
        {
            try
            {
                Entidad e = mapHoteles[id];
                return e;
            }
            catch (NullReferenceException){
                return null;
            }
        }

        /// <summary>
        /// Metodo encargado de verificar si un hotel se encuentra en cache
        /// </summary>
        /// <param name="id">recibe el id del hotel que se desea buscar</param>
        /// <returns>
        /// Retorna true, si el hotel se encuentra en cache
        /// Retorna false, si el hotel no se encuentra en cache
        /// </returns>
        public static Boolean estaEnCache(int id) {
            if (mapHoteles.ContainsKey(id)) 
            {
                return true; 
            } 
            else
            { 
                return false;
            }
        }

        /// <summary>
        /// Metodo encargado de cambiar la disponibilad de un hotel en el cache
        /// </summary>
        /// <param name="id">Recibe el id del hotel que se desea editar</param>
        /// <param name="nuevaDisponibilidad">Recibe el status que se le asignara al hotel almacenado en cache</param>
        public static void actualizarMapHotelesDisponibilidad(int id, int nuevaDisponibilidad) {
            Boolean disp;
            if (nuevaDisponibilidad == 1) {
                disp = true;
            }else
            {
                disp = false;
            }
            try
            {
                if (mapHoteles.ContainsKey(id))
                {
                    Hotel hotelEnCache = (Hotel)mapHoteles[id];
                    //Para el modificar solo se alteran ciertos Valores.
                    //por lo que al hotelConNuevosCampos en cache le asigno los valores nuevos y actualizo el map
                    hotelEnCache._disponibilidad = disp; 
                    // Ahora Elimino el Hotel del cache
                    mapHoteles.Remove(id);
                    //lo agrego Actualizado
                    mapHoteles.Add(id, hotelEnCache);
                }
            }
            catch (Exception e)
            {
                //Escribir en Log
                Debug.Write("e");
            }
        }

        /// <summary>
        /// Metodo encargado de eliminar un hotel del cache
        /// </summary>
        /// <param name="id">
        /// Recibe el Id del hotel que se desea eliminar
        /// </param>
        public static void eliminarHotelMap(int id) {
            try
            {
                mapHoteles.Remove(id);
            }
            catch (Exception e) { 
                //lanzar exception
            }
        }
    }
} 