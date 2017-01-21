using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    public class M12_COEliminarUsuario: Command<String>
    {
        Usuario _usuario;
        int _ideliminar;

        public M12_COEliminarUsuario(Entidad usuario, int id)
        { 
            this._usuario = (Usuario) usuario;
            this._usuario._id = id;
        }

        public override String ejecutar(){
            DAOUsuario daoUsuario = (DAOUsuario)FabricaDAO.instanciarDaoUsuario();
            String test = daoUsuario.eliminarUsuario(_usuario._id);
            return test;
        }
    }
}