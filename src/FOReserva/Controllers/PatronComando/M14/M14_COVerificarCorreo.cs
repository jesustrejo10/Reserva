using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject;

namespace FOReserva.Controllers.PatronComando.M14
{
    public class M14_COVerificarCorreo : Command<String>
    {
        Usuario1 _u;

        public M14_COVerificarCorreo(Usuario1 usuario)
        {
            this._u = usuario;
        }

        public override String ejecutar()
        {
            IDAORegistroU daoUsuario = FabricaDAO.instanciarDaoUsuario();
            int test = daoUsuario.VerificarCorreo(_u);
            return test.ToString();
        }

    }
}
