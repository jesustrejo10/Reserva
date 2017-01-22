using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M16
{
    public class M16_COModificarReclamo : Command<String>
    {
        Reclamo _reclamo;
        int _id;

        public M16_COModificarReclamo(Entidad _reclamo,int _id)
        {
            this._reclamo = (Reclamo) _reclamo;
            this._reclamo._id = _id;
        }

        public override String ejecutar()
        {
            IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
            Entidad test = daoReclamo.Modificar(_reclamo);
            //Reclamo reclamo = (Reclamo)test;
            return "1";
        }

    }
}