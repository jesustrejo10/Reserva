using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a agregar una comida a un vuelo en la BD
    /// </summary>
    ///
    public class M06_COAgregarComidaVuelo : Command<bool>
    {
         
        private Entidad _nodo;

        /// <summary>
        /// Constructor del comando, recibe un objeto Entidad
        /// </summary>
        ///
        public M06_COAgregarComidaVuelo(Entidad nodo)
        {
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
            return comidaDAO.agregarComidaVuelo(this._nodo);
        }
    }
}