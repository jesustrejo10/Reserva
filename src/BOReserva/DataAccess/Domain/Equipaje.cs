using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Equipaje
    /// </summary>
    public class Equipaje : Entidad
    {
        public int _peso { get; set; }
        public int _abordaje { get; set; }


        /// <summary>
        /// Constructor de la clase sin parametros
        /// </summary>
        public Equipaje() { }

        /// <summary>
        /// Constructor con 2 parametros
        /// </summary>
        /// <param name="peso">peso del equipaje</param>
        /// <param name="abordaje">abordaje asociado</param>
        public Equipaje(int peso, int abordaje)
        {
            this._peso = peso;
            this._abordaje = abordaje;
        }

        /// <summary>
        /// Constructor con 3 parametros
        /// </summary>
        /// <param name="id">id del equipaje</param>
        /// <param name="peso">peso del equipaje</param>
        /// <param name="abordaje">abordaje asociado</param>
        public Equipaje(int id, int peso, int abordaje)
        {
            this._id = id;
            this._peso = peso;
            this._abordaje = abordaje;
        }
    }
}