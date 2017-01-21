﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject;

namespace BOReserva.Controllers.PatronComando
{
    public class M16_COAgregarReclamo: Command<String>
    {
        Reclamo _reclamo;

        public M16_COAgregarReclamo(Reclamo reclamo) 
        {
            this._reclamo = reclamo;
        }

        public override String ejecutar()
        {
            IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();

            daoReclamo.Agregar(_reclamo);
            int test = daoReclamo.Agregar(_reclamo);
            return test.ToString();
        }
    }
}