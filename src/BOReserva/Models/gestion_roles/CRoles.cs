using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_roles
{


    public class CRoles
    {
        private int _id_rol;
        private string _nombre_rol;
        private CListaGenerica<CModulo_general> _menu;
        private CListaGenerica<CModulo_detallado> _permisos;


        public CRoles()
        {
            this._nombre_rol = "";
            this._menu = new CListaGenerica<CModulo_general>();
            this._permisos = new CListaGenerica<CModulo_detallado>();
        }

        //Get and set de id rol 
        public int Id_rol
        {
            get { return _id_rol; }
            set { _id_rol = value; }
        }

        //Get and set de nombre rol 
        public string Nombre_rol
        {
            get { return _nombre_rol; }
            set { _nombre_rol = value; }
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