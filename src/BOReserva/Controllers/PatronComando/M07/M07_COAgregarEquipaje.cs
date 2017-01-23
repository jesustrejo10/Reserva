using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;


namespace BOReserva.Controllers.PatronComando
{
    public class M07_COAgregarEquipaje: Command<String>
    {
        Equipaje _equipaje;

        public M07_COAgregarEquipaje(Equipaje equipaje)
        {
            this._equipaje = equipaje;
        }

        public override string ejecutar()
        {
            IDAO reclamoEDAO = FabricaDAO.instanciarDaoEquipaje();
            int result = reclamoEDAO.Agregar(_equipaje);
            
            return result.ToString();
        }        
    }
}