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
    public class M08_COListarAutomovil : Command<List<Entidad>>
    {
        
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public M08_COListarAutomovil() { }

        public M08_COListarAutomovil(Entidad _objeto)
        {
            this._objeto = _objeto;
        }


        #endregion

        #region Ejecucion

        public override List<Entidad> ejecutar()
        {
            DAO Dao = FabricaDAO.CrearDaoAutomovil();
            DAOAutomovil DaoAutomovil = (DAOAutomovil)Dao;
            return DaoAutomovil.ConsultarTodos();

        }

        #endregion

    }
}