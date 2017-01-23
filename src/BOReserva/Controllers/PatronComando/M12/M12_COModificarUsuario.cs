using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    /// <summary>
    /// Comando Modificar Hoteles
    /// </summary>
    public class M12_COModificarUsuario : Command<string>
    {

        Usuario _usuario;
        int _idModificar;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="usuario">Usuario a modificar</param>
        /// <param name="id">Identificador del usuario a modificar</param>
        public M12_COModificarUsuario(Entidad usuario, int id)
        {
            this._usuario = (Usuario)usuario;
            this._usuario._id = id;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override string ejecutar()
        {
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            Entidad test = daoUsuario.Modificar(_usuario);
            Usuario usuario = (Usuario)test;

            return usuario.nombre;
        }

    }
}