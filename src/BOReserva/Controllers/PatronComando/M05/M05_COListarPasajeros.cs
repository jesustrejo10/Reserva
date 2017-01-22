using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System.Collections.Generic;


namespace BOReserva.Controllers.PatronComando.M05
{
    public class M05_COListarPasajeros : Command<List<Entidad>>
    {
        int _id;

        public M05_COListarPasajeros() { }

        public M05_COListarPasajeros(int id)
        {
            _id = id;
        }

        public override List<Entidad> ejecutar()
        {
            IDAOCheckIn daoCheckIn = (IDAOCheckIn) FabricaDAO.instanciarDaoCheckIn();
            List<Entidad> list = daoCheckIn.ListarPasesPasajero(_id);
            return list;
        }
    }
}