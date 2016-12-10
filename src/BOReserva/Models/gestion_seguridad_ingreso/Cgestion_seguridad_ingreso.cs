
using BOReserva.Models.gestion_usuarios;
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
       private String _apellidoUsuarioTexto;
       private String _usuarioEstatus;

        public Cgestion_seguridad_ingreso() { }
        public Cgestion_seguridad_ingreso(String correo, String clave, String nombre,String apellido, String status)
        {
            this._correoCampoTexto = correo;
            this._claveCampoTexto = clave;
            this._nombreUsuarioTexto = nombre;
            this.apellidoUsuarioTexto = apellido;
            this._usuarioEstatus = status;

        }

        #region verificarUsuario
        /// <summary>
        /// Funcion que verifica credenciales de usuario, se conecta con el modulo de usuario 
        /// se verifica el usuario sin tomar en cuanta mayusculas o minusculas
        /// </summary>
        /// <param name="_correoCampoTexto"> Correo de Usuario</param>
        /// <param name="_claveCampoTexto"> Contraseña de Usuario</param>
        /// <returns>Retorna true or false segun verificacion de credenciales</returns>
        public Cgestion_seguridad_ingreso verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
        {
                      
            M01SQL bd = new M01SQL();
            String clave = Encriptar.CrearHash(_claveCampoTexto);//metodo implementado por MOD 12 USUARIO
                     
            Cgestion_seguridad_ingreso verificacion = bd.UsuarioEnBD(_correoCampoTexto);
            Boolean Usuario = verificacion._correoCampoTexto.Equals(_correoCampoTexto);
            Boolean Contraseña = verificacion._claveCampoTexto.Equals(clave);
            System.Diagnostics.Debug.WriteLine("Correo " + Usuario + " contrasena " + Contraseña);

            if (Usuario && Contraseña)
            {
                return verificacion;
            }
            else
            {
                if (verificacion != null && !verificacion._correoCampoTexto.Equals(""))
                    bd.IncrementarIntentos(_correoCampoTexto);


                throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");

            }
        }
        #endregion

        /// <summary>
        /// Funcion que verifica el estatus de usuario activo o inactivo
        /// </summary>
        /// <returns>Retorna true estatus de usuario activo false inacivo</returns>

        public Boolean EstaActivo()
        {
            // M01SQL bd = new M01SQL();
            //  String estatus = bd.UsuarioEstatus(this._correoCampoTexto);
            if (this._usuarioEstatus.ToLower().Equals("activo"))
            {
                return true;
            }
            else
                throw new Cvalidar_status_exception("Usuario Inactivo contacte administrador");


        }

        /// <summary>
        /// Funcion que verifica si el usuario se encuentra bloqueado
        /// </summary>
        /// <returns>Retorna true bloqueado false si no esta bloqueado</returns>
        public Boolean BloquearUsuario()
        {
            M01SQL bd = new M01SQL();
            if (bd.BloquearUsuario(this._correoCampoTexto))
            {
                return true;
            }
            else
            {
                return false; // Creo que aqui deberia lanzar una excepcion
            }
        }

        /// <summary>
        /// Funcion reinicia el contador de intentos de usuario
        /// </summary>
        /// <returns>Retorna true si el ingreso de contraseña fue correcto false caso contrario</returns>
        public Boolean ResetearIntentos()
        {
            M01SQL bd = new M01SQL();
            if (bd.ResetearIntentos(this._correoCampoTexto))
            {
                return true;
            }
            else
            {
                return false; // Creo que aqui deberia lanzar una excepcion
            }
        }

        /// <summary>
        /// Funcion que verifica la cantidad de intentos fallidos de ingreso
        /// de contraseña si llega a 3 se bloquea al usuario
        /// </summary>
        /// <returns>Retorna true fue bloqueado false caso contrario</returns>
        public Boolean VerificarIntentos()
        {
            M01SQL bd = new M01SQL();
            int intentos = bd.NumeroIntentos(this._correoCampoTexto);
            if (intentos < 3)
                return true;
            else
                throw new Cvalidar_bloqueo_exception("Usuario Bloqueado Contacte administrador");  
                return false;
        }

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

        public String apellidoUsuarioTexto
        {
            get { return this._apellidoUsuarioTexto; }
            set { this._apellidoUsuarioTexto = value; }
        }

        #endregion

    }


   
        }


