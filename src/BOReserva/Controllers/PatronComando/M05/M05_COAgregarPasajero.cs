using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;


namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para ingresar un pasajero
    /// </summary>
    public class M05_COAgregarPasajero : Command<String>
    {
        Pasajero _pasajero;

        /// <summary>
        /// Constructor del comando Agregar Pasajero
        /// </summary>
        /// <param name="pasajero"></param>
        public M05_COAgregarPasajero(Pasajero pasajero)
        {
            this._pasajero = pasajero;
        }

        /// <summary>
        /// Ejecutar comando Agregar un pasajero a la DB
        /// </summary>
        /// <returns></returns>
        public override String ejecutar()
        {
            IDAO daoPasajero = FabricaDAO.instanciarDaoPasajero();
            int test = daoPasajero.Agregar(_pasajero);
            return test.ToString();
        }

    }
}