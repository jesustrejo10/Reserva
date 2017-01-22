using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M16
{
    public class M16_COEliminarReclamo : Command<String>
    {
        Reclamo _reclamo;
        int _idReclamo;

        public M16_COEliminarReclamo(int id)
        { 
            this._idReclamo = id;
        }


        public override String ejecutar(){
            IDAOReclamo daoReclamo =  FabricaDAO.instanciarDaoReclamoPersonalizado();
            int respuesta = daoReclamo.Eliminar(_idReclamo);
            return respuesta.ToString();
        }
    }
}