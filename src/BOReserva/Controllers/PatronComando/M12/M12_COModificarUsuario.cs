using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    public class M12_COModificarUsuario : Command<string>
    {

        Usuario _usuario;
        int _idModificar;

        public M12_COModificarUsuario(Entidad usuario, int id)
        {
            this._usuario = (Usuario)usuario;
            this._usuario._id = id;
        }

        public override string ejecutar()
        {
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            Entidad test = daoUsuario.Modificar(_usuario);
            Usuario usuario = (Usuario)test;

            return usuario.nombre;
        }

    }
}