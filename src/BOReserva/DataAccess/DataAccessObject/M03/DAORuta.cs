using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M03
{
    public class DAORuta :  DAO, IDAOHotel {
     
        public DAORuta() {}

        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

    }
}