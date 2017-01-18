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
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para a;adir un hotel a la BD
    /// </summary>
    public class M05_COAgregarPasajero : Command<String>
    {
        Pasajero _pasajero;

        public M05_COAgregarPasajero(Pasajero pasajero)
        {
            this._pasajero = pasajero;
        }

        public override String ejecutar()
        {
            IDAO daoPasajero= FabricaDAO.instanciarDaoPasajero();
            int test = daoPasajero.Agregar(_pasajero);
            return test.ToString();
        }

    }
}