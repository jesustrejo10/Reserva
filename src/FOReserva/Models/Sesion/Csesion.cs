using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.registro_autenticacion
{
    public class Csesion
    {
        public Csesion()
        {
            //Constructor
        }

        public void Miniciar_Sesion(Ccliente cliente)
        {
            //inicia sesion
        }

        public void Mcerrar_Sesion()
        {
            //Cerrar sesion
        }

        public Ccliente _cliente { get; set; }
    }
}