using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;


namespace BOReserva.Controllers.PatronComando
{
    public class M06_COAgregarComida: Command<bool>
    {
        private Entidad _nodo;

        public M06_COAgregarComida(Entidad nodo) {
            this._nodo = nodo;
        }

        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.crear(this._nodo);
        }
    }
}