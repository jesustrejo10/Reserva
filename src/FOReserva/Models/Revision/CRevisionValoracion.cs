using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    /// <summary>
    /// Clase Valoracion Revision
    /// </summary>
    public class CRevisionValoracion : Entidad
    {
        private int _positivo;
        private int _negativo;

        public enum TipoValoracion { Positiva, Negativa };

        /// <summary>
        /// Builder Valoracion Revision
        /// </summary>
        /// <param name="positivo">Valoraciones positivas</param>
        /// <param name="negativo">Valoraciones negativas</param>
        public CRevisionValoracion(int positivo, int negativo)
         {
             this._positivo = positivo;
             this._negativo = negativo;
         }

        /// <summary>
        /// Builder Valoracion Revision Vacio
        /// </summary>
         public CRevisionValoracion() { }

         public int Positivo
         {
             get { return _positivo; }
             set { _positivo = value; }
         }
         public int Negativo
         {
             get { return _negativo; }
             set { _negativo = value; }
         }
    }
}