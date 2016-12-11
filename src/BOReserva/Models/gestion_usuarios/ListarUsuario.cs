using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class ListarUsuario
    {
        /// <summary>
        /// TextBox de correo
        /// </summary>
        public String _correo { get; set; }


        /// <summary>
        /// nombre
        /// </summary>
        public String _nombre { get; set; }

        /// <summary>
        /// apellido
        /// </summary
        public String _apellido { get; set; }

        /// <summary>
        ///  fecha de creacion
        /// </summary>
        public DateTime _fechaCreacion { get; set; }
        /// <summary>
        /// Combo activo
        /// </summary>
        public String _activo { get; set; }

        /// <summary>
        /// id del rol
        /// </summary>
        public int _rolID { get; set; }

        /// <summary>
        /// string del rol
        /// </summary>
        public String _rol { get; set; }

        /// <summary>
        /// id del usuario almacenado en la bd a traves de una secuencia
        /// </summary>
        public int _id { get; set; }

        /// <summary>
        /// id del usuario almacenado en la bd a traves de una secuencia
        /// </summary>
        public string _contraseña { get; set; }

        /// <summary>
        /// id del usuario almacenado en la bd a traves de una secuencia
        /// </summary>
        public string _confirmarContraseña { get; set; }

        private String HashPassword(String pass)
        {
            return Encriptar.CrearHash(_contraseña);
        }

        public String getDate()
        {
            return _fechaCreacion.ToString("dd/MM/yyyy");
        }

        public CUsuario toClass()
        {
            CUsuario user = new CUsuario(_id, _nombre, _apellido, HashPassword(_contraseña), _correo, _activo, _rolID);
            return user;

        }
    }
}