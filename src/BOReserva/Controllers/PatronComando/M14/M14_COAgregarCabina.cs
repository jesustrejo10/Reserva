using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M14_COAgregarCabina : Command<String>
    {
        Cabina _cabina;

        public M14_COAgregarCabina(Cabina cabina) { 
            this._cabina = cabina;
        }
        

        public override String ejecutar(){
            IDAO daoCabina = FabricaDAO.instanciarDaoCabina();       
            int test = daoCabina.Agregar(_cabina);
            return test.ToString();
        }
    }
}