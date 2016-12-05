using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.registro_autenticacion
{
    public class Ccodigo_Temporal
    {

        public Ccodigo_Temporal()
        {
            //Constructor
        }

        public Boolean Mcomparar_codigo(String _codigo)
        {
            return false;
        }

        public String Mgenerar_codigo()
        {
            return null;
        }

        public String _codigo { get; set; }
 
    }
}