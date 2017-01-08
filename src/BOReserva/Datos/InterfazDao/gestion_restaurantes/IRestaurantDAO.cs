using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.Datos.InterfazDao.gestion_restaurantes
{
    public interface IRestaurantDAO : IDAO
    {
        List<Entidad> ListarLugar();
    }
}
