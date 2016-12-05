using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_seguridad_ingreso
{
    public class Cgestion_seguridad_ingreso
    {
       private String _correoCampoTexto;
       private String _claveCampoTexto;
       private String _nombreUsuarioTexto;

  
        public String correoCampoTexto
        {
            get { return this._correoCampoTexto; }
            set { this._correoCampoTexto = value; }
        }

        public String claveCampoTexto
        {
            get { return this._claveCampoTexto; }
            set { this._claveCampoTexto = value; }
        }

        public String nombreUsuarioTexto
        {
            get { return this._nombreUsuarioTexto; }
            set { this._nombreUsuarioTexto = value; }
        }



    }
}