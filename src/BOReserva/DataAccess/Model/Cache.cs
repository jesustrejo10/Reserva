using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Model
{
    public class Cache
    {
        public static Dictionary<int, Entidad> mapHoteles = new Dictionary<int, Entidad>();

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
    }
}