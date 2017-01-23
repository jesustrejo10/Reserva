using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COValidacionPermiso : Command<List<int>>
    {
        int _idPermiso;

        public M13_COValidacionPermiso(int id)
        {
            this._idPermiso = id;
        }

        public override List<int> ejecutar()
        {
            DAOPermiso daoPermiso = (DAOPermiso)FabricaDAO.instanciarDAOPermiso();
            List<int> test = daoPermiso.validacionPermiso(_idPermiso);
            return test;
        }

    }
}