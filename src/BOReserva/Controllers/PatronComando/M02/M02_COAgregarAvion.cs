using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace BOReserva.Controllers.PatronComando
{

    public class M02_COAgregarAvion : Command<String>
    {

        Avion _avion;

        public M02_COAgregarAvion(Avion avion)
        {
            this._avion = avion;
        }

        public override String ejecutar()
        {
            IDAO daoAvion = FabricaDAO.instanciarDaoAvion();
            int test = daoAvion.Agregar(_avion);
            return test.ToString();
        }

    }

}