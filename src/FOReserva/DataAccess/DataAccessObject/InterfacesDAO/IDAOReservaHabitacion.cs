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
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="id">Id de la Habitacion a Eliminar</param>
        /// <returns>Retorna String</returns>
        String eliminarReservaHabitacion(int id);
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="reserva">Id de la Reserva a modificar</param>
        /// <param name="cant_dias">Cantidad de dias a modificar</param>
        /// <returns>Retorna String</returns>
        String modificarReservaHabitacion(int reserva, int cant_dias);
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="id">Id de la Reserva</param>
        /// <returns>Retorna  Dictionary<int, Entidad></returns>
        Dictionary<int, Entidad> ConsultarTodosHabitacion(int id);
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="id">Id de la Reserva</param>
        /// <returns>Retorna  Dictionary<int, Entidad></returns>
        Dictionary<int,Entidad> ConsultarHotelesPorIdCiudad(int _lugar);
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <returns>Retorna List<CiudadHab></returns>

        List<CiudadHab> ObtenerCiudades();

    }
}
