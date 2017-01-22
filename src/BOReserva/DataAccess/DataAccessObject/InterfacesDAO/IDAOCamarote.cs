using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOCamarote : IDAO
    {
        Dictionary<int, Entidad> ConsultarTodos(int idCrucero);
    }
}
