using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a consultar los vuelos de la BD
    /// </summary>
    public class M06_CORellenarComida:Command<Entidad>
    {
        private Entidad _nodo;

        /// <summary>
        /// Constructor del comando, recibe un objeto Entidad
        /// </summary>
        ///
        public M06_CORellenarComida(Entidad nodo)
        {
            this._nodo = nodo;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>Retorna una Entidad</returns>
        public override Entidad ejecutar()
        {
            IDAOComida DAOcomida = FabricaDAO.instanciarComida();
            return DAOcomida.rellenarComida(_nodo);
        }
    }
}