using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain.M14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    public class M14_COAgregarCamarote : Command<String>
    {
        Camarote _camarote;

        public M14_COAgregarCamarote()
        { }

        public M14_COAgregarCamarote(Camarote camarote)
        {
            this._camarote = camarote;
        }
        

        public override String ejecutar(){
            IDAO daoCamarote = FabricaDAO.instanciarDaoCamarote();       
            int test = daoCamarote.Agregar(_camarote);
            return test.ToString();
        }


    }
}