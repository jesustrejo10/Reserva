using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOReserva.Controllers.PatronComando.M19
{
    public interface IM19_COObtenerPaises
    {
        Dictionary<int, Entidad> obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais);
    }
}
