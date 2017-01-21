using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_CORellenarComida:Command<Entidad>
    {
        private Entidad _nodo;

        public M06_CORellenarComida(Entidad nodo)
        {
            this._nodo = nodo;
        }

        public override Entidad ejecutar()
        {
            IDAOComida DAOcomida = FabricaDAO.instanciarComida();
            return DAOcomida.rellenarComida(_nodo);
        }
    }
}