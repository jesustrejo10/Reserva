using BOReserva.Models.gestion_cruceros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class FabricaTransporte
    {
        public static Transporte InstanciarCrucero(CGestion_crucero crucero)
        {

            return new Crucero(crucero._nombreCrucero, crucero._companiaCrucero, crucero._capacidadCrucero, crucero._estatus);
        }

    }
}