using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DAO
{
    interface IDAO
    {
        int Agregar(Entidad e);
        Entidad Modificar(Entidad e);
        Entidad Consultar(int id);
        Entidad Consultar(Entidad e);

    }
}
