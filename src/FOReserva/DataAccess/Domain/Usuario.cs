using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Usuario : Entidad
    {
        /// <summary>
        /// Constructor Base.
        /// </summary>
        public Usuario() {
            this.Id = 0;
        }

        /// <summary>
        /// Constructur Usuario, requiere ID.
        /// </summary>
        public Usuario(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Constructur Usuario, requiere ID y Nombre.
        /// </summary>
        public Usuario(int id, String nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Permite obtener y indicar el Id de la instancia.
        /// </summary>
        public int Id
        {
            get { return this._id;  }
            set { _id = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Nombre de la instancia.
        /// </summary>
        public string Nombre { get; set; }        
    }
}