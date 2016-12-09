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

        /// <summary>
        /// TextBox de correo
        /// </summary>
        public String _correo { get; set; }

        /// <summary>
        /// TextBox de contraseña
        /// </summary>
        public String _contraseña
        {
            get;
            set;
        }

        /// <summary>
        /// TextBox nombre y apellido
        /// </summary>
        public String _nombre { get; set; }

        public String _apellido { get; set; }
        /// <summary>
        /// TextBox fecha de creacion
        /// </summary>
        public DateTime _fechaCreacion { get; set; }
        /// <summary>
        /// Combo activo
        /// </summary>
        public String _activo { get; set; }

        /// <summary>
        /// Combo rol
        /// </summary>
        public int _rol { get; set; }

        [NotMapped]
        [Compare("_contraseña")]
        public string _confirmarContraseña
        {
            get;
            set;

        }


        public CUsuario toClass(){
            CUsuario user = new CUsuario(_nombre, _apellido, HashPassword(_contraseña), _correo, _activo, _fechaCreacion, _rol);
            return user;

        }

        private String HashPassword(String pass)
        {
            return Encriptar.CrearHash(_contraseña);
        }

        private void setFecha()
        {
            _fechaCreacion = DateTime.Now;
        }
    }
}