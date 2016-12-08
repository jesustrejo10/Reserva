using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class ModificarUsuario
    {
        /// <summary>
        /// TextBox de correo
        /// </summary>
        private String _correo;


        /// <summary>
        /// nombre
        /// </summary>
        private String _nombre;

        /// <summary>
        /// apellido
        /// </summary
        private String _apellido;

        /// <summary>
        ///  fecha de creacion
        /// </summary>
        private DateTime _fechaCreacion;
        /// <summary>
        /// Combo activo
        /// </summary>
        private String _activo;
            
        /// <summary>
        /// id del rol
        /// </summary>
        private int _rolID;

        /// <summary>
        /// contraseña del usuario
        /// </summary>
        private String _contraseña;

        /// <summary>
        /// string del rol
        /// </summary>
        private String _rol;

        /// <summary>
        /// id del usuario almacenado en la bd a traves de una secuencia
        /// </summary>
        private int _id;

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
            get { return _rolID; }
            set { _rolID = value; }
        }

    }
       #endregion
}
    
