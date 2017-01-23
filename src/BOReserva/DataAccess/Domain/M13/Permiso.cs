using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    ///<summary>
    ///Clase de dominio Permiso
    ///</summary>
    public class Permiso : Entidad
    {
        ///<summary>
        ///nombre del permiso
        ///</summary>
        public string nombrePermiso { get; set; }
        ///<summary>
        ///nombre
        ///</summary>
        public String _nombre { get; set; }
        ///<summary>
        ///id del permiso
        ///</summary>
        public int _idPermiso { get; set; }
        ///<summary>
        ///url del permiso
        ///</summary>
        public String url { get; set; }
        ///<summary>
        ///Constructor
        ///</summary>
        public Permiso(int id, string nombre)
        {
            this._idPermiso = id;
            this._nombre = nombre;
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Permiso()
        {
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Permiso(int id) : base(id)
        {
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Permiso(string nombrePermiso)
        {
            this.nombrePermiso = nombrePermiso;
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Permiso(string nombrePermiso, string url) : this(nombrePermiso)
        {
            this.url = url;
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Permiso(int id, string nombre, string url) : this(id, nombre)
        {
            this.url = url;
        }
    }
}