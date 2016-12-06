using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_seguridad_ingreso
{
    public class Cvalidar_usuario_Exception : Exception
    {
        public Cvalidar_usuario_Exception(String Mensaje) : base(Mensaje) { }

    }
}