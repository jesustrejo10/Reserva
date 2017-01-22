using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOPaquete : IDAO
    {
        //Métodos propios para los paquetes
        List<Entidad> ConsultarTodos();
    }
}
