using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    public class M12_COConsultarUsuario : Command<Entidad>
    {
        int valor;

        public M12_COConsultarUsuario(int value)
        {
            this.valor = value;
        }

        public override Entidad ejecutar()
        {
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            Entidad Usuario = daoUsuario.Consultar(valor);

            return Usuario;
        }
        
    }
}