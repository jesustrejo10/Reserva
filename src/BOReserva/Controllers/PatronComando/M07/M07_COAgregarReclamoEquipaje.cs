using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M07
{
    public class M07_COAgregarReclamoEquipaje: Command<String> 
    {
        ReclamoEquipaje _reclamoE;

        public M07_COAgregarReclamoEquipaje(ReclamoEquipaje reclamoe)
        {
            this._reclamoE = reclamoe;
        }

        public override string ejecutar()
        {
            IDAO reclamoEDAO = FabricaDAO.instanciarDaoReclamoEquipaje();
            int result = reclamoEDAO.Agregar(_reclamoE);
            return result.ToString();
        }
        
    }
}