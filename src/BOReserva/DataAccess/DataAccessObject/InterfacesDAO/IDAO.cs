using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DAO
{
    public interface IDAO
    {
        int Agregar(Entidad e);
        Entidad Modificar(Entidad e);
        Entidad Consultar(int id);
        Dictionary<int,Entidad> ConsultarTodos();

    }
}
