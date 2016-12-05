using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.registro_autenticacion
{
    public class Cpregunta_Respuesta
    {
        public Cpregunta_Respuesta(String _pregunta1, String _pregunta2, String _pregunta3, String _respuesta1, String _respuesta2, String _respuesta3)
        {
            //Constructor
        }

        public String Mrecuperacion(String _pregunta, String _respuesta)
        {
            //Recupera
            return null;
        }

        public Boolean Mvalidar_Respuesta(String _pregunta)
        {
            //Valida respuesta
            return false;
        }

        public String _pregunta { get; set; }
        public String _respuesta { get; set; }

    }
}