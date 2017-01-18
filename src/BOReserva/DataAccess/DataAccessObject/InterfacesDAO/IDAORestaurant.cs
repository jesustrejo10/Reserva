using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.M10
{
    public interface IDAORestaurant : IDAO
    {
        List<Entidad> ListarLugar();

        Entidad consultarRestaurantId(Entidad objeto);
    }
}
