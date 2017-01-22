using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Permiso : Entidad
    {
        public string nombrePermiso { get; set; }

        public String _nombre { get; set; }

        public int _idPermiso { get; set; }

        public String url { get; set; }

        public Permiso(int id, string nombre)
        {
            this._idPermiso = id;
            this._nombre = nombre;
        }

        public Permiso()
        {
        }

        public Permiso(int id) : base(id)
        {
        }

        public Permiso(string nombrePermiso)
        {
            this.nombrePermiso = nombrePermiso;
        }

        public Permiso(string nombrePermiso, string url) : this(nombrePermiso)
        {
            this.url = url;
        }
    }
}