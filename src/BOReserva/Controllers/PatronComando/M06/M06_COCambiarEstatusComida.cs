using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_COCambiarEstatusComida : Command<bool>
    {
        private Comida _nodo;

        public M06_COCambiarEstatusComida(Entidad nodo, int valor) {
            this._nodo = (Comida)nodo;
            this._nodo._estatus = valor;
        }

        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.cambiarEstadoComida(this._nodo);
        }
    }
}