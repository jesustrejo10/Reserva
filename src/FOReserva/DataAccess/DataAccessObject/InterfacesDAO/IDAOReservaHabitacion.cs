using System;
using System.Collections.Generic;
using FOReserva.DataAccess.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
   public interface IDAOReservaHabitacion : IDAO
    {
        String eliminarReservaHabitacion(int id);

         List<Entidad> ConsultarHotelesPorIdCiudad(Entidad _lugar);

         Dictionary<int,Entidad> ObtenerCiudades();

    }
}
