﻿using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M08
{
    public class M08_CODesactivarAutomovil : Command<String>
    {
        
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public M08_CODesactivarAutomovil() { }

        public M08_CODesactivarAutomovil(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        #endregion

        public override string ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}