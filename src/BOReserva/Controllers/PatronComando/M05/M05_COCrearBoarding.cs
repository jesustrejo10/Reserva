using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para agregar un boleto a la DB
    /// </summary>
    public class M05_COCrearBoarding : Command<int>
    {
        BoardingPass _boarding;


        public M05_COCrearBoarding(BoardingPass boarding)
        {
            this._boarding = boarding;
        }

        public override int ejecutar()
        {
            IDAO daoBoarding = FabricaDAO.instanciarDaoCheckIn();
            int test = daoBoarding.Agregar(_boarding);
            return test;
        }

    }
}