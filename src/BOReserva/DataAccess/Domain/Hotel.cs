using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Hotel : Entidad
    {
        public String _nombre { get; set; }
        public String _direccion { get; set; }
        public Ciudad _ciudad { get; set; }
        public String _email { get; set; }
        public String _paginaWeb { get; set; }
        public int _clasificacion { get; set; }
        public int _capacidad { get; set; }

        /// <summary>
        /// Constructor Vacio utilizado mientras se le da forma al proyecto
        /// </summary>
        public Hotel() {
        }

        
        
    }
}