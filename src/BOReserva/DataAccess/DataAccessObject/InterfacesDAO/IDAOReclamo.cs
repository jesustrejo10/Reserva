using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    public interface IDAOReclamo : IDAO
    {
        int modificarEstado(int id, int estado);
        int Eliminar(int id);
    }
}
