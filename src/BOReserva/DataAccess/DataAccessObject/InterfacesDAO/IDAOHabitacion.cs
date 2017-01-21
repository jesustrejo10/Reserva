using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Interfaz que tiene el metodo Agregarhab
    /// </summary>
    interface IDAOHabitacion : IDAO
    {
        string Agregarhab(Hotel hotel, int precio);

    }
}
