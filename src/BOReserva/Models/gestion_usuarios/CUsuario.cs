using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class CUsuario
    {

        private String _correo { get; set; }
        private String _contraseña { get; set; }
        private String _nombreApellido { get; set; }
        private DateTime _fechaCreacion;
        private String _activo;
        //private Rol _rol;

    }
}