using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M14_COAgregarCrucero : Command<String>
    {
        Crucero _crucero;

        public M14_COAgregarCrucero(Crucero crucero ) { 
            this._crucero = crucero;
        }        
                
        public override String ejecutar(){
            IDAO daoCrucero = FabricaDAO.instanciarDaoCrucero();       
            int test = daoCrucero.Agregar(_crucero);
            return test.ToString();            
        }

    }
}