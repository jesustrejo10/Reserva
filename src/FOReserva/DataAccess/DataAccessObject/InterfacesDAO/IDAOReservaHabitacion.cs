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
        String modificarReservaHabitacion(int reserva, int cant_dias);
        Dictionary<int, Entidad> ConsultarTodosHabitacion(int id); 

        Dictionary<int,Entidad> ConsultarHotelesPorIdCiudad(int _lugar);

        List<CiudadHab> ObtenerCiudades();

    }
}
