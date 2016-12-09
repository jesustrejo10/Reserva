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
        /// string del rol
        /// </summary>
        private String _rol;

        /// <summary>
        /// id del usuario almacenado en la bd a traves de una secuencia
        /// </summary>
        private int _id;
    }
}