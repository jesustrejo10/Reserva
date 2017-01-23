using System;
using System.Collections.Generic;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a consultar los vuelos de la BD
    /// </summary>
    public class M06_COConsultarVuelos:Command<List<Entidad>>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        ///
        public M06_COConsultarVuelos()
        {

        }


        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>Retorna una Entidad</returns>
        public override List<Entidad> ejecutar()
        {
            IDAOVuelo DAOVuelo = (IDAOVuelo) FabricaDAO.instanciarDAOVuelo();
            return DAOVuelo.ConsultarTodos();
        } 
    }
}