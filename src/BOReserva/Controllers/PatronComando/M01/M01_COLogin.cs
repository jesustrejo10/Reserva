using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M01
{
    public class M01_COLogin : Command<String>
    {
        private string _correo;
        private string _contrasena;

        public M01_COLogin(string correo, string contrasena)
        {
            this._correo = correo;
            this._contrasena = contrasena;
        }

        public override String ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}