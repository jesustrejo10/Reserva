using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase para el manejo de las ciudad
    /// </summary>
    public class Ciudad : Entidad
    {
        public String _nombre { get; set; }
        public Pais _pais { get; set; }
        public int _fkPais { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Id de la ciudad</param>
        /// <param name="nombre">Nombre de la ciudad</param>
        /// <param name="pais">Pais al cual pertenece</param>
        public Ciudad(int id, String nombre, Pais pais) {
            this._id = id;
            this._nombre = nombre;
            this._pais = pais;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Id de la ciudad</param>
        /// <param name="nombre">Nombre de la ciudad</param>
        /// <param name="fkPais">Pais al cual pertenece</param>
        public Ciudad(int id, String nombre, int fkPais)
        {
            this._id = id;
            this._nombre = nombre;
            this._fkPais = fkPais;
        }

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Ciudad() { }
    }
}