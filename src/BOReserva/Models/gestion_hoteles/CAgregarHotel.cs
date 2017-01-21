using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_hoteles
{
    /// <summary>
<<<<<<< HEAD
    /// Clase del modelo de la vista parcial M08_AgregarHoteles
=======
    /// Clase del modelo de la vista parcial M09_AgregarHotel
>>>>>>> 22c1980369f519eaca5fa02a9a7352070445db73
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
