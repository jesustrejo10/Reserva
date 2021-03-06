﻿using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.GeneralLugar
{
    public class COConsultarTodosLugar : Command<bool>
    {
        
        #region Atributos

        Entidad _objeto;

        #endregion

        #region Constructor

        public COConsultarTodosLugar(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        #endregion

        #region Ejecucion

        public override bool ejecutar()
        {
            DAO Dao = FabricaDAO.CrearDaoAutomovil();
            DAOAutomovil DaoAutomovil = (DAOAutomovil)Dao;
            return DaoAutomovil.ActivarDesactivar(this._objeto);
        }

        #endregion

    }
}