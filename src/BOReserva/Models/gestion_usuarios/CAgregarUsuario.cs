using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Models.gestion_usuarios
{
    /// <summary>
    /// Constructor de la clase
    /// </summary>
    /// <param name="_correo">Correo del usuario</param>
    /// <param name="_nombre">Nombre del usuario</param>
    /// <param name="_apellido">Apellido del usuario</param>
    /// <param name="_contrasena">Contrasena del usuario</param>
    /// <param name="_rol">Rol del usuario</param>
    /// <param name="_activo">Activo del usuario</param>
    /// <param name="_id">Id del usuario</param>
    /// <param name="_fechaCreacion">fechaCreacion del usuario</param>
    /// <param name="_rols">rols del usuario</param>
    public class CAgregarUsuario
    {

        [Required]
        public string _correo { get; set; }
        public string _nombre { get; set; }
        public string _apellido { get; set; }
        private string _contrasena { get; set; }
        public int _rol { get; set; }
        public string _activo { get; set; }
        public int _id { get; set; }
        public DateTime _fechaCreacion { get; set; }
        public Dictionary<int, Entidad> _rols { get; set; }

        [NotMapped]
        [Compare("contraseñaUsuario")]
        public string _confirmarContraseña { get; set; }

        public string contraseñaUsuario
        {
            get { return HashPassword(_contrasena); }
            set { _contrasena = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pass">password del usuario</param>
        private String HashPassword(String pass)
        {
            if (pass != null)
                return Encriptar.CrearHash(_contrasena);
            else return null;
        }

    }
}