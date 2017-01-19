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

    }
}
