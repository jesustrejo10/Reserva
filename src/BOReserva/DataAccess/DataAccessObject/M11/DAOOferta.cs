using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace BOReserva.DataAccess.DataAccessObject.M11
{
    public class DAOOferta : DAO, IDAOOferta
    {
        public DAOOferta() { } 

        int IDAO.Agregar(Entidad e)
        {
            Oferta oferta = (Oferta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
            }
            catch (Exception)
            {

                throw;
            }

            return 0;
        }

        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();

        }

        Dictionary<int, Entidad> ConsultarTodos()
        {
            return null;
        }
        
           
    }
}