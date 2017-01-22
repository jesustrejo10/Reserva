using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers.PatronComando.M08
{
    public class M08_COListarCantidadAutomovil : Command<List<SelectListItem>>
    {

        #region Atributos

        Entidad _objeto;

        #endregion

        #region Constructor

        public M08_COListarCantidadAutomovil(){}

        public M08_COListarCantidadAutomovil(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        #endregion

        #region Ejecucion

        public override List<SelectListItem> ejecutar(int cantidad)
        {
            DAO Dao = FabricaDAO.CrearDaoAutomovil();
            DAOAutomovil DaoAutomovil = (DAOAutomovil)Dao;
            return DaoAutomovil.listarCantidad(cantidad);
        }

        #endregion

    }
}