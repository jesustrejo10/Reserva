using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M09
{
    public class DAOHabitacion : DAO, IDAOHabitacion
    {
        int IDAOHabitacion.Agregar(List<Entidad> e)
        {
             //aca recibo la listade vaina y lo agrego a la bd
            return 0;
        }

    }
}