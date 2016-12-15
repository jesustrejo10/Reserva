using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class AgregarUsuario
    {
        public AgregarUsuario()
        {
            setFecha();
        }

        public AgregarUsuario(CUsuario usuario)
        {
            this._correo = usuario.correoUsuario;
            this._nombre = usuario.nombreUsuario;
            this._apellido = usuario.apellidoUsuario;
            this._contraseña = usuario.contraseñaUsuario;
            this._rol = usuario.rolUsuario;
            this._activo = usuario.activoUsuario;
            this._id = usuario.idUsuario;
        }
        
        #region Atributos
        /// <summary>
        /// TextBox de correo
        /// </summary>
        private String _correo { get; set; }

        /// <summary>
        /// TextBox de correo
        /// </summary>
        private int _id { get; set; }

        /// <summary>
        /// TextBox de contraseña
        /// </summary>
        private String _contraseña
        {
            get;
            set;
        }

        /// <summary>
        /// TextBox nombre y apellido
        /// </summary>
        private String _nombre { get; set; }

        private String _apellido { get; set; }
        /// <summary>
        /// TextBox fecha de creacion
        /// </summary>
        private DateTime _fechaCreacion { get; set; }
        /// <summary>
        /// Combo activo
        /// </summary>
        private String _activo { get; set; }

        /// <summary>
        /// Combo rol
        /// </summary>
        private int _rol { get; set; }
        #endregion

        #region Getters y Setters
        /// <summary>
        /// Get y Set del atributo _nombre
        /// </summary>
        /// <returns>nombre del usuario/returns>
        public string nombreUsuario
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set del atributo _contraseña
        /// </summary>
        /// <returns>contraseña del usuario/returns>
        public string contraseñaUsuario
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        /// <summary>
        /// Get y Set del atributo _correo
        /// </summary>
        /// <returns>correo del usuario/returns>
        public string correoUsuario
        {
            get { return _correo; }
            set { _correo = value; }
        }

        /// <summary>
        /// Get y Set del atributo _apellido
        /// </summary>
        /// <returns>apellido del usuario/returns>
        public string apellidoUsuario
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        /// <summary>
        /// Get y Set del atributo _fechaCreacion
        /// </summary>
        /// <returns>fecha creacion del usuario/returns>
        public DateTime fechaCreacionUsuario
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        /// <summary>
        /// Get y Set del atributo _activo
        /// </summary>
        /// <returns>activo si el usuario esta activo, inactivo si no lo esta/returns>
        public string activoUsuario
        {
            get { return _activo; }
            set { _activo = value; }
        }

        /// <summary>
        /// Get y Set del atributo _rol
        /// </summary>
        /// <returns>activo si el usuario esta activo, inactivo si no lo esta/returns>
        public int rolUsuario
        {
            get { return _rol; }
            set { _rol = value; }
        }

        /// <summary>
        /// Get y Set del atributo _id
        /// </summary>
        /// <returns>id del usuario/returns>
        public int idUsuario
        {
            get { return _id; }
            set { _id = value; }
        }

        [NotMapped]
        [Compare("contraseñaUsuario")]
        public string _confirmarContraseña
        {
            get;
            set;

        }
       #endregion


       


        public CUsuario toClass(){
            CUsuario user = new CUsuario(_id, _nombre, _apellido, HashPassword(_contraseña), _correo, _activo, _fechaCreacion, _rol);
            return user;

        }

        

        private String HashPassword(String pass)
        {
            if (pass != null)
                return Encriptar.CrearHash(_contraseña);
            else return null;
        }

        private void setFecha()
        {
            _fechaCreacion = DateTime.Now;
        }
    }
}