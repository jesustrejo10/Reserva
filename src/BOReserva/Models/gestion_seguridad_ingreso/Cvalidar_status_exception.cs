using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_seguridad_ingreso
{
    public class Cvalidar_status_exception:Exception
    {
      
      public Cvalidar_status_exception(String Mensaje):base(Mensaje) { }

    }
}