using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    public interface IDAO
    {
        int Agregar(Entidad e);
        Entidad Modificar(Entidad e);
        Entidad Consultar(int id);
        Dictionary<int,Entidad> ConsultarTodos();

    }
}
