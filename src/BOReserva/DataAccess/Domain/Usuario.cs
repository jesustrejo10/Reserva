using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Usuario :Entidad
    {
        public String _nombre { get; set; }
        public String _apellido { get; set; }
        public String _correo { get; set; }
        public String _contrasena { get; set; }
        public Rol _rol { get; set; }
        public DateTime _fechaCreacion { get; set; }
        public String _activo { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, String nombre, String apellido, String correo, String contrasena, Rol rol, DateTime fechaCreacion, String activo)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._correo = correo;
            this._contrasena = contrasena;
            this._rol = rol;
            this._fechaCreacion = fechaCreacion;
            this._activo = activo;
        }

        public Usuario(String nombre, String apellido, String correo, String contrasena, Rol rol, DateTime fechaCreacion, String activo)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._correo = correo;
            this._contrasena = contrasena;
            this._rol = rol;
            this._fechaCreacion = fechaCreacion;
            this._activo = activo;
        }

    }
}