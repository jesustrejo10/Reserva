using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BOReserva.Controllers.PatronComando.M07
{
    public class M07_COEditarReclamoEquipaje : Command<String>
    {
        Equipaje _equipaje;
        int _idEquipaje;
        int _peso;

        public M07_COEditarReclamoEquipaje(int id, int estado)
        { 
            this._idReclamo = id;
            this._estado = estado;
        }

        public override String ejecutar(){
            IDAOEquipaje daoEquipaje = FabricaDAO.instanciarDaoReclamoEquipaje();
            int respuesta = daoEquipaje.modificarEstado(_idReclamo, _estado);
            return respuesta.ToString();
        }
    }
}