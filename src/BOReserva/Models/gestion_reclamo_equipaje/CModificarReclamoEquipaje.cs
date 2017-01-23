using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_reclamo_equipaje
{
    /// <summary>
    /// Clase del modelo de la vista parcial modificar reclamo equipaje
    /// </summary>
    public class CModificarReclamoEquipaje
    {
        public String _descripcionReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public String _estadoReclamo { get; set; }
        public int _pasajero { get; set; }
        public int _equipaje { get; set; }
    }
}