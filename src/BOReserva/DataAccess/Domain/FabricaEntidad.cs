using BOReserva.Models.gestion_hoteles;
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
    }
}