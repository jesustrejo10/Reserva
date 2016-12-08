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

        #region verificarUsuario
        /// <summary>
        /// Funcion que verifica credenciales de usuario, se conecta con el modulo de usuario 
        /// se verifica el usuario sin tomar en cuanta mayusculas o minusculas
        /// </summary>
        /// <param name="_correoCampoTexto"> Correo de Usuario</param>
        /// <param name="_claveCampoTexto"> Contraseña de Usuario</param>
        /// <returns>Retorna true or false segun verificacion de credenciales</returns>
        public Boolean verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
        {
            Boolean Usuario = String.Equals("admin@admin.com", _correoCampoTexto, StringComparison.OrdinalIgnoreCase);
            Boolean Contraseña = "123".Equals(_claveCampoTexto);
            if (Usuario && Contraseña)
            {
                return true;
            }
            else
                throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");
        }
        #endregion


        #region Get y Set
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

        #endregion

    }
}