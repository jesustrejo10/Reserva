using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_roles
{


    public class CRoles
    {
        private string _nombre_rol;
        private CListaGenerica<CModulo_general> _menu;
        private CListaGenerica<CModulo_detallado> _permisos;
        private int idRol;

        public CRoles()
        {
            this._nombre_rol = "";
            this._idRol = 0;
            this._menu = new CListaGenerica<CModulo_general>();
            this._permisos = new CListaGenerica<CModulo_detallado>();
        }

        public CRoles(String nombre, int id)
        {
            this._idRol = id;
            this._nombre_rol = nombre;
        }

        //Get and set de rol 
        public string Nombre_rol
        {
            get { return _nombre_rol; }
            set { _nombre_rol = value; }
        }

        public int _idRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        //Get and set de la lista de modulos generales
        public CListaGenerica<CModulo_general> Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        //Get and set de la lista de modulo detallado
        public CListaGenerica<CModulo_detallado> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }

    }
}