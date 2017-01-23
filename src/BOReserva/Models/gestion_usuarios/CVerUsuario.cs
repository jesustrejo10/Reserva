using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;
using System.ComponentModel.DataAnnotations;


namespace BOReserva.Models.gestion_usuarios
{
    public class CVerUsuario
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
    }
}