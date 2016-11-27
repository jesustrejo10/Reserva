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
        /// <summary>
        /// TextBox de correo
        /// </summary>
        public String _correo { get; set; }
        /// <summary>
        /// TextBox de contraseña
        /// </summary>
        public String _contraseña { get; set; }
        /// <summary>
        /// TextBox nombre y apellido
        /// </summary>
        public String _nombreApellido { get; set; }
        /// <summary>
        /// TextBox fecha de creacion
        /// </summary>
        public DateTime _fechaCreacion { get; set; }
        /// <summary>
        /// TextBox activo
        /// </summary>
        public String _activo { get; set; }

        [NotMapped]
        [Compare("_contraseña")]
        public string _confirmarContraseña { get; set; }
        //private Rol _rol;


    }
}