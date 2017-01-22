using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase para el manejo de los hoteles
    /// </summary>
    public class Hotel : Entidad
    {
        public String _nombre { get; set; }
        public String _direccion { get; set; }
        public Ciudad _ciudad { get; set; }
        public String _email { get; set; }
        public String _paginaWeb { get; set; }
        public int _clasificacion { get; set; }
        public int _capacidad { get; set; }
        public Boolean _disponibilidad { get; set; }
        public int _precio { get; set; }


        /// <summary>
        /// Constructor Vacio utilizado mientras se le da forma al proyecto
        /// </summary>
        public Hotel() {
        }
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="id">Id del hotel/param>
        /// <param name="nombre">Nombre del hotel</param>
        /// <param name="direccion">Ubicacion del hotel</param>
        /// <param name="email">Email del hotel</param>
        /// <param name="paginaWeb">Pagina web del hotel</param>
        /// <param name="clasificacion">Clasificacion del hotel</param>
        /// <param name="capacidad">Capacidad del hotel</param>
        /// <param name="ciudad">Ciudad donde se ubica el hotel</param>
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
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del hotel</param>
        /// <param name="direccion">Direccion del hotel</param>
        /// <param name="email">Email del hotel</param>
        /// <param name="paginaWeb">Pagina web del hotel</param>
        /// <param name="clasificacion">Clasificacion del hotel</param>
        /// <param name="capacidad">Capacidad del hotel</param>
        /// <param name="ciudad">Ciudad donde se ubica el hotel</param>
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

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del hotel</param>
        /// <param name="direccion">Direccion del hotel</param>
        /// <param name="email">Email del hotel</param>
        /// <param name="paginaWeb">Pagina web del hotel</param>
        /// <param name="clasificacion">Clasificacion del hotel</param>
        /// <param name="capacidad">Capacidad del hotel</param>
        /// <param name="ciudad">Ciudad donde se ubica el hotel</param>
        /// <param name="precio">Precio de las habitaciones</param>
        public Hotel(String nombre, String direccion, String email, String paginaWeb, int clasificacion, int capacidad, Ciudad ciudad, int precio)
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

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="idhotel">Id del hotel</param>
        /// <param name="nombre">Nombre del hotel</param>
        /// <param name="direccion">Direccion del hotel</param>
        /// <param name="email">Email del hotel</param>
        /// <param name="paginaWeb">Pagina web del hotel</param>
        /// <param name="clasificacion">Clasificacion del hotel</param>
        /// <param name="capacidad">Capacidad del hotel</param>
        /// <param name="ciudad">Ciudad donde se ubica el hotel</param>
        /// <param name="disponibilidad">Disponibilidad del hotel</param>
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