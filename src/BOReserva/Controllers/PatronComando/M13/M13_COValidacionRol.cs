using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COValidacionRol : Command<List<int>>
    {
        int _idRol;

        public M13_COValidacionRol(int id)
        {
            this._idRol = id;
        }

        public override List<int> ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            List<int> test = daoRol.validacionRol(_idRol);
            return test;
        }

    }
}