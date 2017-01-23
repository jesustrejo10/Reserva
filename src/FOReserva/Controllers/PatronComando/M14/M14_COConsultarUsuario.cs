using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace FOReserva.Controllers.PatronComando.M14
{
    public class M14_COConsultarUsuario : Command<Entidad>
    {
        Entidad _u;

        public M14_COConsultarUsuario(Entidad usuario)
        {
            this._u = usuario;
        }

        public override Entidad ejecutar()
        {
            IDAORegistroU daoUsuario = FabricaDAO.instanciarDaoUsuario();
            return daoUsuario.ConsultarUsuarioPerfil(_u);
        }

    }
}