//﻿using BOReserva.Servicio;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace BOReserva.Models.gestion_seguridad_ingreso
//{
//    public class Cgestion_seguridad_ingreso
//    {
//       private String _correoCampoTexto;
//       private String _claveCampoTexto;
//       private String _nombreUsuarioTexto;
//       private String _usuarioEstatus;


//       public Cgestion_seguridad_ingreso()
//       {
//       }
        
//        public Cgestion_seguridad_ingreso(String correo, String clave, String nombre, String status)
//        {
//            this._correoCampoTexto = correo;
//            this._claveCampoTexto = clave;
//            this._nombreUsuarioTexto = nombre;
//            this._usuarioEstatus = status;

//        }

//        /// <summary>
//        /// Funcion que verifica credenciales de usuario, se conecta con el modulo de usuario 
//        /// </summary>
//        /// <param name="_correoCampoTexto"> Longitud de la serie</param>
//        /// <param name="_claveCampoTexto"> Longitud de la serie</param>

//        //public Boolean verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
//        public Cgestion_seguridad_ingreso verificarUsuario(String _correoCampoTexto, String _claveCampoTexto)
//        {
//            M01SQL bd = new M01SQL();
//            Cgestion_seguridad_ingreso verificacion = bd.UsuarioEnBD(_correoCampoTexto);
//            if (verificacion!=null && verificacion._correoCampoTexto.Equals(_correoCampoTexto) && verificacion._claveCampoTexto.Equals(_claveCampoTexto))
//            {
//                return verificacion;
//            }
//            else {
//                if (verificacion != null && !verificacion._correoCampoTexto.Equals(""))
//                    bd.IncrementarIntentos(_correoCampoTexto);
//                throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");
            
//            }
//                /*
//            if ("admin@admin.com".Equals(_correoCampoTexto) && "123".Equals(_claveCampoTexto))
//            {
//                return true;
//            }
//            else
//                throw new Cvalidar_usuario_Exception("Usuario o contraseña incorrecto");*/
//        }

//        public Boolean EstaActivo() 
//        {
//           // M01SQL bd = new M01SQL();
//          //  String estatus = bd.UsuarioEstatus(this._correoCampoTexto);
//            if (this._usuarioEstatus.ToLower().Equals("activo"))
//            {
//                return true;
//            }
//            else
//                return false;
 
//        }

//        public Boolean BloquearUsuario() {
//            M01SQL bd = new M01SQL();
//            if (bd.BloquearUsuario(this._correoCampoTexto)) {
//                return true;
//            }
//            else
//            {
//                return false; // Creo que aqui deberia lanzar una excepcion
//            }
//        }

//        public Boolean ResetearIntentos()
//        {
//            M01SQL bd = new M01SQL();
//            if (bd.ResetearIntentos(this._correoCampoTexto))
//            {
//                return true;
//            }
//            else
//            {
//                return false; // Creo que aqui deberia lanzar una excepcion
//            }
//        }

//        public Boolean VerificarIntentos()
//        {
//            M01SQL bd = new M01SQL();
//            int intentos = bd.NumeroIntentos(this._correoCampoTexto);
//            if (intentos<3)
//                return true;
//            else
//                return false;
//        }

//        public String correoCampoTexto
//        {
//            get { return this._correoCampoTexto; }
//            set { this._correoCampoTexto = value; }
//        }

//        public String claveCampoTexto
//        {
//            get { return this._claveCampoTexto; }
//            set { this._claveCampoTexto = value; }
//        }

//        public String nombreUsuarioTexto
//        {
//            get { return this._nombreUsuarioTexto; }
//            set { this._nombreUsuarioTexto = value; }
//        }



//    }
//}
