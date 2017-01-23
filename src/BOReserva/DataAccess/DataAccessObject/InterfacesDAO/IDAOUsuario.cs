using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOUsuario : IDAO
    {
        String eliminarUsuario(int id);

        String statusUsuario(Entidad e, string status);
    }
}
