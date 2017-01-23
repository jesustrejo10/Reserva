using System;
using System.Collections.Generic;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a consultar las comidas de la BD
    /// </summary>
    ///
    public class M06_COConsultarComidas: Command<List<Entidad>>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        ///
        public M06_COConsultarComidas()
        {

        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>Retorna una Entidad</returns>
        public override List<Entidad> ejecutar()
        {
            IDAOComida comidaDAO = FabricaDAO.instanciarComida();
            return comidaDAO.consultarComidas();
        }
    }
}