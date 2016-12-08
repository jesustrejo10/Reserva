using BOReserva.Servicio;
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


       public Cgestion_seguridad_ingreso()
       {
       }
        
        public Cgestion_seguridad_ingreso(String correo, String clave, String nombre)
        {
            this._correoCampoTexto = correo;
            this._claveCampoTexto = clave;
            this._nombreUsuarioTexto = nombre;
        }

        /// <summary>
        /// Funcion que verifica credenciales de usuario, se conecta con el modulo de usuario 
        /// </summary>
        /// <param name="_correoCampoTexto"> Longitud de la serie</param>
        /// <param name="_claveCampoTexto"> Longitud de la serie</param>

        //public Boolean verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
        public Cgestion_seguridad_ingreso verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
        {
            M01SQL bd = new M01SQL();
            Cgestion_seguridad_ingreso verificacion = bd.UsuarioEnBD(_correoCampoTexto);
            if (verificacion._correoCampoTexto.Equals(_correoCampoTexto) && verificacion._claveCampoTexto.Equals(_claveCampoTexto))
            {
                return verificacion;
            }
            else
                throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");
            /*
            if ("admin@admin.com".Equals(_correoCampoTexto) && "123".Equals(_claveCampoTexto))
            {
                return true;
            }
            else
                throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");*/
        }

        public Boolean EstaActivo() 
        {
            M01SQL bd = new M01SQL();
            String estatus = bd.UsuarioEstatus(this._correoCampoTexto);
            if (estatus.ToLower().Equals("activo"))
            {
                return true;
            }
            else
                return false;
 
        }

        public Boolean BloquearUsuario() {
            M01SQL bd = new M01SQL();
            if (bd.BloquearUsuario(this._correoCampoTexto)) {
                return true;
            }
            else
            {
                return false; // Creo que aqui deberia lanzar una excepcion
            }
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