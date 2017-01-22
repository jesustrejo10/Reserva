﻿using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class CUsuario
    {

        private String _correo;
        private String _contraseña; 
        private String _nombre;
        private String _apellido;
        private DateTime _fechaCreacion ;
        private String _activo;
        private int _rol;
        private int _id;
        private String _rolS;

        #region Constructores
        public CUsuario()
        {
        }

        public CUsuario(String nombre, String apellido, String contraseña, String correo, String activo, int rol)
        {
            _correo = correo;
            _contraseña = contraseña;
            _nombre = nombre;
            _apellido = apellido;
            _activo = activo;
            _rol = rol;
        }

        public CUsuario(String nombre, String apellido, String contraseña, String correo, String activo, DateTime fechaCreacion, int rol)
        {
            _correo = correo;
            _contraseña = contraseña; 
            _nombre = nombre;
            _apellido = apellido;
            _fechaCreacion = fechaCreacion ;
            _activo = activo;
            _rol = rol;
        }

        public CUsuario(int id, String nombre, String apellido, String contraseña, String correo, String activo, DateTime fechaCreacion, int rol)
        {
            _correo = correo;
            _contraseña = contraseña;
            _nombre = nombre;
            _apellido = apellido;
            _fechaCreacion = fechaCreacion;
            _activo = activo;
            _rol = rol;
            _id = id;
        }

        public CUsuario(int id, String nombre, String apellido, String contraseña, String correo, String activo, int rol)
        {
            _correo = correo;
            _contraseña = contraseña;
            _nombre = nombre;
            _apellido = apellido;
            _activo = activo;
            _rol = rol;
            _id = id;
        }
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

        /// <summary>
        /// Get y Set del atributo _rolS
        /// </summary>
        /// <returns>string del rol del usuario/returns>
        public String rolSUsuario
        {
            get { return _rolS; }
            set { _rolS = value; }
        }

    }
       #endregion
}