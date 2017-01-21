using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOBoleto : IDAO
    {
        int MBuscarIdaVuelta(int id);
        int MConteoCategoria(int codigo_vuelo, String tipo);
        int MConteoCapacidad(int codigo_vuelo, String tipo);
    }
}
