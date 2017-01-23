using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Interfaz DAO Equipaje
    /// </summary>
    public interface IDAOEquipaje : IDAO
    {
        int Eliminar(int id);
    }
}
