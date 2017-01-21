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
    public class COConsultarTodosCiudad : Command<Dictionary<int, Entidad>>
    {

        #region Atributos

        Entidad _objeto;

        #endregion

        #region Constructor

        public COConsultarTodosCiudad(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        #region Ejecucion

        public override Dictionary<int, Entidad> ejecutar()
        {
            DAO Dao = FabricaDAO.instanciarDaoCiudad();

            return Dao.ConsultarTodos();
        }

        #endregion

    }
}