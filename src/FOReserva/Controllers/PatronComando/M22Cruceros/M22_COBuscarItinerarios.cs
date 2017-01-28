using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22Cruceros
{
    public class M22_COBuscarItinerarios : Command<List<Entidad>>
    {
        string _id_crucero;
        string _fecha_ida;
        string _fecha_vuelta;

        public M22_COBuscarItinerarios(string id, string fecha_ida, string fecha_vuelta)
        {
            this._id_crucero = id;
            this._fecha_ida = fecha_ida;
            this._fecha_vuelta = fecha_vuelta;
        }

        public override List<Entidad> ejecutar()
        {
            List<Entidad> lista = null;
            IDAOReservaCrucero dao = (IDAOReservaCrucero)FabricaDAO.instanciarDaoReservaCrucero();
            lista = dao.buscarCrucerosItinerario(_id_crucero, _fecha_ida, _fecha_vuelta);
            return lista;
        }
    }
}