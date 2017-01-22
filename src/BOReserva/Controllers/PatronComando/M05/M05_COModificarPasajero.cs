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
    public class M05_COModificarPasajero : Command<String>
    {
        Pasajero _pasajero;

        public M05_COModificarPasajero(Pasajero pasajero)
        {
            this._pasajero = pasajero;
        }

        public override String ejecutar()
        {
            IDAO daoPasajero= FabricaDAO.instanciarDaoPasajero();
            Entidad test = daoPasajero.Modificar(_pasajero);
            return "exito";
        }

    }
}