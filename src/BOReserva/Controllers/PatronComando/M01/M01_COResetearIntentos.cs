using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M01
{
    public class M01_COResetearIntentos : Command<Boolean>
    {
        private Entidad usuario;

        public M01_COResetearIntentos(Entidad _usuario)
        {
            this.usuario = _usuario;
        }

        public override Boolean ejecutar()
        {
            IDAOLogin dao = (DAOLogin)FabricaDAO.instanciarDaoLogin();
            var respuesta = dao.ResetearIntentos(usuario);
            return respuesta;
        }
    }
}