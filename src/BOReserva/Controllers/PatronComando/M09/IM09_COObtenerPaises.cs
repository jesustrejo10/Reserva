using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.Controllers.PatronComando.M09
{
    public interface IM09_COObtenerPaises
    {
        Dictionary<int, Entidad> obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais);
    }
}
