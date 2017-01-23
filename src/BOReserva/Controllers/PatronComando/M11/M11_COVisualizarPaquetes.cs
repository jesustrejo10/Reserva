using BOReserva.DataAccess.DataAccessObject.M11;
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
    public class M11_COVisualizarPaquetes : Command<List<Entidad>>
    {

        /// <summary>
        /// Sobreescritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override List<Entidad> ejecutar()
        {
            IDAOPaquete daoPaquete = FabricaDAO.instanciarDaoPaquete();
            List<Entidad> mapPaquetes = daoPaquete.ConsultarTodos();
            return mapPaquetes;
            //Aquí se puede poner una excepción
        }
    }
}