﻿using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_hoteles
{
    /// <summary>
    /// Clase del modelo de la vista parcial M08_AgregarAutomovil
    /// </summary>
    public class CAgregarHotel
    {
        [Required]
        public String _nombre { get; set; } 
        public String _direccion { get; set; } 
        public String _paginaWeb { get; set; } 
        public String _email { get; set; } 
        public String _pais { get; set; }
        public int _clasificacion { get; set; }
        public int _capacidadHabitacion { get; set; }
        public Dictionary<int, Entidad> _paises { get; set; }

        public int _precioHabitacion { get; set;  }
    }
}
