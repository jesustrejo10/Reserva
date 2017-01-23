using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COEliminarPermiso : Command<String>
    {
        int _idPermiso;

        public M13_COEliminarPermiso(int id)
        {
            this._idPermiso = id;
        }

        public override String ejecutar()
        {
            DAOPermiso daoPermiso = (DAOPermiso)FabricaDAO.instanciarDAOPermiso();
            String test = daoPermiso.eliminarPermisoSeleccionado(_idPermiso);
            return test;
        }

    }
}