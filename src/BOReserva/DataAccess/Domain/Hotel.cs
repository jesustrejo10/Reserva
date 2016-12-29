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
        public Hotel(String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
        {
            this._nombre = nombre;
            this._direccion = direccion;
            this._email = email;
            this._paginaWeb = paginaWeb;
            this._clasificacion = clasificacion;
            this._capacidad = capacidad;
            this._ciudad = ciudad;
        }
        
        
    }
}