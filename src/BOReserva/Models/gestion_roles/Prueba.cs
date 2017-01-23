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



        public CRoles(string nombre)
        {
            this._nombre_rol = nombre;
            this._menu = new CListaGenerica<CModulo_general>();
        }



        //Get and set de rol 
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


    }
}