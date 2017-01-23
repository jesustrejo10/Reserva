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
    public class COConsultarIdLugar : Command<int>
    {

        #region Atributos

        String _lugar;

        #endregion

        #region Constructor

        public COConsultarIdLugar(string _lugar)
        {
            this._lugar = _lugar;
        }

        #endregion

        #region Ejecucion

        public override int ejecutar()
        {
            DAOLugar Dao = (DAOLugar)FabricaDAO.instanciarDaoLugar();

            return Dao.obtenerIDlugar(this._lugar);
        }

        #endregion

    }
}