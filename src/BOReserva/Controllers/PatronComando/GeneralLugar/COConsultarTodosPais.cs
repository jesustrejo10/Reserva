using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.GeneralLugar
{
    public class COConsultarTodosPais : Command<Dictionary<int, Entidad>>
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

        public override Dictionary<int, Entidad> ejecutar()
        {
            DAO Dao = FabricaDAO.instanciarDaoPais();

            return Dao.ConsultarTodos();
        }

        #endregion

    }
}