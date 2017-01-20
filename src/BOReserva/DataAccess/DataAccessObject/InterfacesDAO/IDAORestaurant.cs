using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
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

        bool Crear(Entidad objeto);
        bool Modificar(Entidad objeto);
        bool Eliminar(Entidad objeto);
        List<Entidad> Consultar(Entidad objeto);
    }
}
