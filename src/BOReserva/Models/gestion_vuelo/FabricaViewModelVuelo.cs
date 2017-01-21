using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Models.gestion_vuelo
{
    public class FabricaViewModelVuelo 
    {
        /// <summary>
        /// 
        /// </summary>
        public static VueloViewModel instanciarCrearVueloVM()
        {
            return new CrearVueloMO();
        }
    }
}