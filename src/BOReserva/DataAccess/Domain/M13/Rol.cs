using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_roles;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase dominio Rol
    /// </summary>
    public class Rol: Entidad
    {
        private CListaGenerica<CModulo_detallado> permisos;
        ///<summary>
        ///id del rol
        ///</summary>
        public int _idRol { get; set; }
        ///<summary>
        ///Nombre del rol
        ///</summary>
        public String _nombreRol { get; set; }
        ///<summary>
        ///Permiso del rol
        ///</summary>
        public Permiso _permiso { get; set; }
        ///<summary>
        ///Nombre del permiso
        ///</summary>
        public String _nombrePermiso { get; set; }
        ///<summary>
        ///lista de permisos
        ///</summary>
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

        ///<summary>
        ///Constructor
        ///</summary>
        public Rol(int id)
        {
            this._idRol = id;
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Rol(int id, string nombre, CListaGenerica<CModulo_detallado> permisos)
        {
            this._idRol = id;
            this._nombreRol = nombre;
            this.permisos = permisos;
        }
    }

   
}