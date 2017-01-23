using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Interfaz DAO Reclamo Equipaje
    /// </summary>
    public interface IDAOReclamoEquipaje : IDAO
    {
        int Eliminar(int id);
        int modificarEstado(int id, string estado);
    }
}
