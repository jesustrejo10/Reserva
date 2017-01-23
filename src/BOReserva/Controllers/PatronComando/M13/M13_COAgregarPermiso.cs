using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COAgregarPermiso : Command<String>
    {
        Permiso _permiso;

        public M13_COAgregarPermiso(Permiso permiso)
        {
            this._permiso = permiso;
        }

        public override string ejecutar()
        {
            IDAO daoPermiso = FabricaDAO.instanciarDAOPermiso();
            daoPermiso.Agregar(_permiso);
            return "1";
        }
    }
}