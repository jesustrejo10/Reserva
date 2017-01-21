using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Interfaz que posee los metodos eliminarOferta
    /// </summary>
    interface IDAOOferta : IDAO
    {
        
        String eliminarOferta(int id);
    }
}
