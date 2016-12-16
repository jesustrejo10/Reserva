using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Sesion
{
    public class Seguridad
    {

        public static string Cifrar(string _texto) {
            string resultado = string.Empty;

            byte[] cifrado = System.Text.Encoding.Unicode.GetBytes(_texto);
            resultado = Convert.ToBase64String(cifrado);
            return resultado;
        }


        public static string Descifrar(string  _texto) {
            string resultado = string.Empty;

            byte[] descifrado = Convert.FromBase64String(_texto);
            resultado = System.Text.Encoding.Unicode.GetString(descifrado);
            return resultado;
        }
    }
}