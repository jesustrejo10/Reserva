using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_seguridad_ingreso
{
    public class Cgestion_seguridad_ingreso
    {
       private String _correoCampoTexto;
       private String _claveCampoTexto;
       private String _nombreUsuarioTexto;

        /// <summary>
        /// Funcion que verifica credenciales de usuario, se conecta con el modulo de usuario 
        /// </summary>
        /// <param name="_correoCampoTexto"> Longitud de la serie</param>
        /// <param name="_claveCampoTexto"> Longitud de la serie</param>
        public Boolean verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
        {
            if ("admin@admin.com".Equals(_correoCampoTexto) && "123".Equals(_claveCampoTexto))
            {
                return true;
            }
            else
                throw new Cvalidar_texto_Exception("Usuario o contraseña incorrecto");
        }

        public String correoCampoTexto
        {
            get { return this._correoCampoTexto; }
            set { this._correoCampoTexto = value; }
        }

        public String claveCampoTexto
        {
            get { return this._claveCampoTexto; }
            set { this._claveCampoTexto = value; }
        }

        public String nombreUsuarioTexto
        {
            get { return this._nombreUsuarioTexto; }
            set { this._nombreUsuarioTexto = value; }
        }



    }
}