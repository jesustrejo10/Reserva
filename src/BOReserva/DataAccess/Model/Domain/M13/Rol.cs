using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase dominio Rol
    /// </summary>
    public class Rol: Entidad
    {
        public int _idRol { get; set; }
        public String _nombreRol { get; set; }
        public Permiso _permiso { get; set; }
        public String _nombrePermiso { get; set; }
        public List<Entidad> listapermisos { get; set; }

        /// <summary>
        /// Constructor vacio de Roles
        /// </summary>
        public Rol()
        {
        }

        /// <summary>
        /// Constructor de Roles que posee los atributos id del rol y nombre del rol
        /// </summary>
        public Rol(int id, String nombre)
        {
            this._idRol = id;
            this._nombreRol = nombre;
        }

        /// <summary>
        /// Constructor de Roles que posee nombre del rol
        /// </summary>
        public Rol(String nombre)
        {
            this._nombreRol = nombre;
        }

        /// <summary>
        /// Constructor de Roles que posee los atributos nombre del rol y de permiso
        /// </summary>
        public Rol(String nombre, String permiso)
        {
            this._nombreRol = nombre;
            this._nombrePermiso = permiso;
        }

        public Rol(int id)
        {
            this._idRol = id;
        }
    }

   
}