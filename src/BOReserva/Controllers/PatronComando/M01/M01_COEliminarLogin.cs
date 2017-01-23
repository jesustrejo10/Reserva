using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    internal class M01_COEliminarLogin : Command<bool>
    {
        private Entidad usuario;

        public M01_COEliminarLogin(Entidad _usuario)
        {
            this.usuario = _usuario;
        }

        public override Boolean ejecutar()
        {
            IDAOLogin dao = (DAOLogin)FabricaDAO.instanciarDaoLogin();
            var respuesta = dao.EliminarLogin(usuario);
            return respuesta;
        }
    }
}