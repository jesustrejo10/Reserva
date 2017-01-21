using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_COAgregarComidaVuelo:Command<bool>
    {
        private Entidad _nodo;

        public M06_COAgregarComidaVuelo(Entidad nodo)
        {
            this._nodo = nodo;
        }

        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.agregarComidaVuelo(this._nodo);
        }
    }
}