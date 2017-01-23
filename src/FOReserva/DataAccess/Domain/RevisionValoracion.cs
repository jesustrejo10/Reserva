using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Esta clase facilita la interaccion con la tabla Revision_Valoracion.
    /// </summary>
    public class RevisionValoracion : Entidad
    {
        public enum Calificacion { Positiva = 1, Negativa = -1 }

        private Entidad _revision;
        private Calificacion _punto;
        private Entidad _propietario;

        /// <summary>
        /// Constructor Base.
        /// </summary>
        public RevisionValoracion() {
            this.Punto = Calificacion.Positiva;
            this.Propietario = new Entidad(0);
            this.Revision = new Entidad(0);
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
        /// Propiedad que facilita el acceso a atributo Revision.
        /// </summary>
        public Entidad Revision
        {
            get { return _revision; }
            set { _revision = value; }
        }

        /// <summary>
        /// Propiedad que facilita el acceso a atributo Punto.
        /// </summary>
        public Calificacion Punto
        {
            get { return _punto; }
            set { _punto = value; }
        }

        /// <summary>
        /// Propiedad que facilita el acceso a atributo Propietario.
        /// </summary>
        public Entidad Propietario
        {
            get { return _propietario; }
            set { _propietario = value; }
        }
    }
}