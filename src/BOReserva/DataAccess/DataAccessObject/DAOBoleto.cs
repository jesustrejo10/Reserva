using System;
using System.Collections.Generic;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOBoleto : DAO, IDAOBoleto
    {
        int IDAOBoleto.Agregar(Entidad e)
        {
            return 1;
        }
        
    }
}