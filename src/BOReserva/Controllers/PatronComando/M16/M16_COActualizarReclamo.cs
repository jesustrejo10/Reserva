using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M16
{
    public class M16_COActualizarReclamo : Command<String>
    {
        Reclamo _reclamo;
        int _idReclamo;
        int _estado;

        public M16_COActualizarReclamo(int id, int estado)
        { 
            this._idReclamo = id;
            this._estado = estado;
        }

        public override String ejecutar(){
            IDAOReclamo daoReclamo = FabricaDAO.instanciarDaoReclamoPersonalizado();
            int respuesta = daoReclamo.modificarEstado(_idReclamo,_estado);
            return respuesta.ToString();
        }
    }
}