using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Controllers.PatronComando
{
    public class M06_COEditarComida:Command<bool>
    {
        private Comida _nodo;

        public M06_COEditarComida(Entidad nodo)
        {
            this._nodo = (Comida)nodo;    
        }

        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.editarComida(this._nodo);
        }
    }
}