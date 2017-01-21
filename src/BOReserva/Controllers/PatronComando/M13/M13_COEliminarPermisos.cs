using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COEliminarPermisos : Command<String>
    {
        int _idEliminar;

        public M13_COEliminarPermisos(int id)
        {
            this._idEliminar = id;
        }

        public override String ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            String test = daoRol.eliminarPermiso(_idEliminar);
            return test;
        }

    }
}