using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    /// <summary>
    /// Clase M09_COEliminar Hotel.
    /// Hereda de Comando
    /// </summary>
    public class M12_COEliminarUsuario: Command<String>
    {
        Usuario _usuario;
        int _ideliminar;
        /// <summary>
        /// Constructor  del Comando Eliminar Usuario
        /// </summary>
        /// <param name="usuario">
        /// Recibe el Usuario que se va a eliminar
        /// </param>
        /// <param name="id">
        /// Recibe el Id del Usuario que se va a eliminar
        /// </param>
        public M12_COEliminarUsuario(Entidad usuario, int id)
        { 
            this._usuario = (Usuario) usuario;
            this._usuario._id = id;
        }
        /// <summary>
        /// Sobre escritura del Ejecutar de Comando
        /// </summary>
        /// <returns>
        /// Devuelve un String, en el cual se indica el mensaje que sera llevado a la vista
        /// </returns>
        public override String ejecutar(){
            IDAOUsuario daoUsuario = (DAOUsuario)FabricaDAO.instanciarDaoUsuario();
            String test = daoUsuario.eliminarUsuario(_usuario._id);
            return test;
        }
    }
}