using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M01
{
    public class M01_COBloquearUsuario : Command<String>
    {
        private string _correo;

        public M01_COBloquearUsuario(string correo)
        {
            this._correo = correo;
        }

        public override String ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}