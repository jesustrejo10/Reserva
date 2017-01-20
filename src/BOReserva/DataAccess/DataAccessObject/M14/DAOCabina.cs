using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M14
{
    public class DAOCabina : DAO, IDAOCabina
    {
        int IDAO.Agregar(Entidad e) 
        {
            return 1;
        }
    }
}