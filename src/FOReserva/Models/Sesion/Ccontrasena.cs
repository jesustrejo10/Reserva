using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.registro_autenticacion
{
    public class Ccontrasena
    {

        public Ccontrasena(String _contrasena)
        {
            //Constructor
        }

        public void Meditar_Contrasena(String _contrasena)
        {
            //Editar
        }

        public Boolean Mcomparar_Contrasena(String _contrasena)
        {
            //Compara
            return false;
        }

        public String Mencriptar_Contrasena(String _contrasena)
        {
            //Encripta
            return null;
        }

        public String Mdesencriptar_Contrasena(String _contrasena)
        {
            return null;
        }

        public String _contrasena { get; set; }
    }
}