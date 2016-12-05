using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_seguridad_ingreso
{
    public class Cvalidar_texto_Exception : Exception
    {
        public Cvalidar_texto_Exception(String Mensaje) : base(Mensaje) { }

    }
}