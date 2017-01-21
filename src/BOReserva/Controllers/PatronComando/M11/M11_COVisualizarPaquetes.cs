using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M11
{
    /// <summary>
    /// Comando Visualizar Paquetes
    /// </summary>
    public class M11_COVisualizarPaquetes : Command<Dictionary<int, Entidad>>
    {

        /// <summary>
        /// Sobreescritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoPaquete = FabricaDAO.instanciarDaoPaquete();
            Dictionary<int, Entidad> mapPaquetes = daoPaquete.ConsultarTodos();
            return mapPaquetes;
        }
    }
}