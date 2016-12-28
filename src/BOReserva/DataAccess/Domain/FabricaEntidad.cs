using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class FabricaEntidad
    {
        static Entidad CrearHotel(String nombre, String direccion, int fkCiudad, int clasificacion, String webPage, String email, int capacidad){

            return new Hotel();
        }
    }
}