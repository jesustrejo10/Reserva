using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOAutomovil : IDAO
    {
        bool ActivarDesactivar(Entidad e);
        bool Agregar(Entidad e);
        bool Modificar(Entidad e);
        bool Eliminar(Entidad e);
        Entidad Consultar(int id);
        Dictionary<int, Entidad> ConsultarTodos();
    }
}
