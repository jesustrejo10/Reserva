using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    public class M12_COStatusUsuario : Command<String>
    {
        Usuario _usuario;
        string _status;

        public M12_COStatusUsuario(Entidad usuario, string status)
        {
            this._usuario = (Usuario)usuario;
            this._status = status;
        }

        public override String ejecutar()
        {
            DAOUsuario daoUsuario = (DAOUsuario)FabricaDAO.instanciarDaoUsuario();
            String test = daoUsuario.statusUsuario(_usuario, _status);
            return test;
        }
    }
}