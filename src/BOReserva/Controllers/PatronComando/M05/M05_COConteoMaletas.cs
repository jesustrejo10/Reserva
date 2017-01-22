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
    public class M05_COConteoMaletas : Command<int>
    {
         int _id;

        public M05_COConteoMaletas(int id)
        {
            this._id = id;
        }

        public override int ejecutar()
        {
            IDAOCheckIn daoChaeckIn = (IDAOCheckIn)FabricaDAO.instanciarDaoCheckIn();
            int conteo = daoChaeckIn.MConteoMaletas(_id);
            return conteo;
        }

    }
}