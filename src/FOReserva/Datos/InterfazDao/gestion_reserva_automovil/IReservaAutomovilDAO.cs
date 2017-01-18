using FOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOReserva.Datos.InterfazDao.gestion_reserva_automovil
{
    public interface IReservaAutomovilDAO : IDAO
    {
        List<Entidad> ListarLugar();

        Entidad consultarRestaurantId(Entidad objeto);
    }

}