using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class Encriptar
    {   
        //Extraido de https://github.com/TANGERINE00/Tangerine01/blob/f75064375e1a3dcb5e4f21bf390442de289ef04b/Tangerine/Tangerine/DominioTangerine/Encriptacion.cs
        public static string CrearHash(string dato)
        {
            MD5 md5 = MD5.Create();//Se instancia MD5
            byte[] md5Byte = md5.ComputeHash(Encoding.UTF8.GetBytes(dato));//Se aplica md5 al parametro de entrada
            StringBuilder cadena = new StringBuilder();
            for (int i = 0; i < md5Byte.Length; i++)
            {
                cadena.Append(md5Byte[i].ToString("x2"));
            }

            Console.Write(cadena.ToString());
            return cadena.ToString();
        }
        
    }
}