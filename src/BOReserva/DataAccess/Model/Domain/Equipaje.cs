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
        private int _peso { get; set; }
        private int _abordaje { get; set; }


        /// <summary>
        /// Constructor de la clase sin parametros
        /// </summary>
        public Equipaje() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="peso">peso del equipaje</param>
        /// <param name="abordaje">abordaje asociado</param>
        public Equipaje(int peso, int abordaje)
        {
            this._peso = peso;
            this._abordaje = abordaje;
        }
    }
}