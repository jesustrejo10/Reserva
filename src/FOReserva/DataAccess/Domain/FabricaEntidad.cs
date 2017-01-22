using FOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada con la finalidad de instanciar a cualquier objeto dentro del Dominio

    /// </summary>
    public class FabricaEntidad
    {
        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }

        #region M21_Reserva_Restaurant

        public static Entidad InstanciarRestaurante(string direccion, string descripcion, string apertura, string cierre, Lugar ciudad){
            return new Restaurante(direccion, descripcion, apertura, cierre, ciudad);
        }

        #endregion
    }
}
