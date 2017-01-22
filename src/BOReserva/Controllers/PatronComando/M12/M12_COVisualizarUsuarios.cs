using BOReserva.DataAccess.DAO;
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
    /// Comando Visualizar Usuarios
    /// </summary>
    public class M12_COVisualizarUsuarios : Command<Dictionary<int, Entidad>>
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
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            Dictionary<int, Entidad> mapUsuarios = daoUsuario.ConsultarTodos();               
            return mapUsuarios;
        }

    }
}