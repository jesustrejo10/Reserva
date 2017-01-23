using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a editar la comida de la BD
    /// </summary>
    public class M06_COEditarComida:Command<bool>
    {
        private Comida _nodo;

        /// <summary>
        /// Constructor del comando, recibe un objeto Entidad
        /// </summary>
        ///
        public M06_COEditarComida(Entidad nodo)
        {
            this._nodo = (Comida)nodo;    
        }


        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>Retorna una Entidad</returns>
        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.editarComida(this._nodo);
        }
    }
}