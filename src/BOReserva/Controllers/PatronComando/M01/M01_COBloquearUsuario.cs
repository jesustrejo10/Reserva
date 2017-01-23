using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando.M01
{
    public class M01_COBloquearUsuario : Command<Boolean>
    {
        private Entidad usuario;

        public M01_COBloquearUsuario(Entidad _usuario)
        {
            this.usuario = _usuario;
        }

        public override Boolean ejecutar()
        {
            IDAOLogin dao = (DAOLogin)FabricaDAO.instanciarDaoLogin();
            var respuesta = dao.BloquearUsuario(usuario);
            return respuesta;
        }
    }
}