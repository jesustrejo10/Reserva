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
    public class COConsultarTodosCiudad : Command<List<String>>
    {

        #region Atributos

        Entidad _objeto;
        String _pais;

        #endregion

        #region Constructor

        public COConsultarTodosCiudad(Entidad _objeto,string _pais)
        {
            this._objeto = _objeto;
            this._pais = _pais;
        }

        #endregion

        #region Ejecucion

        public override List<String> ejecutar()
        {
            DAOCiudad Dao = (DAOCiudad)FabricaDAO.instanciarDaoCiudad();

            return Dao.listarCiudades(this._pais);
        }

        #endregion

    }
}