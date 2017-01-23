using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FOReserva.Models.gestion_reserva_automovil
{
    /// <summary>
    /// Clase del modelo de la vista parcial M19_Reserva_Autos
    /// </summary>
    public class CVistaReservaAuto : Entidad
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

        public String _fechaini { get; set; }

        public String _fechafin { get; set; }

        public int SelectedCiudadIdOrigen { get; set; }
        public int SelectedCiudadIdDestino { get; set; }

        public String _horaIni { get; set; }

        public String _horaFin { get; set; }

        public int _ciudadOrigen { get; set; }

        public int _ciudadDestino { get; set; }


        public CVistaReservaAuto(string fecha_ini, string fecha_fin, string horario_ini,
                                       string horario_fin, int idOrigen, int idDestino)
        {
            
            this._fechaini = fecha_ini;
            this._fechafin = fecha_fin;
            this._horaIni = horario_ini;
            this._horaFin = horario_fin;
            this._ciudadOrigen = idOrigen;
            this._ciudadDestino = idDestino;
        }

        public CVistaReservaAuto()
        {


        }



    }
}
