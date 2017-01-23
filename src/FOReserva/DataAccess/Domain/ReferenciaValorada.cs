using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferenciaValorada: Entidad
    {
        /// <summary>
        /// Constructor base.
        /// </summary>
        public ReferenciaValorada() {
            this.Id = 0;
            this.Estrellas = 0;
            this.Tipo = EnumTipoRevision.Hotel;
        }

        /// <summary>
        /// Permite obtener y indicar el Id de la instancia.
        /// </summary>
        public int Id
        {
            get { return this._id; }
            set { _id = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Estrellas de la instancia.
        /// </summary>
        public decimal Estrellas { get; set; }

        /// <summary>
        /// Permite obtener y indicar el Tipo de la instancia.
        /// </summary>
        public EnumTipoRevision Tipo { get; set; }
    }
}