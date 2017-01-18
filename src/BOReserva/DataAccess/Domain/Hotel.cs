using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Hotel : Entidad
    {
        private object p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        private object p6;
        private object p7;
        private Ciudad ciudad;
        private int idHotel;
        private int p8;
        private int p9;
        private int p10;

        public String _nombre { get; set; }
        public String _direccion { get; set; }
        public Ciudad _ciudad { get; set; }
        public String _email { get; set; }
        public String _paginaWeb { get; set; }
        public int _clasificacion { get; set; }
        public int _capacidad { get; set; }
        public Boolean _disponibilidad { get; set; } 
        /// <summary>
        /// Constructor Vacio utilizado mientras se le da forma al proyecto
        /// </summary>
        public Hotel() {
        }
        public Hotel(int id, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad)
        {
            this._id = id;
            this._nombre = nombre;
            this._direccion = direccion;
            this._email = email;
            this._paginaWeb = paginaWeb;
            this._clasificacion = clasificacion;
            this._capacidad = capacidad;
            this._ciudad = ciudad;
            this._disponibilidad = true;
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
            this._disponibilidad = true;

        }

        public Hotel(int idhotel, String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad, int disponibilidad)
        {
            this._id = idhotel;
            this._nombre = nombre;
            this._direccion = direccion;
            this._email = email;
            this._paginaWeb = paginaWeb;
            this._clasificacion = clasificacion;
            this._capacidad = capacidad;
            this._ciudad = ciudad;
            if (disponibilidad == 1){
                this._disponibilidad = true;
            }
            else
            {
                this._disponibilidad = false;
            }

        }
    }
}