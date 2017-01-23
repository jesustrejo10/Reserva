using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
 
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para Visualizar los cruceros a la BD
    /// </summary>
    public class M14_COVisualizarCruceros : Command<Dictionary<int, Entidad>>
    {

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoCrucero = FabricaDAO.instanciarDaoCrucero();
            Dictionary<int, Entidad> mapCruceros = daoCrucero.ConsultarTodos();
            return mapCruceros;
        }
        
    }
}