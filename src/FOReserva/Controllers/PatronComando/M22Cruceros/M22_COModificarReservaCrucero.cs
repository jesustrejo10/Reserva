using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22Cruceros
{
    public class M22_COModificarReservaCrucero : Command<Entidad>
    {
        string _id;
        string _pasajeros;
        string _status;

        public M22_COModificarReservaCrucero(string id, string pasajeros, string status)
        {
            this._id = id;
            this._pasajeros = pasajeros;
            this._status = status;
        }

        public override Entidad ejecutar()
        {
            Entidad resultado;
            IDAOReservaCrucero daoCrucero = (IDAOReservaCrucero) FabricaDAO.instanciarDaoReservaCrucero();
            resultado = daoCrucero.CambiarReserva(_id, _pasajeros, _status);
            return resultado;
        }

    }
}