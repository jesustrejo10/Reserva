using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers.PatronComando.GeneralLugar
{
    public class COConsultarTodosPais : Command<List<SelectListItem>>
    {
        
        #region Atributos

        Entidad _objeto;

        #endregion

        #region Constructor

        public COConsultarTodosPais(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        #endregion

        #region Ejecucion

        public override List<SelectListItem> ejecutar()
        {
            DAOPais Dao = (DAOPais)FabricaDAO.instanciarDaoPais();

            return Dao.listarPaises();
        }

        #endregion

    }
}