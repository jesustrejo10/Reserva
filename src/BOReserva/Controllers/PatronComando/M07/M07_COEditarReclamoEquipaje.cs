using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BOReserva.Controllers.PatronComando.M07
{
    public class M07_COEditarReclamoEquipaje: Command<String>
    {
        ReclamoEquipaje _reclamo;
        int _idReclamo;
        string _estado;

        public M07_COEditarReclamoEquipaje(int id, string estado)
        { 
            this._idReclamo = id;
            this._estado = estado;
        }

        public override String ejecutar(){
            IDAOReclamoEquipaje daoReclamo = FabricaDAO.instanciarDaoReclamoEquipajePersonalizado();
            int respuesta = daoReclamo.modificarEstado(_idReclamo,_estado);
            return respuesta.ToString();
        }  
    }
}