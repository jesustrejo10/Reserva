using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_roles
{
    public class CModulo_detallado
    {
        private string _nombre;
        private string _url;



        public CModulo_detallado()
        {
        }

        public CModulo_detallado(string nombre, string url)
        {
            this._nombre = nombre;
            this._url = url;
        }

        // Get and set de nombre
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        // Get and set de la url 
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        

    }


}