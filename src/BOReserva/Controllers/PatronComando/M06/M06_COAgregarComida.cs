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
    /// <summary>
    /// Comando destinado a agregar una comida a la BD
    /// </summary>
    public class M06_COAgregarComida: Command<bool>
    {
        private Entidad _nodo;

        /// <summary>
        /// Constructor del comando, recibe un objeto Entidad
        /// </summary>
        ///
        public M06_COAgregarComida(Entidad nodo) {
            this._nodo = nodo;
        }


        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>Retorna una Entidad</returns>
        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.crear(this._nodo);
        }
    }
}