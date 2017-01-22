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
        private Entidad _revision;
        private int _punto;
        private Entidad _propietario;

        /// <summary>
        /// Constructor Base.
        /// </summary>
        public RevisionValoracion() {
            this.Punto = 0;
            this.Propietario = new Entidad(0);
            this.Revision = new Entidad(0);
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
        public int Punto
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