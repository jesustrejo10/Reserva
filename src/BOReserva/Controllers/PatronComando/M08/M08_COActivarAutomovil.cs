using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M08
{
    public class M08_COActivarAutomovil : Command<String>
    {
        
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public M08_COActivarAutomovil() { }

        public M08_COActivarAutomovil(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        #endregion

        #region Ejecucion

        public override string ejecutar()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}