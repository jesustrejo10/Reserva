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
    public class M05_COCrearMaletas : Command<int>
    {
         int _id;
         int _peso;

         public M05_COCrearMaletas(int id, int peso)
        {
            this._id = id;
            this._peso = peso;
        }

        public override int ejecutar()
        {
            IDAOCheckIn daoChaeckIn = (IDAOCheckIn)FabricaDAO.instanciarDaoCheckIn();
            int maleta = daoChaeckIn.CrearEquipaje(_id,_peso);

            return maleta;
        }

    }
}