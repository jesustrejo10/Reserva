using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class ListaRoles
    {
        private int _rolID;
        private string _rolNombre;

        public int rolID
        {
            get { return _rolID; }
            set { _rolID = value; }
        }

        public string rolNombre
        {
            get { return _rolNombre; }
            set { _rolNombre= value; }
        }
    }
}