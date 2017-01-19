using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Models.gestion_usuarios
{
    public class CAgregarUsuario
    {

        [Required]
        public string _correo { get; set; }
        public string _nombre { get; set; }
        public string _apellido { get; set; }
        public string _contrasena { get; set; }
        public int _rol { get; set; }
        public string _activo { get; set; }
        public int _id { get; set; }
        public DateTime _fechaCreacion { get; set; }
        public Dictionary<int, Entidad> _rols { get; set; }

        [NotMapped]
        [Compare("_contrasena")]
        public string _confirmarContraseña { get; set; }

        public CUsuario toClass()
        {
            CUsuario user = new CUsuario(_id, _nombre, _apellido, HashPassword(_contrasena), _correo, _activo, _fechaCreacion, _rol);
            return user;

        }

        private String HashPassword(String pass)
        {
            if (pass != null)
                return Encriptar.CrearHash(_contrasena);
            else return null;
        }

        private void setFecha()
        {
            _fechaCreacion = DateTime.Now;
        }
    }
}