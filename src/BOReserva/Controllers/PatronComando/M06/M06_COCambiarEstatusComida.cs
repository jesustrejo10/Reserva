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
    /// Comando destinado a cambiar el estatus de una comida en la BD
    /// </summary>
    ///
    public class M06_COCambiarEstatusComida : Command<bool>
    {
        
        private Comida _nodo;

        /// <summary>
        /// Constructor del comando
        /// </summary>
        ///
        public M06_COCambiarEstatusComida(Entidad nodo, int valor) {
            this._nodo = (Comida)nodo;
            this._nodo._estatus = valor;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>Retorna una Entidad</returns>
        public override bool ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.cambiarEstadoComida(this._nodo);
        }
    }
}